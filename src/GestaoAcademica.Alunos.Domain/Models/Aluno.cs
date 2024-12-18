using GestaoAcademica.Core.DomainObjects;
using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.Alunos.Domain.Models
{
    public class Aluno : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Endereco Endereco { get; private set; }
        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }
        public Status Status { get; private set; }

        protected Aluno() { }

        public Aluno(
            string nome,
            string numeroDocumento,
            DateTime dataNascimento,
            Endereco endereco,
            string nomePai,
            string nomeMae)
        {
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Endereco = endereco;
            NomePai = nomePai;
            NomeMae = nomeMae;
            Status = TornarInativo(); // O aluno torna-se ativo, quando este é matriculado em algum curso.

            Validar();
        }

        public Status TornarAtivo() => Status = Status.Ativo;

        public Status TornarInativo() => Status = Status.Inativo;

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(NumeroDocumento, "O campo número do documento não pode estar vazio.");
            Validacoes.ValidarSeNulo(DataNascimento, "O campo data de nascimento não pode estar vazio.");
            Validacoes.ValidarSeVazio(NomePai, "O campo nome do pai não pode estar vazio.");
            Validacoes.ValidarSeVazio(NomeMae, "O campo nome da mãe não pode estar vazio.");
        }
    }
}
