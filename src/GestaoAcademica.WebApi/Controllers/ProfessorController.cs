using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Professores.Application.Commands;
using GestaoAcademica.Professores.Application.Dtos;
using GestaoAcademica.Professores.Application.Queries;
using GestaoAcademica.Professores.Application.Queries.Dtos;
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
        public async Task<ActionResult<ProfessorDetailsDto>> ObterProfessor(Guid idProfessor)
        {
            var professor = await _professorQueries.ObterProfessor(idProfessor);
            return professor != null ? Ok(professor) : NotFound();
        }

        [HttpGet]
        [Route("obter-professores")]
        public async Task<ActionResult<IEnumerable<ProfessorDetailsDto>>> ObterProfessores()
        {
            var professores = await _professorQueries.ObterProfessores();
            return professores != null && professores.Any() ? Ok(professores) : NoContent();
        }

        [HttpPost]
        [Route("cadastrar-professor")]
        public async Task<ActionResult> CadastrarProfessor(ProfessorCreateEditDto professorDto)
        {
            var command = new CadastrarProfessorCommand(
                professorDto.Nome,
                professorDto.NumeroDocumento,
                professorDto.DataNascimento,
                professorDto.Endereco);

            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPut]
        [Route("editar-professor")]
        public async Task<ActionResult> AtualizarProfessor(Guid idProfessor, ProfessorCreateEditDto professorDto)
        {
            var professor = await _professorQueries.ObterProfessor(idProfessor);

            if (professor == null) return BadRequest("Professor não encontrado");

            var command = new AtualizarProfessorCommand(
                professorDto.Id,
                professorDto.Nome,
                professorDto.NumeroDocumento,
                professorDto.DataNascimento,
                professorDto.Endereco);

            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpDelete]
        [Route("excluir-professor")]
        public async Task<ActionResult> ExcluirProfessor(Guid idProfessor)
        {
            var command = new ExcluirProfessorCommand(idProfessor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }
    }
}
