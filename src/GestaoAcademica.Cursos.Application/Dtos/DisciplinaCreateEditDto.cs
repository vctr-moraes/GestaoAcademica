using System.ComponentModel.DataAnnotations;

namespace GestaoAcademica.Cursos.Application.Dtos
{
    public class DisciplinaCreateEditDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CargaHoraria { get; set; }
    }
}
