using GestaoAcademica.Alunos.Domain.Interfaces;
using GestaoAcademica.Alunos.Domain.Models;
using GestaoAcademica.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Alunos.Data.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public AlunoRepository(AlunoContext context)
        {
            _context = context;
        }

        public void Adicionar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
        }

        public async Task<Aluno> ObterPorId(Guid id)
        {
            return await _context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
