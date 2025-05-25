using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Professores.Application.Commands;
using GestaoAcademica.Professores.Application.Dtos;
using GestaoAcademica.Professores.Application.Queries;
using GestaoAcademica.Professores.Application.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProfessorQueries _professorQueries;
        private readonly ILogger<ProfessorController> _logger;

        public ProfessorController(
            IMediatorHandler mediatorHandler,
            IProfessorQueries professorQueries,
            INotificationHandler<DomainNotification> notifications,
            ILogger<ProfessorController> logger) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _professorQueries = professorQueries;
            _logger = logger;
        }

        [HttpGet]
        [Route("obter-professor")]
        public async Task<ActionResult<ProfessorDetailsDto>> ObterProfessor(Guid idProfessor)
        {
            try
            {
                var professor = await _professorQueries.ObterProfessor(idProfessor);

                _logger.LogInformation(message: $"Sucesso ao obter professor.", args: [JsonSerializer.Serialize(professor), DateTime.Now, nameof(GetType)]);

                return professor != null ? Ok(professor) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao obter professor.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }

        [HttpGet]
        [Route("obter-professores")]
        public async Task<ActionResult<IEnumerable<ProfessorDetailsDto>>> ObterProfessores()
        {
            try
            {
                var professores = await _professorQueries.ObterProfessores();

                _logger.LogInformation(message: $"Sucesso ao obter professores.", args: [JsonSerializer.Serialize(professores), DateTime.Now, nameof(GetType)]);

                return professores != null && professores.Any() ? Ok(professores) : NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao obter professores.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }

        [HttpPost]
        [Route("cadastrar-professor")]
        public async Task<ActionResult> CadastrarProfessor(ProfessorCreateEditDto professorDto)
        {
            try
            {
                var command = new CadastrarProfessorCommand(
                    professorDto.Nome,
                    professorDto.NumeroDocumento,
                    professorDto.DataNascimento,
                    professorDto.Endereco);

                await _mediatorHandler.EnviarComando(command);

                if (OperacaoValida())
                {
                    _logger.LogInformation(message: $"Sucesso ao cadastrar professor.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao cadastrar professor.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao cadastrar professor.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }

        [HttpPut]
        [Route("editar-professor")]
        public async Task<ActionResult> AtualizarProfessor(Guid idProfessor, ProfessorCreateEditDto professorDto)
        {
            try
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
                    _logger.LogInformation(message: $"Sucesso ao atualizar professor.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao atualizar professor.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao atualizar professor.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }

        [HttpDelete]
        [Route("excluir-professor")]
        public async Task<ActionResult> ExcluirProfessor(Guid idProfessor)
        {
            try
            {
                var command = new ExcluirProfessorCommand(idProfessor);
                await _mediatorHandler.EnviarComando(command);

                if (OperacaoValida())
                {
                    _logger.LogInformation(message: $"Sucesso ao excluir professor.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao excluir professor.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao excluir professor.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }
    }
}
