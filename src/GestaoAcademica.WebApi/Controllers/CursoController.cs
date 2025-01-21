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

        [HttpPost]
        [Route("cadastrar-disciplina")]
        public async Task CadastrarDisciplina(DisciplinaDto disciplinaDto)
        {
            var command = new CadastrarDisciplinaCommand(
                disciplinaDto.Nome,
                disciplinaDto.Descricao,
                disciplinaDto.CargaHoraria);

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
