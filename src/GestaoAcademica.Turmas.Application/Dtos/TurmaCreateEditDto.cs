using System.ComponentModel.DataAnnotations;

namespace GestaoAcademica.Turmas.Application.Dtos
{
    public class TurmaCreateEditDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid IdCurso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string NomeCurso { get; set; }
    }
}
