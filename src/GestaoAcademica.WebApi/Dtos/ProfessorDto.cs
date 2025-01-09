using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.WebApi.Dtos
{
    public class ProfessorDto
    {
        public string Nome { get; set; }
        public string NumeroDocumento { get; set; }
        public DateOnly DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
    }
}
    