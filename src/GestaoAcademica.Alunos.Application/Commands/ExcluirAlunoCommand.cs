using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Alunos.Application.Commands
{
    public class ExcluirAlunoCommand : Command
    {
        public Guid IdAluno { get; private set; }

        public ExcluirAlunoCommand(Guid idAluno)
        {
            IdAluno = idAluno;
        }
    }
}
