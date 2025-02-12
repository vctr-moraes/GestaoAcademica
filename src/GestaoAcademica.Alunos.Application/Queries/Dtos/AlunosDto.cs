namespace GestaoAcademica.Alunos.Application.Queries.Dtos
{
    public class AlunosDto
    {
        public string? Nome { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Status { get; set; }
        public DateOnly DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
