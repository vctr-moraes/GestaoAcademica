using GestaoAcademica.Core.Messages.CommonMessages.DomainEvents;

namespace GestaoAcademica.Turmas.Domain.Events
{
    public class NovoAlunoMatriculadoEvent : DomainEvent
    {
        public NovoAlunoMatriculadoEvent(
            Guid aggregateId,
            string nomeAluno,
            string curso) : base(aggregateId)
        {
            NomeAluno = nomeAluno;
            Curso = curso;
        }

        public string NomeAluno { get; private set; }
        public string Curso { get; private set; }
    }
}
