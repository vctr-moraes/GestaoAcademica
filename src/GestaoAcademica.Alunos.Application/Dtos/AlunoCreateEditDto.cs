using GestaoAcademica.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace GestaoAcademica.WebApi.Dtos
{
    public class AlunoCreateEditDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string NomePai { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string NomeMae { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Endereco Endereco { get; set; }
    }
}
