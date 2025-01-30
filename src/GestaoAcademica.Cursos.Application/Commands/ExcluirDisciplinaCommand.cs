using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class ExcluirDisciplinaCommand : Command
    {
        public Guid DisciplinaId { get; private set; }

        public ExcluirDisciplinaCommand(Guid disciplinaId)
        {
            DisciplinaId = disciplinaId;
        }
    }
}
