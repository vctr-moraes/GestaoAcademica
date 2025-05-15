using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Cursos.Application.Commands;
using GestaoAcademica.Cursos.Application.Dtos;
using GestaoAcademica.Cursos.Application.Queries;
using GestaoAcademica.Cursos.Application.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICursoQueries _cursoQueries;

        public CursoController(
            IMediatorHandler mediatorHandler,
            ICursoQueries cursoQueries,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _cursoQueries = cursoQueries;
        }

        [HttpGet]
        [Route("obter-curso")]
        public async Task<ActionResult<CursoDetailsDto>> ObterCurso(Guid idCurso)
        {
            var curso = await _cursoQueries.ObterCursoPorId(idCurso);
            return curso != null ? Ok(curso) : NotFound();
        }

        [HttpGet]
        [Route("obter-cursos")]
        public async Task<ActionResult<IEnumerable<CursoDetailsDto>>> ObterCursos()
        {
            var cursos = await _cursoQueries.ObterCursos();
            return cursos != null && cursos.Any() ? Ok(cursos) : NoContent();
        }

        [HttpGet]
        [Route("obter-cursos-disciplinas")]
        public async Task<ActionResult<IEnumerable<CursosDisciplinasDetailsDto>>> ObterCursosDisciplinas()
        {
            var cursosDisciplinas = await _cursoQueries.ObterCursosDisciplinas();
            return cursosDisciplinas != null && cursosDisciplinas.Any() ? Ok(cursosDisciplinas) : NoContent();
        }

        [HttpPost]
        [Route("cadastrar-curso")]
        public async Task<ActionResult> CadastrarCurso(CursoCreateEditDto cursoDto)
        {
            var command = new CadastrarCursoCommand(
                cursoDto.Nome,
                cursoDto.Descricao,
                cursoDto.CargaHoraria,
                cursoDto.DataCriacao,
                cursoDto.Grau,
                cursoDto.Modalidade);

            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPut]
        [Route("editar-curso")]
        public async Task<ActionResult> AtualizarCurso(Guid idCurso, CursoCreateEditDto cursoDto)
        {
            var curso = await _cursoQueries.ObterCursoPorId(idCurso);

            if (curso == null) return BadRequest("Curso não encontrado");

            var command = new AtualizarCursoCommand(
                cursoDto.Id,
                cursoDto.Nome,
                cursoDto.Descricao,
                cursoDto.CargaHoraria,
                cursoDto.DataCriacao,
                cursoDto.Grau,
                cursoDto.Modalidade);

            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpDelete]
        [Route("excluir-curso")]
        public async Task<ActionResult> ExcluirCurso(Guid cursoId)
        {
            var command = new ExcluirCursoCommand(cursoId);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPost]
        [Route("cadastrar-disciplina")]
        public async Task<ActionResult> CadastrarDisciplina(DisciplinaCreateEditDto disciplinaDto)
        {
            var command = new CadastrarDisciplinaCommand(
                disciplinaDto.Nome,
                disciplinaDto.Descricao,
                disciplinaDto.CargaHoraria);

            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPut]
        [Route("editar-disciplina")]
        public async Task<ActionResult> AtualizarDisciplina(Guid idDisciplina, DisciplinaCreateEditDto disciplinaDto)
        {
            var disciplina = await _cursoQueries.ObterDisciplinaPorId(idDisciplina);

            if (disciplina == null) return BadRequest("Disciplina não encontrada");

            var command = new AtualizarDisciplinaCommand(
                disciplinaDto.Id,
                disciplinaDto.Nome,
                disciplinaDto.Descricao,
                disciplinaDto.CargaHoraria);

            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpDelete]
        [Route("excluir-disciplina")]
        public async Task<ActionResult> ExcluirDisciplina(Guid disciplinaId)
        {
            var command = new ExcluirDisciplinaCommand(disciplinaId);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPost]
        [Route("vincular-disciplina")]
        public async Task<ActionResult> VincularDisciplina(Guid cursoId, Guid disciplinaId)
        {
            var command = new VincularDisciplinaCommand(cursoId, disciplinaId);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPost]
        [Route("desvincular-disciplina")]
        public async Task<ActionResult> DesvincularDisciplina(Guid cursoId, Guid disciplinaId)
        {
            var command = new DesvincularDisciplinaCommand(cursoId, disciplinaId);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPost]
        [Route("atribuir-professor-coordenador")]
        public async Task<ActionResult> AtribuirProfessorCoordenador(Guid idCurso, Guid idProfessor, string nomeProfessor)
        {
            var command = new AtribuirProfessorCoordenadorCommand(idCurso, idProfessor, nomeProfessor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPost]
        [Route("desvincular-professor-coordenador")]
        public async Task<ActionResult> DesvincularProfessorCoordenador(Guid idCurso, Guid idProfessor)
        {
            var command = new DesvincularProfessorCoordenadorCommand(idCurso, idProfessor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPost]
        [Route("atribuir-professor")]
        public async Task<ActionResult> AtribuirProfessor(Guid idDisciplina, Guid idProfessor, string nomeProfessor)
        {
            var command = new AtribuirProfessorCommand(idDisciplina, idProfessor, nomeProfessor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpPost]
        [Route("desvincular-professor")]
        public async Task<ActionResult> DesvincularProfessor(Guid idDisciplina, Guid idProfessor)
        {
            var command = new DesvincularProfessorCommand(idDisciplina, idProfessor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }
    }
}
