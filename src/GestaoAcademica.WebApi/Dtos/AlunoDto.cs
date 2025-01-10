using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.WebApi.Dtos
{
    public class AlunoDto
    {
        public string Nome { get; set; }
        public string NumeroDocumento { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public Endereco Endereco { get; set; }
    }
}
