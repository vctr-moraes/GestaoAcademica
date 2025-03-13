using System.ComponentModel.DataAnnotations;

namespace GestaoAcademica.Cursos.Application.Dtos
{
    public class CursoCreateEditDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CargaHoraria { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Grau { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Modalidade { get; set; }
    }
}
