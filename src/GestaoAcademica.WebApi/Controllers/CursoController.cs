using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Cursos.Application.Commands;
using GestaoAcademica.Cursos.Application.Queries;
using GestaoAcademica.Cursos.Application.Queries.Dtos;
using GestaoAcademica.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICursoQueries _cursoQueries;

        public CursoController(IMediatorHandler mediatorHandler, ICursoQueries cursoQueries)
        {
            _mediatorHandler = mediatorHandler;
            _cursoQueries = cursoQueries;
        }

        [HttpGet]
        [Route("obter-curso")]
        public async Task<CursosDto> ObterCursoPorId(Guid idCurso)
        {
            return await _cursoQueries.ObterCursoPorId(idCurso);
        }

        [HttpGet]
        [Route("obter-cursos")]
        public async Task<IEnumerable<CursosDto>> ObterCursos()
        {
            return await _cursoQueries.ObterCursos();
        }

        [HttpGet]
        [Route("obter-cursos-disciplinas")]
        public async Task<IEnumerable<CursosDisciplinasDto>> ObterCursosDisciplinas()
        {
            return await _cursoQueries.ObterCursosDisciplinas();
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

        [HttpDelete]
        [Route("excluir-curso")]
        public async Task ExcluirCurso(Guid cursoId)
        {
            var command = new ExcluirCursoCommand(cursoId);
            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("cadastrar-disciplina")]
        public async Task CadastrarDisciplina(DisciplinaCursoDto disciplinaDto)
        {
            var command = new CadastrarDisciplinaCommand(
                disciplinaDto.Nome,
                disciplinaDto.Descricao,
                disciplinaDto.CargaHoraria);

            await _mediatorHandler.EnviarComando(command);
        }

        [HttpDelete]
        [Route("excluir-disciplina")]
        public async Task ExcluirDisciplina(Guid disciplinaId)
        {
            var command = new ExcluirDisciplinaCommand(disciplinaId);
            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("vincular-disciplina")]
        public async Task VincularDisciplina(Guid cursoId, Guid disciplinaId)
        {
            var command = new VincularDisciplinaCommand(cursoId, disciplinaId);
            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("desvincular-disciplina")]
        public async Task DesvincularDisciplina(Guid cursoId, Guid disciplinaId)
        {
            var command = new DesvincularDisciplinaCommand(cursoId, disciplinaId);
            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("atribuir-professor-coordenador")]
        public async Task AtribuirProfessorCoordenador(Guid idCurso, Guid idProfessor, string nomeProfessor)
        {
            var command = new AtribuirProfessorCoordenadorCommand(idCurso, idProfessor, nomeProfessor);
            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("desvincular-professor-coordenador")]
        public async Task DesvincularProfessorCoordenador(Guid idCurso, Guid idProfessor)
        {
            var command = new DesvincularProfessorCoordenadorCommand(idCurso, idProfessor);
            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("atribuir-professor")]
        public async Task AtribuirProfessor(Guid idDisciplina, Guid idProfessor, string nomeProfessor)
        {
            var command = new AtribuirProfessorCommand(idDisciplina, idProfessor, nomeProfessor);
            await _mediatorHandler.EnviarComando(command);
        }

        [HttpPost]
        [Route("desvincular-professor")]
        public async Task DesvincularProfessor(Guid idDisciplina, Guid idProfessor)
        {
            var command = new DesvincularProfessorCommand(idDisciplina, idProfessor);
            await _mediatorHandler.EnviarComando(command);
        }
    }
}
