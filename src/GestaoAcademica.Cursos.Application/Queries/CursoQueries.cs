using GestaoAcademica.Cursos.Application.Queries.Dtos;
using GestaoAcademica.Cursos.Domain.Interfaces;

namespace GestaoAcademica.Cursos.Application.Queries
{
    public class CursoQueries : ICursoQueries
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoQueries(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<CursoDetailsDto> ObterCursoPorId(Guid idCurso)
        {
            var curso = await _cursoRepository.ObterPorId(idCurso);

            if (curso == null) return null;

            return new CursoDetailsDto
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                CargaHoraria = curso.CargaHoraria,
                DataCriacao = curso.DataCriacao,
                Grau = curso.Grau.ToString(),
                Modalidade = curso.Modalidade.ToString(),
                NomeProfessorCoordenador = curso.NomeProfessorCoordenador
            };
        }

        public async Task<IEnumerable<CursoDetailsDto>> ObterCursos()
        {
            var cursos = await _cursoRepository.ObterTodos();

            if (cursos == null) return null;

            return cursos.Select(x => new CursoDetailsDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                CargaHoraria = x.CargaHoraria,
                DataCriacao = x.DataCriacao,
                Grau = x.Grau.ToString(),
                Modalidade = x.Modalidade.ToString(),
                NomeProfessorCoordenador = x.NomeProfessorCoordenador
            });
        }

        public async Task<IEnumerable<CursosDisciplinasDetailsDto>> ObterCursosDisciplinas()
        {
            var cursos = await _cursoRepository.ObterCursosDisciplinas();

            if (cursos == null) return null;

            return cursos.Select(x => new CursosDisciplinasDetailsDto
            {
                Id = x.Id,
                Nome = x.Nome,
                CargaHoraria = x.CargaHoraria,
                DataCriacao = x.DataCriacao,
                Grau = x.Grau.ToString(),
                Modalidade = x.Modalidade.ToString(),
                NomeProfessorCoordenador = x.NomeProfessorCoordenador,
                Disciplinas = x.CursosDisciplinas.Select(d => new DisciplinaDetailsDto
                {
                    Id = d.Disciplina.Id,
                    Nome = d.Disciplina.Nome,
                    Descricao = d.Disciplina.Descricao,
                    CargaHoraria = d.Disciplina.CargaHoraria,
                    NomeProfessor = d.Disciplina.NomeProfessor
                }).ToList()
            });
        }

        public async Task<DisciplinaDetailsDto> ObterDisciplinaPorId(Guid idDisciplina)
        {
            var disciplina = await _cursoRepository.ObterDisciplinaPorId(idDisciplina);

            if (disciplina == null) return null;

            return new DisciplinaDetailsDto
            {
                Id = disciplina.Id,
                Nome = disciplina.Nome,
                Descricao = disciplina.Descricao,
                CargaHoraria = disciplina.CargaHoraria,
                NomeProfessor = disciplina.NomeProfessor
            };
        }
    }
}
