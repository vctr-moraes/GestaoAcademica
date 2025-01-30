using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class ExcluirCursoCommand : Command
    {
        public Guid CursoId { get; private set; }

        public ExcluirCursoCommand(Guid cursoId)
        {
            CursoId = cursoId;
        }
    }
}
