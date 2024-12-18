using GestaoAcademica.Alunos.Domain.Interfaces;

namespace GestaoAcademica.Alunos.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        // matricular aluno em um curso
        // aprovar aluno em curso
        // trancar matricula aluno em curso
        // reprovar aluno em curso

        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Task<bool> MatricularAluno(Guid alunoId, Guid cursoId)
        {
            throw new NotImplementedException();
        }
    }
}
