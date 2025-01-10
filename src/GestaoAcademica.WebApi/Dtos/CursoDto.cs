namespace GestaoAcademica.WebApi.Dtos
{
    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CargaHoraria { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Grau { get; set; }
        public int Modalidade { get; set; }
    }
}
