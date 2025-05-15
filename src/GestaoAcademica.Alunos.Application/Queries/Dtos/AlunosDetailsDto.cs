namespace GestaoAcademica.Alunos.Application.Queries.Dtos
{
    public class AlunosDetailsDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Status { get; set; }
        public DateOnly DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? NomePai { get; set; }
        public string? NomeMae { get; set; }
        public EnderecoAlunoDetailsDto? Endereco { get; set; }
    }

    public class EnderecoAlunoDetailsDto
    {
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Pais { get; set; }
        public string? Cep { get; set; }
        public string? Referencia { get; set; }
    }
}
