using GestaoAcademica.Core.Messages;
using GestaoAcademica.Turmas.Domain.Interfaces;
using GestaoAcademica.Turmas.Domain.Models;
using MediatR;

namespace GestaoAcademica.Turmas.Application.Commands
{
    public class TurmaCommandHandler : IRequestHandler<AbrirTurmaCommand, bool>, IRequestHandler<MatricularAlunoCommand, bool>
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaCommandHandler(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
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

            if (turma == null) return false;
            if (turma.Alunos.Any(x => x.IdAluno == message.IdAluno)) return false;

            var alunoCursante = new AlunoCursante(turma, message.IdAluno, message.NomeAluno);

            turma.MatricularAluno(alunoCursante);

            _turmaRepository.AdicionarAlunoCursante(alunoCursante);
            return await _turmaRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
