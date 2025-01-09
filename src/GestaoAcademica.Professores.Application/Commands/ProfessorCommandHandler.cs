using GestaoAcademica.Core.Messages;
using GestaoAcademica.Professores.Domain.Interfaces;
using GestaoAcademica.Professores.Domain.Models;
using MediatR;

namespace GestaoAcademica.Professores.Application.Commands
{
    public class ProfessorCommandHandler : IRequestHandler<CadastrarProfessorCommand, bool>
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorCommandHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
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

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
