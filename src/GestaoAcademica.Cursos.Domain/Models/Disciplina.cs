using GestaoAcademica.Core.DomainObjects;

namespace GestaoAcademica.Cursos.Domain.Models
{
    public class Disciplina : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CargaHoraria { get; private set; }
        public string Professor { get; private set; }

        protected Disciplina() { }

        public Disciplina(string nome, string descricao, string cargaHoraria)
        {
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;

            Validar();
        }

        public void AtribuirProfessor(string professor)
        {
            // Posteriormente será utilizado o objeto Professor
            Professor = professor;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(Descricao, "O campo descrição não pode estar vazio.");
            Validacoes.ValidarSeVazio(CargaHoraria, "O campo carga horária não pode estar vazio.");
        }
    }
}
