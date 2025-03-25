namespace GestaoAcademica.Core.Messages.CommonMessages.IntegrationEvents
{
    public class AtualizarStatusNovoAlunoMatriculadoEvent : IntegrationEvent
    {
        public Guid IdAluno { get; private set; }

        public AtualizarStatusNovoAlunoMatriculadoEvent(Guid idAluno)
        {
            AggregateId = idAluno;
            IdAluno = idAluno;
        }
    }
}
