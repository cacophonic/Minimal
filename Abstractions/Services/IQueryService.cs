using Abstractions.ServiceContracts;
using System.Threading.Tasks;

namespace Abstractions.Services
{
    public interface IQueryService
    {
        Task<dynamic> ExecuteQuery(IServiceRequest request);
    }
}
