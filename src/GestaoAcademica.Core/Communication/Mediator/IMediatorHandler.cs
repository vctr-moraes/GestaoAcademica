using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}
