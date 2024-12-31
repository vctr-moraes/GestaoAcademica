using GestaoAcademica.Core.DomainObjects;

namespace GestaoAcademica.Turmas.Domain.Models
{
    public class AlunoCursante : Entity
    {
        public Guid IdAluno { get; private set; }
        public string NomeAluno { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime DataSaida { get; private set; }
        public MotivoSaida MotivoSaida { get; private set; }
        public Status Status { get; private set; }

        protected AlunoCursante() { }

        public AlunoCursante(Guid idAluno, string nomeAluno)
        {
            IdAluno = idAluno;
            NomeAluno = nomeAluno;
            DataEntrada = DateTime.Now;
            Status = Status.Ativo;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeNulo(IdAluno, "O campo id do aluno não pode estar vazio.");
            Validacoes.ValidarSeVazio(NomeAluno, "O campo nome do aluno não pode estar vazio.");
            Validacoes.ValidarSeNulo(DataEntrada, "O campo data de entrada não pode estar vazio.");
        }
    }
}
