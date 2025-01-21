using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class DesvincularProfessorCoordenadorCommand : Command
    {
        public Guid IdCurso { get; private set; }
        public Guid IdProfessor { get; private set; }

        public DesvincularProfessorCoordenadorCommand(Guid idCurso, Guid idProfessor)
        {
            IdCurso = idCurso;
            IdProfessor = idProfessor;
        }
    }
}
