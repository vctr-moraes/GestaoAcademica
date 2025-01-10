using GestaoAcademica.Alunos.Application.Commands;
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

        public AlunoController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
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
    }
}
