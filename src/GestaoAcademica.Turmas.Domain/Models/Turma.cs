using GestaoAcademica.Core.DomainObjects;

namespace GestaoAcademica.Turmas.Domain.Models
{
    public class Turma : Entity, IAggregateRoot
    {
        public DateTime DataInicio { get; private set; }
        public DateTime DataEncerramento { get; private set; }
        public StatusTurma StatusTurma { get; private set; }
        public Guid IdCurso { get; private set; }
        public string NomeCurso { get; private set; }

        private readonly List<AlunoCursante> _alunos;
        public IReadOnlyCollection<AlunoCursante> Alunos => _alunos;

        protected Turma() { }

        public Turma(DateTime dataInicio, Guid idCurso, string nomeCurso)
        {
            DataInicio = dataInicio;
            IdCurso = idCurso;
            NomeCurso = nomeCurso;
            StatusTurma = StatusTurma.Aberta;

            Validar();
        }

        public void MatricularAluno(AlunoCursante alunoCursante)
        {
            _alunos.Add(alunoCursante);
        }

        public void TrancarMatriculaAluno(Guid idAluno)
        {
            var alunoCursante = _alunos.FirstOrDefault(x => x.IdAluno == idAluno);

            if (alunoCursante == null)
            {
                throw new Exception("Aluno inexistente.");
            }

            _alunos.Remove(alunoCursante);
        }

        public void Validar()
        {
            Validacoes.ValidarSeNulo(DataInicio, "O campo data início não pode estar vazio.");
            Validacoes.ValidarSeNulo(IdCurso, "O campo id do curso não pode estar vazio.");
            Validacoes.ValidarSeVazio(NomeCurso, "O campo nome do curso não pode estar vazio.");
        }
    }
}
