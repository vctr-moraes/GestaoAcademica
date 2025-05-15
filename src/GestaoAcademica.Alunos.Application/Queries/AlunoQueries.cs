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

        public async Task<AlunosDetailsDto> ObterAlunoPorId(Guid idAluno)
        {
            var aluno = await _alunoRepository.ObterPorId(idAluno);

            if (aluno == null) return null;

            return new AlunosDetailsDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Status = aluno.Status.ToString(),
                DataCadastro = aluno.DataCadastro,
                NumeroDocumento = aluno.NumeroDocumento,
                NomePai = aluno.NomePai,
                NomeMae = aluno.NomeMae,
                Endereco = new EnderecoAlunoDetailsDto
                {
                    Logradouro = aluno.Endereco.Logradouro,
                    Bairro = aluno.Endereco.Bairro,
                    Cidade = aluno.Endereco.Cidade,
                    Pais = aluno.Endereco.Pais,
                    Cep = aluno.Endereco.Cep,
                    Referencia = aluno.Endereco.Referencia
                }
            };
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
                NumeroDocumento = a.NumeroDocumento,
                NomePai = a.NomePai,
                NomeMae = a.NomeMae,
                Endereco = new EnderecoAlunoDetailsDto
                {
                    Logradouro = a.Endereco.Logradouro,
                    Bairro = a.Endereco.Bairro,
                    Cidade = a.Endereco.Cidade,
                    Pais = a.Endereco.Pais,
                    Cep = a.Endereco.Cep,
                    Referencia = a.Endereco.Referencia
                }
            });
        }
    }
}
