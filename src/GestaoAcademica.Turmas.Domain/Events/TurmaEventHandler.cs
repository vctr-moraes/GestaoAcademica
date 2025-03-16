using MediatR;

namespace GestaoAcademica.Turmas.Domain.Events
{
    public class TurmaEventHandler : INotificationHandler<NovoAlunoMatriculadoEvent>
    {
        public async Task Handle(NovoAlunoMatriculadoEvent message, CancellationToken cancellationToken)
        {
            // Notificar por e-mail professor coordenador, sobre novo aluno matriculado.
            await Task.Run(() => Console.WriteLine($"Aluno {message.NomeAluno} matriculado na turma de {message.Curso}"));
        }
    }
}
