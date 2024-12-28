using GestaoAcademica.Core.DomainObjects;
using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.Professores.Domain.Models
{
    public class Professor : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Endereco Endereco { get; private set; }
        public Status Status { get; private set; }

        protected Professor() { }

        public Professor(
            string nome,
            string numeroDocumento,
            DateTime dataNascimento,
            Endereco endereco)
        {
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Endereco = endereco;
            Status = TornarAtivo();

            Validar();
        }

        public Status TornarAtivo() => Status = Status.Ativo;

        public Status TornarInativo() => Status = Status.Inativo;

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(NumeroDocumento, "O campo número do documento não pode estar vazio.");
            Validacoes.ValidarSeNulo(DataNascimento, "O campo data de nascimento não pode estar vazio.");
        }
    }
}
