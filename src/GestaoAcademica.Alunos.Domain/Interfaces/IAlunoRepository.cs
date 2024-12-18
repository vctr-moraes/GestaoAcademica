using GestaoAcademica.Alunos.Domain.Models;
using GestaoAcademica.Core.Data;

namespace GestaoAcademica.Alunos.Domain.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterPorId(Guid id);

        Task<IEnumerable<Aluno>> ObterTodos();

        void Adicionar(Aluno aluno);

        void Atualizar(Aluno aluno);
    }
}
