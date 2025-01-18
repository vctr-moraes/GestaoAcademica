namespace GestaoAcademica.WebApi.Dtos
{
    public class TurmaDto
    {
        public DateTime DataInicio { get; set; }
        public Guid IdCurso { get; set; }
        public string NomeCurso { get; set; }
    }
}
