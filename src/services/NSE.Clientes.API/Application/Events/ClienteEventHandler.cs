using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NSE.Clientes.API.Application.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            // Falta implementar um evento de confirmação
            return Task.CompletedTask;
        }
    }
}