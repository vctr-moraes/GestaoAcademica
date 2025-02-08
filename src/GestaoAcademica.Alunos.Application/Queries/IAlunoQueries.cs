using GestaoAcademica.Alunos.Application.Queries.Dtos;

namespace GestaoAcademica.Alunos.Application.Queries
{
    public interface IAlunoQueries
    {
        Task<IEnumerable<AlunoCadastradosDto>> ObterAlunos();
    }
}
