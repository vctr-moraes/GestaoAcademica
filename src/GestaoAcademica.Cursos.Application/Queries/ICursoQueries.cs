using GestaoAcademica.Cursos.Application.Queries.Dtos;

namespace GestaoAcademica.Cursos.Application.Queries
{
    public interface ICursoQueries
    {
        Task<CursosDto> ObterCursoPorId(Guid idCurso);
        Task<IEnumerable<CursosDisciplinasDto>> ObterCursosDisciplinas();
        Task<IEnumerable<CursosDto>> ObterCursos();
    }
}
