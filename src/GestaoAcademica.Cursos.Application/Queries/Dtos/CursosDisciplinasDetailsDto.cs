namespace GestaoAcademica.Cursos.Application.Queries.Dtos
{
    public class CursosDisciplinasDetailsDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CargaHoraria { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? Grau { get; set; }
        public string? Modalidade { get; set; }
        public string? NomeProfessorCoordenador { get; set; }
        public List<DisciplinaDetailsDto>? Disciplinas { get; set; } = new List<DisciplinaDetailsDto>();
    }

    public class DisciplinaDetailsDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? CargaHoraria { get; set; }
        public string? NomeProfessor { get; set; }
    }
}
