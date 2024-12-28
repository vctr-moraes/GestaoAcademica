using GestaoAcademica.Core.Data;
using GestaoAcademica.Professores.Domain.Models;

namespace GestaoAcademica.Professores.Domain.Interfaces
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<Professor> ObterPorId(Guid id);

        Task<IEnumerable<Professor>> ObterTodos();

        void Adicionar(Professor professor);

        void Atualizar(Professor professor);

        void Excluir(Professor professor);
    }
}
