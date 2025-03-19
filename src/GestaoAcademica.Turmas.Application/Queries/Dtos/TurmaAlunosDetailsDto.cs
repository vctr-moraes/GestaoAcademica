using GestaoAcademica.Turmas.Domain.Models;

namespace GestaoAcademica.Turmas.Application.Queries.Dtos
{
    public class TurmaAlunosDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataEncerramento { get; set; }
        public StatusTurma StatusTurma { get; set; }
        public string? NomeCurso { get; set; }
        public List<AlunoCursanteDetailsDto>? Alunos { get; set; } = new List<AlunoCursanteDetailsDto>();
    }

    public class AlunoCursanteDetailsDto
    {
        public Guid IdAluno { get; set; }
        public string? NomeAluno { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public MotivoSaida MotivoSaida { get; set; }
        public StatusAluno StatusAluno { get; set; }
    }
}
