namespace GestaoAcademica.Professores.Application.Queries.Dtos
{
    public class ProfessorDetailsDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateOnly DataNascimento { get; set; }
        public EnderecoProfessorDetailsDto? Endereco { get; set; }
    }

    public class EnderecoProfessorDetailsDto
    {
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Pais { get; set; }
        public string? Cep { get; set; }
        public string? Referencia { get; set; }
    }
}
