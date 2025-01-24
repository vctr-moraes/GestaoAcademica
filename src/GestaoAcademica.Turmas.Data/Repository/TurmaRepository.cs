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
            return await _context.Turmas.Include(x => x.Alunos).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Turma>> ObterTodos()
        {
            return await _context.Turmas.AsNoTracking().ToListAsync();
        }

        public async Task<AlunoCursante> ObterAlunoCursantePorId(Guid id)
        {
            return await _context.AlunosCursantes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AlunoCursante>> ObterAlunosCursantesPorTurma(Guid idTurma)
        {
            return await _context.AlunosCursantes
                .AsNoTracking()
                .Where(x => x.IdTurma == idTurma)
                .ToListAsync();
        }

        public void AdicionarAlunoCursante(AlunoCursante alunoCursante)
        {
            _context.AlunosCursantes.Add(alunoCursante);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
