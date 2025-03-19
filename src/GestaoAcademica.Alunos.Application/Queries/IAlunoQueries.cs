using GestaoAcademica.Alunos.Application.Queries.Dtos;

namespace GestaoAcademica.Alunos.Application.Queries
{
    public interface IAlunoQueries
    {
        Task<AlunosDetailsDto> ObterAlunoPorId(Guid idAluno);
        Task<IEnumerable<AlunosDetailsDto>> ObterAlunos();
    }
}
