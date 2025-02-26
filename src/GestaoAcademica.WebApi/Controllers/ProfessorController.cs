using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Professores.Application.Commands;
using GestaoAcademica.Professores.Application.Queries;
using GestaoAcademica.Professores.Application.Queries.Dtos;
using GestaoAcademica.WebApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProfessorQueries _professorQueries;

        public ProfessorController(
            IMediatorHandler mediatorHandler,
            IProfessorQueries professorQueries,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _professorQueries = professorQueries;
        }

        [HttpGet]
        [Route("obter-professor")]
        public async Task<ActionResult<ProfessoresDto>> ObterProfessor(Guid idProfessor)
        {
            var professor = await _professorQueries.ObterProfessor(idProfessor);
            return professor != null ? Ok(professor) : NotFound();
        }

        [HttpGet]
        [Route("obter-professores")]
        public async Task<ActionResult<IEnumerable<ProfessoresDto>>> ObterProfessores()
        {
            var professores = await _professorQueries.ObterProfessores();
            return professores != null && professores.Any() ? Ok(professores) : NoContent();
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
