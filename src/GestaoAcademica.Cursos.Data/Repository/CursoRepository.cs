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

        public void Excluir(Curso curso)
        {
            _context.Remove(curso);
        }

        public async Task<Curso> ObterPorId(Guid id)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(x => x.Id == id);

            if (curso == null) return null;

            await _context.Entry(curso).Collection(x => x.CursosDisciplinas).LoadAsync();

            return curso;
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

        public void ExcluirDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Remove(disciplina);
        }

        public void RemoverDisciplinaCurso(Guid cursoId, Guid disciplinaId)
        {
            throw new NotImplementedException();
        }

        public async Task<Disciplina> ObterDisciplinaPorId(Guid id)
        {
            return await _context.Disciplinas.Include(x => x.CursosDisciplinas.Curso).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Disciplina>> ObterDisciplinasPorCurso(Guid id)
        {
            return await _context.Disciplinas
                .AsNoTracking()
                .Where(x => x.CursosDisciplinas.CursoId == id)
                .ToListAsync();
        }

        public void AdicionarCursoDisciplina(CursosDisciplinas cursosDisciplinas)
        {
            _context.CursosDisciplinas.Add(cursosDisciplinas);
        }

        public async Task<CursosDisciplinas> ObterCursoDisciplina(Guid cursoId, Guid disciplinaId)
        {
            return await _context.CursosDisciplinas
                .Include(x => x.Curso)
                .Include(x => x.Disciplina)
                .FirstOrDefaultAsync(x => x.CursoId == cursoId && x.DisciplinaId == disciplinaId);
        }

        public void RemoverCursoDisciplina(CursosDisciplinas cursosDisciplinas)
        {
            _context.CursosDisciplinas.Remove(cursosDisciplinas);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
