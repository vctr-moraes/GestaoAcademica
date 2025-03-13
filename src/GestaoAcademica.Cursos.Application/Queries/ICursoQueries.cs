using GestaoAcademica.Cursos.Application.Queries.Dtos;

namespace GestaoAcademica.Cursos.Application.Queries
{
    public interface ICursoQueries
    {
        Task<CursoDetailsDto> ObterCursoPorId(Guid idCurso);
        Task<IEnumerable<CursosDisciplinasDetailsDto>> ObterCursosDisciplinas();
        Task<IEnumerable<CursoDetailsDto>> ObterCursos();
    }
}
