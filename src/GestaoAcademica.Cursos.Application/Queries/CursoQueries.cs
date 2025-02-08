using GestaoAcademica.Cursos.Application.Queries.Dtos;
using GestaoAcademica.Cursos.Domain.Interfaces;
using GestaoAcademica.Cursos.Domain.Models;

namespace GestaoAcademica.Cursos.Application.Queries
{
    public class CursoQueries : ICursoQueries
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoQueries(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<CursosDto> ObterCursoPorId(Guid idCurso)
        {
            var curso = await _cursoRepository.ObterPorId(idCurso);

            if (curso == null) return null;

            return new CursosDto
            {
                Id = curso.Id,
                Nome = curso.Nome,
                CargaHoraria = curso.CargaHoraria,
                DataCriacao = curso.DataCriacao,
                Grau = curso.Grau.ToString(),
                Modalidade = curso.Modalidade.ToString(),
                NomeProfessorCoordenador = curso.NomeProfessorCoordenador
            };
        }

        public async Task<IEnumerable<CursosDto>> ObterCursos()
        {
            var cursos = await _cursoRepository.ObterTodos();

            if (cursos == null) return null;

            return cursos.Select(x => new CursosDto
            {
                Id = x.Id,
                Nome = x.Nome,
                CargaHoraria = x.CargaHoraria,
                DataCriacao = x.DataCriacao,
                Grau = x.Grau.ToString(),
                Modalidade = x.Modalidade.ToString(),
                NomeProfessorCoordenador = x.NomeProfessorCoordenador
            });
        }

        public async Task<IEnumerable<CursosDisciplinasDto>> ObterCursosDisciplinas()
        {
            var cursos = await _cursoRepository.ObterCursosDisciplinas();

            if (cursos == null) return null;

            return cursos.Select(x => new CursosDisciplinasDto
            {
                Id = x.Id,
                Nome = x.Nome,
                CargaHoraria = x.CargaHoraria,
                DataCriacao = x.DataCriacao,
                Grau = x.Grau.ToString(),
                Modalidade = x.Modalidade.ToString(),
                NomeProfessorCoordenador = x.NomeProfessorCoordenador,
                Disciplinas = x.CursosDisciplinas.Select(d => new DisciplinaDto
                {
                    Id = d.Disciplina.Id,
                    Nome = d.Disciplina.Nome,
                    CargaHoraria = d.Disciplina.CargaHoraria,
                    NomeProfessor = d.Disciplina.NomeProfessor
                }).ToList()
            });
        }
    }
}
