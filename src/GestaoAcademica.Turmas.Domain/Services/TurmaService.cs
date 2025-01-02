using GestaoAcademica.Turmas.Domain.Interfaces;

namespace GestaoAcademica.Turmas.Domain.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<bool> MatricularAluno(Guid idTurma, Guid idAluno, string nomeAluno)
        {
            if (!await ValidarAlunoCursanteExistente(idAluno)) return false;

            var turma = await _turmaRepository.ObterPorId(idTurma);
            turma.VincularAluno(idAluno, nomeAluno);

            _turmaRepository.Atualizar(turma);
            return await _turmaRepository.UnitOfWork.Commit();
        }

        private async Task<bool> ValidarAlunoCursanteExistente(Guid idAluno)
        {
            var alunoCursante = await _turmaRepository.ObterAlunoCursantePorId(idAluno);
            return alunoCursante == null;
        }
    }
}
