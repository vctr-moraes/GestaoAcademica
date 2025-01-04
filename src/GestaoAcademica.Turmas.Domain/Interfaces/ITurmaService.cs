namespace GestaoAcademica.Turmas.Domain.Interfaces
{
    public interface ITurmaService
    {
        Task<bool> MatricularAluno(Guid idTurma, Guid idAluno, string nomeAluno);
        Task<bool> TrancarMatriculaAluno(Guid idTurma, Guid idAluno);
    }
}
