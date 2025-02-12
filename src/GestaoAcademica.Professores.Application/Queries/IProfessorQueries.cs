using GestaoAcademica.Professores.Application.Queries.Dtos;

namespace GestaoAcademica.Professores.Application.Queries
{
    public interface IProfessorQueries
    {
        Task<ProfessoresDto> ObterProfessor(Guid idProfessor);
        Task<IEnumerable<ProfessoresDto>> ObterProfessores();
    }
}
