namespace GestaoAcademica.Turmas.Domain.Interfaces
{
    public interface ITurmaService
    {
        Task<bool> MatricularAluno(Guid idTurma, Guid idCurso, string nomeCurso, Guid idAluno, string nomeAluno);
    }
}
