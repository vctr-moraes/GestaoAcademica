using GestaoAcademica.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace GestaoAcademica.Professores.Application.Dtos
{
    public class ProfessorCreateEditDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Endereco Endereco { get; set; }
    }
}
