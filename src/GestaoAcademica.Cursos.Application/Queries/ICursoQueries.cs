using GestaoAcademica.Cursos.Application.Queries.Dtos;

namespace GestaoAcademica.Cursos.Application.Queries
{
    public interface ICursoQueries
    {
        Task<CursoDetailsDto> ObterCursoPorId(Guid idCurso);
        Task<DisciplinaDetailsDto> ObterDisciplinaPorId(Guid idDisciplina);
        Task<IEnumerable<CursosDisciplinasDetailsDto>> ObterCursosDisciplinas();
        Task<IEnumerable<CursoDetailsDto>> ObterCursos();
    }
}
