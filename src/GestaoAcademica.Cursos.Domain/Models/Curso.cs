using GestaoAcademica.Core.DomainObjects;

namespace GestaoAcademica.Cursos.Domain.Models
{
    public class Curso : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CargaHoraria { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Grau Grau { get; private set; }
        public Modalidade Modalidade { get; private set; }
        public Guid IdProfessorCoordenador { get; private set; }
        public string NomeProfessorCoordenador { get; private set; }

        private readonly List<CursosDisciplinas> _cursosDisciplinas;
        public IReadOnlyCollection<CursosDisciplinas> CursosDisciplinas => _cursosDisciplinas;

        protected Curso()
        {
            _cursosDisciplinas = new List<CursosDisciplinas>();
        }

        public Curso(
            string nome,
            string descricao,
            string cargaHoraria,
            DateTime dataCriacao,
            Grau grau,
            Modalidade modalidade)
        {
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            DataCriacao = dataCriacao;
            Grau = grau;
            Modalidade = modalidade;
            _cursosDisciplinas = new List<CursosDisciplinas>();

            Validar();
        }

        public void VincularDisciplina(Curso curso, Disciplina disciplina)
        {
            _cursosDisciplinas.Add(new CursosDisciplinas(this, disciplina));
        }

        public void AtribuirProfessorCoordenador(Guid idProfessor, string nomeProfessor)
        {
            IdProfessorCoordenador = idProfessor;
            NomeProfessorCoordenador = nomeProfessor;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(Descricao, "O campo descrição não pode estar vazio.");
            Validacoes.ValidarSeVazio(CargaHoraria, "O campo carga horária não pode estar vazio.");
            Validacoes.ValidarSeNulo(DataCriacao, "O campo data criação não pode estar vazio.");
            Validacoes.ValidarSeNulo(Grau, "O campo grau não pode estar vazio.");
            Validacoes.ValidarSeNulo(Modalidade, "O campo modalidade não pode estar vazio.");
        }
    }
}
