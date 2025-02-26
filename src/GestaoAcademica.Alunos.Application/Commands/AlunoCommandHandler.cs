using GestaoAcademica.Alunos.Domain.Interfaces;
using GestaoAcademica.Alunos.Domain.Models;
using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace GestaoAcademica.Alunos.Application.Commands
{
    public class AlunoCommandHandler : IRequestHandler<CadastrarAlunoCommand, bool>, IRequestHandler<ExcluirAlunoCommand, bool>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public AlunoCommandHandler(IAlunoRepository alunoRepository, IMediatorHandler mediatorHandler)
        {
            _alunoRepository = alunoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(CadastrarAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var aluno = new Aluno(
                message.Nome,
                message.NumeroDocumento,
                message.DataNascimento,
                message.Endereco,
                message.NomePai,
                message.NomeMae);

            _alunoRepository.Adicionar(aluno);
            return await _alunoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(ExcluirAlunoCommand message, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorId(message.IdAluno);

            if (aluno == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("aluno", "Aluno não encontrado."));
                return false;
            }

            if (aluno.Status == Status.Ativo)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("aluno", "O aluno não pode ser excluído, pois possui status ativo."));
                return false;
            }

            _alunoRepository.Excluir(aluno);
            return await _alunoRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
