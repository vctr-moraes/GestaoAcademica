using GestaoAcademica.Alunos.Application.Commands;
using GestaoAcademica.Alunos.Application.Queries;
using GestaoAcademica.Alunos.Application.Queries.Dtos;
using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAlunoQueries _alunoQueries;

        public AlunoController(IMediatorHandler mediatorHandler, IAlunoQueries alunoQueries)
        {
            _mediatorHandler = mediatorHandler;
            _alunoQueries = alunoQueries;
        }

        [HttpGet]
        [Route("obter-alunos")]
        public async Task<IEnumerable<AlunoCadastradosDto>> ObterAlunos()
        {
            return await _alunoQueries.ObterAlunos();
        }

        [HttpPost]
        [Route("cadastrar-aluno")]
        public async Task CadastrarAluno(AlunoDto alunoDto)
        {
            var command = new CadastrarAlunoCommand(
                alunoDto.Nome,
                alunoDto.NumeroDocumento,
                alunoDto.DataNascimento,
                alunoDto.Endereco,
                alunoDto.NomePai,
                alunoDto.NomeMae);

            await _mediatorHandler.EnviarComando(command);
        }

        [HttpDelete]
        [Route("excluir-aluno")]
        public async Task ExcluirAluno(Guid idAluno)
        {
            var command = new ExcluirAlunoCommand(idAluno);
            await _mediatorHandler.EnviarComando(command);
        }
    }
}
