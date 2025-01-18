using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Turmas.Application.Commands;
using GestaoAcademica.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/turmas")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        public TurmaController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        [Route("abrir-turma")]
        public async Task AbrirTurma([FromBody] TurmaDto turmaDto)
        {
            var command = new AbrirTurmaCommand(turmaDto.DataInicio, turmaDto.IdCurso, turmaDto.NomeCurso);

            await _mediatorHandler.EnviarComando(command);
        }
    }
}
