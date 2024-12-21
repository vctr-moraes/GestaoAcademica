using GestaoAcademica.Core.DomainObjects;

namespace GestaoAcademica.Cursos.Domain.Models
{
    public class CursosDisciplinas : Entity
    {
        public Guid CursoId { get; private set; }
        public Guid DisciplinaId { get; private set; }
        public Curso Curso { get; private set; }
        public Disciplina Disciplina { get; private set; }

        protected CursosDisciplinas() { }

        public CursosDisciplinas(Curso curso, Disciplina disciplina)
        {
            Curso = curso;
            CursoId = curso.Id;
            Disciplina = disciplina;
            DisciplinaId = disciplina.Id;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeNulo(Curso, "É necessário informar o curso.");
            Validacoes.ValidarSeNulo(Disciplina, "É necessário informar a disciplina.");
        }
    }
}
