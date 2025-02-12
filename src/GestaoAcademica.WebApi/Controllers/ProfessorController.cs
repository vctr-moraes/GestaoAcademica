using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Professores.Application.Commands;
using GestaoAcademica.Professores.Application.Queries;
using GestaoAcademica.Professores.Application.Queries.Dtos;
using GestaoAcademica.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProfessorQueries _professorQueries;

        public ProfessorController(IMediatorHandler mediatorHandler, IProfessorQueries professorQueries)
        {
            _mediatorHandler = mediatorHandler;
            _professorQueries = professorQueries;
        }

        [HttpGet]
        [Route("obter-professor")]
        public async Task<ProfessoresDto> ObterProfessor(Guid idProfessor)
        {
            return await _professorQueries.ObterProfessor(idProfessor);
        }

        [HttpGet]
        [Route("obter-professores")]
        public async Task<IEnumerable<ProfessoresDto>> ObterProfessores()
        {
            return await _professorQueries.ObterProfessores();
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
