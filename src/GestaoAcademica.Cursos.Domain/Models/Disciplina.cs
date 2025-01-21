using GestaoAcademica.Core.DomainObjects;

namespace GestaoAcademica.Cursos.Domain.Models
{
    public class Disciplina : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CargaHoraria { get; private set; }
        public CursosDisciplinas CursosDisciplinas { get; private set; }
        public Guid IdProfessor { get; private set; }
        public string NomeProfessor { get; private set; }

        protected Disciplina() { }

        public Disciplina(string nome, string descricao, string cargaHoraria)
        {
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;

            Validar();
        }

        public void AtribuirProfessor(Guid idProfessor, string nomeProfessor)
        {
            IdProfessor = idProfessor;
            NomeProfessor = nomeProfessor;
        }

        public void DesvincularProfessor(Guid idProfessor)
        {
            if (IdProfessor == idProfessor)
            {
                IdProfessor = Guid.Empty;
                NomeProfessor = string.Empty;
            }
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(Descricao, "O campo descrição não pode estar vazio.");
            Validacoes.ValidarSeVazio(CargaHoraria, "O campo carga horária não pode estar vazio.");
        }
    }
}
