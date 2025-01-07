using GestaoAcademica.Core.Messages;
using MediatR;

namespace GestaoAcademica.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediatr;

        public MediatorHandler(IMediator mediator)
        {
            _mediatr = mediator;
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediatr.Send(comando);
        }
    }
}
