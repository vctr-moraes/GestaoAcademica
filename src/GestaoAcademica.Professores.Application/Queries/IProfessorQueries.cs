using GestaoAcademica.Professores.Application.Queries.Dtos;

namespace GestaoAcademica.Professores.Application.Queries
{
    public interface IProfessorQueries
    {
        Task<ProfessorDetailsDto> ObterProfessor(Guid idProfessor);
        Task<IEnumerable<ProfessorDetailsDto>> ObterProfessores();
    }
}
