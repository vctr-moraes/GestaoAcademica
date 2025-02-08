namespace GestaoAcademica.Cursos.Application.Queries.Dtos
{
    public class CursosDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CargaHoraria { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? Grau { get; set; }
        public string? Modalidade { get; set; }
        public string? NomeProfessorCoordenador { get; set; }
    }
}
