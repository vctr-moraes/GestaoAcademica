using GestaoAcademica.Core.Data;
using GestaoAcademica.Turmas.Domain.Models;

namespace GestaoAcademica.Turmas.Domain.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<Turma> ObterPorId(Guid id);

        Task<IEnumerable<Turma>> ObterTodos();

        void Adicionar(Turma turma);

        void Atualizar(Turma turma);

        void Excluir(Turma turma);

        Task<AlunoCursante> ObterAlunoCursantePorId(Guid id);

        Task<IEnumerable<AlunoCursante>> ObterAlunosCursantesPorTurma(Guid idTurma);
    }
}
