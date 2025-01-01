using GestaoAcademica.Core.Data;
using GestaoAcademica.Turmas.Domain.Interfaces;
using GestaoAcademica.Turmas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Turmas.Data.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly TurmaContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public TurmaRepository(TurmaContext context)
        {
            _context = context;
        }

        public void Adicionar(Turma turma)
        {
            _context.Turmas.Add(turma);
        }

        public void Atualizar(Turma turma)
        {
            _context.Turmas.Update(turma);
        }

        public void Excluir(Turma turma)
        {
            _context.Turmas.Remove(turma);
        }

        public async Task<Turma> ObterPorId(Guid id)
        {
            return await _context.Turmas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Turma>> ObterTodos()
        {
            return await _context.Turmas.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
