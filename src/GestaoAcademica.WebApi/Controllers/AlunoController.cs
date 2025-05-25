using GestaoAcademica.Alunos.Application.Commands;
using GestaoAcademica.Alunos.Application.Interfaces;
using GestaoAcademica.Alunos.Application.Queries;
using GestaoAcademica.Alunos.Application.Queries.Dtos;
using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.WebApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GestaoAcademica.WebApi.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAlunoQueries _alunoQueries;
        private readonly IAlunoAppService _alunoAppService;
        private readonly ILogger<AlunoController> _logger;

        public AlunoController(
            IMediatorHandler mediatorHandler,
            IAlunoQueries alunoQueries,
            IAlunoAppService alunoAppService,
            INotificationHandler<DomainNotification> notifications,
            ILogger<AlunoController> logger) : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _alunoQueries = alunoQueries;
            _alunoAppService = alunoAppService;
            _logger = logger;
        }

        [HttpGet]
        [Route("obter-aluno")]
        public async Task<ActionResult<AlunosDetailsDto>> ObterAluno(Guid idAluno)
        {
            try
            {
                var aluno = await _alunoQueries.ObterAlunoPorId(idAluno);

                _logger.LogInformation(message: $"Sucesso ao obter aluno.", args: [JsonSerializer.Serialize(aluno), DateTime.Now, nameof(GetType)]);

                return aluno != null ? Ok(aluno) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao obter aluno.", args: [DateTime.Now, nameof(GetType)]);
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

                _logger.LogInformation(message: $"Sucesso ao obter alunos.", args: [JsonSerializer.Serialize(alunos), DateTime.Now, nameof(GetType)]);

                return alunos != null && alunos.Any() ? Ok(alunos) : NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao obter alunos.", args: [DateTime.Now, nameof(GetType)]);
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
                    _logger.LogInformation(message: $"Sucesso ao cadastrar aluno.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao cadastrar aluno.", args: [DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao cadastrar aluno.", args: [DateTime.Now, nameof(GetType)]);
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
                    _logger.LogInformation(message: $"Sucesso ao atualizar aluno.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao atualizar aluno.", args: [DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao atualizar aluno.", args: [DateTime.Now, nameof(GetType)]);
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
                    _logger.LogInformation(message: $"Sucesso ao excluir aluno.", args: [JsonSerializer.Serialize(command), DateTime.Now, nameof(GetType)]);

                    return Ok();
                }

                _logger.LogError(message: "Ocorreu um erro ao excluir aluno.", args: [DateTime.Now, nameof(GetType)]);

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(exception: ex, message: "Ocorreu uma exceção ao excluir aluno.", args: [DateTime.Now, nameof(GetType)]);
                throw;
            }
        }
    }
}
