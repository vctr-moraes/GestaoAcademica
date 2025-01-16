using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class AtribuirProfessorCoordenadorCommand : Command
    {
        public Guid IdCurso { get; private set; }
        public Guid IdProfessor { get; private set; }
        public string NomeProfessor { get; private set; }

        public AtribuirProfessorCoordenadorCommand(Guid idCurso, Guid idProfessor, string nomeProfessor)
        {
            IdCurso = idCurso;
            IdProfessor = idProfessor;
            NomeProfessor = nomeProfessor;
        }
    }
}
