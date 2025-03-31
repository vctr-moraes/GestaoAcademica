using GestaoAcademica.Core.Data;
using GestaoAcademica.Cursos.Domain.Models;

namespace GestaoAcademica.Cursos.Domain.Interfaces
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<Curso> ObterPorId(Guid id);

        Task<IEnumerable<Curso>> ObterTodos();

        Task<IEnumerable<Curso>> ObterCursosDisciplinas();

        void Adicionar(Curso curso);

        void Atualizar(Curso curso);

        void Excluir(Curso curso);

        Task<Disciplina> ObterDisciplinaPorId(Guid id);

        Task<List<Disciplina>> ObterDisciplinasPorCurso(Guid id);

        void AdicionarDisciplina(Disciplina disciplina);

        void AtualizarDisciplina(Disciplina disciplina);

        void ExcluirDisciplina(Disciplina disciplina);

        void RemoverDisciplinaCurso(Guid cursoId, Guid disciplinaId);

        Task<CursosDisciplinas> ObterCursoDisciplina(Guid cursoId, Guid disciplinaId);

        void AdicionarCursoDisciplina(CursosDisciplinas cursosDisciplinas);

        void RemoverCursoDisciplina(CursosDisciplinas cursosDisciplinas);
    }
}
