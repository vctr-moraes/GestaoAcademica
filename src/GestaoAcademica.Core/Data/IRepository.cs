using GestaoAcademica.Core.DomainObjects;

namespace GestaoAcademica.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
