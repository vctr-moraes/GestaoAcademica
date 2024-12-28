using GestaoAcademica.Core.Data;
using GestaoAcademica.Professores.Domain.Interfaces;
using GestaoAcademica.Professores.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Professores.Data.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ProfessorContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProfessorRepository(ProfessorContext context)
        {
            _context = context;
        }

        public void Adicionar(Professor professor)
        {
            _context.Professores.Add(professor);
        }

        public void Atualizar(Professor professor)
        {
            _context.Professores.Update(professor);
        }

        public void Excluir(Professor professor)
        {
            _context.Professores.Remove(professor);
        }

        public async Task<Professor> ObterPorId(Guid id)
        {
            return await _context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Professor>> ObterTodos()
        {
            return await _context.Professores.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
