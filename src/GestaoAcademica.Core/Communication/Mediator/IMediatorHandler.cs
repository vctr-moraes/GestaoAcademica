using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;

namespace GestaoAcademica.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
