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
            var turma = await _turmaQueries.ObterTurmaPorId(idTurma);
            return turma != null ? Ok(turma) : NotFound();
        }

        [HttpGet]
        [Route("obter-turmas")]
        public async Task<ActionResult<List<TurmaAlunosDetailsDto>>> ObterTurmas()
        {
            var turmas = await _turmaQueries.ObterTurmas();
            return turmas != null ? Ok(turmas) : NotFound();
        }

        [HttpPost]
        [Route("abrir-turma")]
        public async Task AbrirTurma([FromBody] TurmaCreateEditDto turmaDto)
        {
            var command = new AbrirTurmaCommand(turmaDto.DataInicio, turmaDto.IdCurso, turmaDto.NomeCurso);

            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("matricular-aluno")]
        public async Task<ActionResult> MatricularAluno(Guid idTurma, Guid idAluno, string nomeAluno)
        {
            var command = new MatricularAlunoCommand(idTurma, idAluno, nomeAluno);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }
    }
}
