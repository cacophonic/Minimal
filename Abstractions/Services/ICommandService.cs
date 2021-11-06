using Abstractions.ServiceContracts;
using System.Threading.Tasks;

namespace Abstractions.Services
{
    public interface ICommandService
    {
        Task ExecuteCommand(IServiceRequest request);
        Task<dynamic> ExecuteCommandWithResult(IServiceRequest request);
    }
}
