using GestaoAcademica.Core.Data;
using GestaoAcademica.Cursos.Domain.Interfaces;
using GestaoAcademica.Cursos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Cursos.Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CursoRepository(CursoContext context)
        {
            _context = context;
        }

        public void Adicionar(Curso curso)
        {
            _context.Cursos.Add(curso);
        }

        public void Atualizar(Curso curso)
        {
            _context.Cursos.Update(curso);
        }

        public async Task<Curso> ObterPorId(Guid id)
        {
            return await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Curso>> ObterTodos()
        {
            return await _context.Cursos.AsNoTracking().ToListAsync();
        }

        public void AdicionarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
        }

        public void AtualizarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
        }

        public void RemoverDisciplinaCurso(Guid cursoId, Guid disciplinaId)
        {
            throw new NotImplementedException();
        }

        public async Task<Disciplina> ObterDisciplinaPorId(Guid id)
        {
            return await _context.Disciplinas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Disciplina>> ObterDisciplinasPorCurso(Guid id)
        {
            return await _context.Disciplinas
                .AsNoTracking()
                .Where(x => x.CursosDisciplinas.CursoId == id).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
