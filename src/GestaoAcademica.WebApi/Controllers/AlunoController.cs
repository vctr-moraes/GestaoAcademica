using GestaoAcademica.Alunos.Application.Commands;
using GestaoAcademica.Alunos.Application.Interfaces;
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
        private readonly IAlunoAppService _alunoAppService;

        public AlunoController(
            IMediatorHandler mediatorHandler,
            IAlunoQueries alunoQueries,
            IAlunoAppService alunoAppService,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _alunoQueries = alunoQueries;
            _alunoAppService = alunoAppService;
        }

        [HttpGet]
        [Route("obter-aluno")]
        public async Task<ActionResult<AlunosDetailsDto>> ObterAluno(Guid idAluno)
        {
            try
            {
                var aluno = await _alunoQueries.ObterAlunoPorId(idAluno);
                return aluno != null ? Ok(aluno) : NotFound();
            }
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
                throw;
            }
        }

        [HttpGet]
        [Route("obter-alunos")]
        public async Task<ActionResult<IEnumerable<AlunosDetailsDto>>> ObterAlunos()
        {
            try
            {
                var alunos = await _alunoQueries.ObterAlunos();
                return alunos != null && alunos.Any() ? Ok(alunos) : NoContent();
            }
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        [Route("cadastrar-aluno")]
        public async Task<ActionResult> CadastrarAluno(AlunoCreateEditDto alunoDto)
        {
            try
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
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
                throw;
            }
        }

        [HttpPut]
        [Route("editar-aluno")]
        public async Task<ActionResult> AtualizarAluno(Guid id, AlunoCreateEditDto alunoDto)
        {
            try
            {
                var aluno = await _alunoQueries.ObterAlunoPorId(id);

                if (aluno == null) return BadRequest("Aluno não encontrado");

                var command = new AtualizarAlunoCommand(
                    alunoDto.Id,
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
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
                throw;
            }
        }

        [HttpDelete]
        [Route("excluir-aluno")]
        public async Task<ActionResult> ExcluirAluno(Guid idAluno)
        {
            try
            {
                var command = new ExcluirAlunoCommand(idAluno);
                await _mediatorHandler.EnviarComando(command);

                if (OperacaoValida())
                {
                    return Ok();
                }

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                Console.Write($"Exception gerada: {ex.Message}");
                throw;
            }
        }
    }
}
