using GestaoAcademica.Alunos.Domain.Interfaces;
using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.IntegrationEvents;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace GestaoAcademica.Alunos.Domain.Events
{
    public class AlunoEventHandler : INotificationHandler<AtualizarStatusNovoAlunoMatriculadoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAlunoRepository _alunoRepository;

        public AlunoEventHandler(IMediatorHandler mediatorHandler, IAlunoRepository alunoRepository)
        {
            _mediatorHandler = mediatorHandler;
            _alunoRepository = alunoRepository;
        }

        public async Task Handle(AtualizarStatusNovoAlunoMatriculadoEvent message, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorId(message.IdAluno);

            if (aluno == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("aluno", "Aluno não encontrado."));
                return;
            }

            aluno.TornarAtivo();

            _alunoRepository.Atualizar(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }
    }
}
