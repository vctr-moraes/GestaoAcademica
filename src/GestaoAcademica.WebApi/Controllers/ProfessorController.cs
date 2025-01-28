using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Professores.Application.Commands;
using GestaoAcademica.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ProfessorController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        [Route("cadastrar-professor")]
        public async Task CadastrarProfessor(ProfessorDto professorDto)
        {
            var command = new CadastrarProfessorCommand(
                professorDto.Nome,
                professorDto.NumeroDocumento,
                professorDto.DataNascimento,
                professorDto.Endereco);

            await _mediatorHandler.EnviarComando(command);
        }

        [HttpDelete]
        [Route("excluir-professor")]
        public async Task ExcluirProfessor(Guid idProfessor)
        {
            var command = new ExcluirProfessorCommand(idProfessor);
            await _mediatorHandler.EnviarComando(command);
        }
    }
}
