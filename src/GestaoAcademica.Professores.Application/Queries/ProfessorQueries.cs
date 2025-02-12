using GestaoAcademica.Professores.Application.Queries.Dtos;
using GestaoAcademica.Professores.Domain.Interfaces;

namespace GestaoAcademica.Professores.Application.Queries
{
    public class ProfessorQueries : IProfessorQueries
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorQueries(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<ProfessoresDto> ObterProfessor(Guid idProfessor)
        {
            var professor = await _professorRepository.ObterPorId(idProfessor);

            if (professor == null) return null;

            return new ProfessoresDto
            {
                Id = professor.Id,
                Nome = professor.Nome,
                DataNascimento = professor.DataNascimento,
                NumeroDocumento = professor.NumeroDocumento
            };
        }

        public async Task<IEnumerable<ProfessoresDto>> ObterProfessores()
        {
            var professores = await _professorRepository.ObterTodos();

            if (professores == null) return null;

            return professores.Select(p => new ProfessoresDto
            {
                Id = p.Id,
                Nome = p.Nome,
                DataNascimento = p.DataNascimento,
                NumeroDocumento = p.NumeroDocumento
            });
        }
    }
}
