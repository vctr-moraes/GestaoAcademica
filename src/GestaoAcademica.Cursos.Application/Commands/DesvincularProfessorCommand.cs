using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class DesvincularProfessorCommand : Command
    {
        public Guid IdDisciplina { get; private set; }
        public Guid IdProfessor { get; private set; }

        public DesvincularProfessorCommand(Guid idDisciplina, Guid idProfessor)
        {
            IdDisciplina = idDisciplina;
            IdProfessor = idProfessor;
        }
    }
}
