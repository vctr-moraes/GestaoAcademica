using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Turmas.Application.Commands;
using GestaoAcademica.Turmas.Application.Dtos;
using GestaoAcademica.Turmas.Application.Queries;
using GestaoAcademica.Turmas.Application.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/turmas")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITurmaQueries _turmaQueries;
        private readonly ILogger<TurmaController> _logger;

        public TurmaController(
            IMediatorHandler mediatorHandler,
            ITurmaQueries turmaQueries,
            INotificationHandler<DomainNotification> notifications,
            ILogger<TurmaController> logger) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _turmaQueries = turmaQueries;
            _logger = logger;
        }

        [HttpGet]
        [Route("obter-turma")]
        public async Task<ActionResult<TurmaAlunosDetailsDto>> ObterTurma(Guid idTurma)
        {
            try
            {
                var turma = await _turmaQueries.ObterTurmaPorId(idTurma);

                _logger.LogInformation(message: $"Sucesso ao obter turma.", args: [JsonSerializer.Serialize(turma), DateTime.Now, nameof(GetType)]);

                return turma != null ? Ok(turma) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao obter turma.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }

        [HttpGet]
        [Route("obter-turmas")]
        public async Task<ActionResult<List<TurmaAlunosDetailsDto>>> ObterTurmas()
        {
            try
            {
                var turmas = await _turmaQueries.ObterTurmas();

                _logger.LogInformation(message: $"Sucesso ao obter turmas.", args: [JsonSerializer.Serialize(turmas), DateTime.Now, nameof(GetType)]);

                return turmas != null ? Ok(turmas) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao obter turmas.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }

        [HttpPost]
        [Route("abrir-turma")]
        public async Task<ActionResult> AbrirTurma([FromBody] TurmaCreateEditDto turmaDto)
        {
            try
            {
                var command = new AbrirTurmaCommand(turmaDto.DataInicio, turmaDto.IdCurso, turmaDto.NomeCurso);
                await _mediatorHandler.EnviarComando(command);

                if (OperacaoValida())
                {
                    _logger.LogInformation(message: $"Sucesso ao abrir turma.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao abrir turma.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao abrir turma.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }

        [HttpPost]
        [Route("matricular-aluno")]
        public async Task<ActionResult> MatricularAluno(Guid idTurma, Guid idAluno, string nomeAluno)
        {
            try
            {
                var command = new MatricularAlunoCommand(idTurma, idAluno, nomeAluno);
                await _mediatorHandler.EnviarComando(command);

                if (OperacaoValida())
                {
                    _logger.LogInformation(message: $"Sucesso ao matricular aluno.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao matricular aluno.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao matricular aluno.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }
    }
}
