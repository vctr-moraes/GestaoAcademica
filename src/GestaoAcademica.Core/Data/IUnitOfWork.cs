namespace GestaoAcademica.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
