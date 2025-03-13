using GestaoAcademica.Alunos.Application.Queries.Dtos;
using GestaoAcademica.Alunos.Domain.Interfaces;

namespace GestaoAcademica.Alunos.Application.Queries
{
    public class AlunoQueries : IAlunoQueries
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoQueries(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<AlunosDetailsDto>> ObterAlunos()
        {
            var alunos = await _alunoRepository.ObterTodos();

            if (alunos == null) return null;

            return alunos.Select(a => new AlunosDetailsDto
            {
                Id = a.Id,
                Nome = a.Nome,
                DataNascimento = a.DataNascimento,
                Status = a.Status.ToString(),
                DataCadastro = a.DataCadastro,
                NumeroDocumento = a.NumeroDocumento
            });
        }
    }
}
