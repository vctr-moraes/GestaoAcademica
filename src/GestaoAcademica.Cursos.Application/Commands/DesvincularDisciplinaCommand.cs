using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class DesvincularDisciplinaCommand : Command
    {
        public DesvincularDisciplinaCommand(Guid cursoId, Guid disciplinaId)
        {
            CursoId = cursoId;
            DisciplinaId = disciplinaId;
        }

        public Guid CursoId { get; private set; }
        public Guid DisciplinaId { get; private set; }
    }
}
