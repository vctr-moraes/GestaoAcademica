using GestaoAcademica.Alunos.Application.Commands;
using GestaoAcademica.Alunos.Application.Queries;
using GestaoAcademica.Alunos.Application.Queries.Dtos;
using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.WebApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAlunoQueries _alunoQueries;

        public AlunoController(
            IMediatorHandler mediatorHandler,
            IAlunoQueries alunoQueries,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _alunoQueries = alunoQueries;
        }

        [HttpGet]
        [Route("obter-aluno")]
        public async Task<ActionResult<AlunosDetailsDto>> ObterAluno(Guid idAluno)
        {
            var aluno = await _alunoQueries.ObterAlunoPorId(idAluno);
            return aluno != null ? Ok(aluno) : NotFound();
        }

        [HttpGet]
        [Route("obter-alunos")]
        public async Task<ActionResult<IEnumerable<AlunosDetailsDto>>> ObterAlunos()
        {
            var alunos = await _alunoQueries.ObterAlunos();
            return alunos != null && alunos.Any() ? Ok(alunos) : NoContent();
        }

        [HttpPost]
        [Route("cadastrar-aluno")]
        public async Task<ActionResult> CadastrarAluno(AlunoCreateEditDto alunoDto)
        {
            var command = new CadastrarAlunoCommand(
                alunoDto.Nome,
                alunoDto.NumeroDocumento,
                alunoDto.DataNascimento,
                alunoDto.Endereco,
                alunoDto.NomePai,
                alunoDto.NomeMae);

            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }

        [HttpDelete]
        [Route("excluir-aluno")]
        public async Task<ActionResult> ExcluirAluno(Guid idAluno)
        {
            var command = new ExcluirAlunoCommand(idAluno);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest(ObterMensagensErro());
        }
    }
}
