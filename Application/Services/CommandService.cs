using Abstractions.ServiceContracts;
using Abstractions.Services;
using MediatR;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class CommandService : ICommandService
    {
        private readonly IMediator _mediator;

        public CommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ExecuteCommand(IServiceRequest request)
        {
            var type = GetCommandAssembly().GetType(request.Type);

            var command = JsonConvert.DeserializeObject(request.Data, type);

            await _mediator.Send(command);
        }

        public async Task<dynamic> ExecuteCommandWithResult(IServiceRequest request)
        {
            var type = GetCommandAssembly().GetType(request.Type);

            var command = JsonConvert.DeserializeObject(request.Data, type);

            return await _mediator.Send(command);
        }

        private static Assembly GetCommandAssembly()
        {
            return typeof(CommandService).Assembly;
        }
    }
}