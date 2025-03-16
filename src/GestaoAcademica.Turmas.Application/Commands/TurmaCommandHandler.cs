using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Turmas.Domain.Events;
using GestaoAcademica.Turmas.Domain.Interfaces;
using GestaoAcademica.Turmas.Domain.Models;
using MediatR;

namespace GestaoAcademica.Turmas.Application.Commands
{
    public class TurmaCommandHandler : IRequestHandler<AbrirTurmaCommand, bool>, IRequestHandler<MatricularAlunoCommand, bool>
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public TurmaCommandHandler(ITurmaRepository turmaRepository, IMediatorHandler mediatorHandler)
        {
            _turmaRepository = turmaRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AbrirTurmaCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var turma = new Turma(message.DataInicio, message.IdCurso, message.NomeCurso);

            _turmaRepository.Adicionar(turma);
            return await _turmaRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(MatricularAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var turma = await _turmaRepository.ObterPorId(message.IdTurma);

            if (turma == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("turma", "Turma não encontrada."));
                return false;
            }

            if (turma.Alunos.Any(x => x.IdAluno == message.IdAluno))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("aluno", "Aluno já matriculado na turma."));
                return false;
            }

            var alunoCursante = new AlunoCursante(turma, message.IdAluno, message.NomeAluno);

            turma.MatricularAluno(alunoCursante);

            _turmaRepository.AdicionarAlunoCursante(alunoCursante);
            var result = await _turmaRepository.UnitOfWork.Commit();

            if (result)
            {
                await _mediatorHandler.PublicarEvento(new NovoAlunoMatriculadoEvent(turma.Id, alunoCursante.NomeAluno, turma.NomeCurso));
            }

            return result;
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
