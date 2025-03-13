using GestaoAcademica.Turmas.Application.Queries.Dtos;

namespace GestaoAcademica.Turmas.Application.Queries
{
    public interface ITurmaQueries
    {
        Task<TurmaAlunosDetailsDto> ObterTurmaPorId(Guid idTurma);
    }
}
