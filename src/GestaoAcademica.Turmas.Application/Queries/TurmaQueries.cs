using GestaoAcademica.Turmas.Application.Queries.Dtos;
using GestaoAcademica.Turmas.Domain.Interfaces;

namespace GestaoAcademica.Turmas.Application.Queries
{
    public class TurmaQueries : ITurmaQueries
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaQueries(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<TurmaAlunosDetailsDto> ObterTurmaPorId(Guid idTurma)
        {
            var turma = await _turmaRepository.ObterPorId(idTurma);

            if (turma == null) return null;

            var turmaDto = new TurmaAlunosDetailsDto
            {
                Id = turma.Id,
                DataInicio = turma.DataInicio,
                DataEncerramento = turma.DataEncerramento,
                StatusTurma = turma.StatusTurma,
                NomeCurso = turma.NomeCurso,
                Alunos = turma.Alunos.Select(a => new AlunoCursanteDetailsDto
                {
                    IdAluno = a.Id,
                    NomeAluno = a.NomeAluno,
                    DataEntrada = a.DataEntrada,
                    DataSaida = a.DataSaida,
                    MotivoSaida = a.MotivoSaida,
                    StatusAluno = a.StatusAluno
                }).ToList()
            };

            return turmaDto;
        }

        public async Task<List<TurmaAlunosDetailsDto>> ObterTurmas()
        {
            var turmas = await _turmaRepository.ObterTodos();

            if (!turmas.Any()) return null;

            return turmas.Select(x => new TurmaAlunosDetailsDto
            {
                Id = x.Id,
                DataInicio = x.DataInicio,
                DataEncerramento = x.DataEncerramento,
                StatusTurma = x.StatusTurma,
                NomeCurso = x.NomeCurso,
                Alunos = x.Alunos.Select(a => new AlunoCursanteDetailsDto
                {
                    IdAluno = a.Id,
                    NomeAluno = a.NomeAluno,
                    DataEntrada = a.DataEntrada,
                    DataSaida = a.DataSaida,
                    MotivoSaida = a.MotivoSaida,
                    StatusAluno = a.StatusAluno
                }).ToList()
            }).ToList();
        }
    }
}
