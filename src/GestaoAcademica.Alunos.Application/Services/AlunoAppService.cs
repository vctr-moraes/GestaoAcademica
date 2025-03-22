using GestaoAcademica.Alunos.Application.Interfaces;
using GestaoAcademica.Alunos.Domain.Interfaces;

namespace GestaoAcademica.Alunos.Application.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoAppService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }
    }
}
