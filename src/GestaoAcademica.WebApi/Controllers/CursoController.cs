using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Cursos.Application.Commands;
using GestaoAcademica.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        public CursoController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        [Route("cadastrar-curso")]
        public async Task CadastrarCurso(CursoDto cursoDto)
        {
            var command = new CadastrarCursoCommand(
                cursoDto.Nome,
                cursoDto.Descricao,
                cursoDto.CargaHoraria,
                cursoDto.DataCriacao,
                cursoDto.Grau,
                cursoDto.Modalidade);

            await _mediatorHandler.EnviarComando(command);
        }
    }
}
