using GestaoAcademica.Turmas.Domain.Interfaces;

namespace GestaoAcademica.Turmas.Domain.Services
{
    public class TurmaService : ITurmaService
    {
        public Task<bool> MatricularAluno(Guid idTurma, Guid idCurso, string nomeCurso, Guid idAluno, string nomeAluno)
        {
            throw new NotImplementedException();
        }
    }
}
