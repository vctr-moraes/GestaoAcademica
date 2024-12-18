namespace GestaoAcademica.Alunos.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task<bool> MatricularAluno(Guid alunoId, Guid cursoId);
    }
}
