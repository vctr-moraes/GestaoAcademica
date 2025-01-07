using GestaoAcademica.Core.Messages;
using GestaoAcademica.Cursos.Domain.Interfaces;
using GestaoAcademica.Cursos.Domain.Models;
using MediatR;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class CursoCommandHandler : IRequestHandler<CadastrarCursoCommand, bool>
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoCommandHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<bool> Handle(CadastrarCursoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var curso = new Curso(
                message.Nome,
                message.Descricao,
                message.CargaHoraria,
                message.DataCriacao,
                (Grau)message.Grau,
                (Modalidade)message.Modalidade);

            _cursoRepository.Adicionar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
