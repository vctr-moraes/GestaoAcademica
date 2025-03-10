using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Professores.Domain.Interfaces;
using GestaoAcademica.Professores.Domain.Models;
using MediatR;

namespace GestaoAcademica.Professores.Application.Commands
{
    public class ProfessorCommandHandler : IRequestHandler<CadastrarProfessorCommand, bool>, IRequestHandler<ExcluirProfessorCommand, bool>
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ProfessorCommandHandler(IProfessorRepository professorRepository, IMediatorHandler mediatorHandler)
        {
            _professorRepository = professorRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(CadastrarProfessorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var professor = new Professor(
                message.Nome,
                message.NumeroDocumento,
                message.DataNascimento,
                message.Endereco);

            _professorRepository.Adicionar(professor);
            return await _professorRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(ExcluirProfessorCommand message, CancellationToken cancellationToken)
        {
            var professor = await _professorRepository.ObterPorId(message.IdProfessor);

            if (professor == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("professor", "Professor não encontrado."));
                return false;
            }

            if (professor.Status == Status.Ativo)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("professor", "Não é possível excluir um professor ativo."));
                return false;
            }

            _professorRepository.Excluir(professor);
            return await _professorRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
