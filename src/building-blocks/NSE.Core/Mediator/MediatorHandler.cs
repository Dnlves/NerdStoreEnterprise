using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;

namespace NSE.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviarComando<T>(T commando) where T : Command
        {
            return await _mediator.Send(commando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}