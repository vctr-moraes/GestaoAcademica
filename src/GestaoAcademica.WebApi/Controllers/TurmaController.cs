using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Turmas.Application.Commands;
using GestaoAcademica.Turmas.Application.Queries;
using GestaoAcademica.Turmas.Application.Queries.Dtos;
using GestaoAcademica.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/turmas")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITurmaQueries _turmaQueries;

        public TurmaController(IMediatorHandler mediatorHandler, ITurmaQueries turmaQueries)
        {
            _mediatorHandler = mediatorHandler;
            _turmaQueries = turmaQueries;
        }

        [HttpPost]
        [Route("abrir-turma")]
        public async Task AbrirTurma([FromBody] TurmaDto turmaDto)
        {
            var command = new AbrirTurmaCommand(turmaDto.DataInicio, turmaDto.IdCurso, turmaDto.NomeCurso);

            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("matricular-aluno")]
        public async Task MatricularAluno(Guid idTurma, Guid idAluno, string nomeAluno)
        {
            var command = new MatricularAlunoCommand(idTurma, idAluno, nomeAluno);

            await _mediatorHandler.EnviarComando(command);
        }

        [HttpGet]
        [Route("obter-turma")]
        public async Task<TurmaAlunosDto> ObterTurma(Guid idTurma)
        {
            return await _turmaQueries.ObterTurmaPorId(idTurma);
        }
    }
}
