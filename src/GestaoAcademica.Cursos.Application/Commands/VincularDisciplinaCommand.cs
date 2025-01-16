using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class VincularDisciplinaCommand : Command
    {
        public Guid CursoId { get; private set; }
        public Guid DisciplinaId { get; private set; }

        public VincularDisciplinaCommand(Guid cursoId, Guid disciplinaId)
        {
            CursoId = cursoId;
            DisciplinaId = disciplinaId;
        }
    }
}
