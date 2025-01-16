using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class AtribuirProfessorCommand : Command
    {
        public Guid IdDisciplina { get; private set; }
        public Guid IdProfessor { get; private set; }
        public string NomeProfessor { get; private set; }

        public AtribuirProfessorCommand(Guid idDisciplina, Guid idProfessor, string nomeProfessor)
        {
            IdDisciplina = idDisciplina;
            IdProfessor = idProfessor;
            NomeProfessor = nomeProfessor;
        }
    }
}
