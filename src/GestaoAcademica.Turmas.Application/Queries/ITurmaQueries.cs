using GestaoAcademica.Turmas.Application.Queries.Dtos;

namespace GestaoAcademica.Turmas.Application.Queries
{
    public interface ITurmaQueries
    {
        Task<TurmaAlunosDto> ObterTurmaPorId(Guid idTurma);
    }
}
