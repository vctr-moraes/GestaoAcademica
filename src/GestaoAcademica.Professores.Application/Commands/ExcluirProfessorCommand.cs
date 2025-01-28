using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Professores.Application.Commands
{
    public class ExcluirProfessorCommand : Command
    {
        public Guid IdProfessor { get; private set; }

        public ExcluirProfessorCommand(Guid idProfessor)
        {
            IdProfessor = idProfessor;
        }
    }
}
