using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Turmas.Application.Commands;
using GestaoAcademica.Turmas.Application.Dtos;
using GestaoAcademica.Turmas.Application.Queries;
using GestaoAcademica.Turmas.Application.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/turmas")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITurmaQueries _turmaQueries;

        public TurmaController(
            IMediatorHandler mediatorHandler,
            ITurmaQueries turmaQueries,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _turmaQueries = turmaQueries;
        }

        [HttpGet]
        [Route("obter-turma")]
        public async Task<ActionResult<TurmaAlunosDetailsDto>> ObterTurma(Guid idTurma)
        {
            try
            {
                var turma = await _turmaQueries.ObterTurmaPorId(idTurma);
                return turma != null ? Ok(turma) : NotFound();
            }
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
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
                return turmas != null ? Ok(turmas) : NotFound();
            }
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
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
                    return Ok();
                }

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
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
                    return Ok();
                }

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
                throw;
            }
        }
    }
}
