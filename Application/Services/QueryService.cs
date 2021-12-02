using Abstractions.ServiceContracts;
using Abstractions.Services;
using MediatR;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class QueryService : IQueryService
    {
        private readonly IMediator _mediator;

        public QueryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<dynamic> ExecuteQuery(IServiceRequest request)
        {
            var type = GetQueriesAssembly().GetType(request.Type);

            var query = JsonConvert.DeserializeObject(request.Data, type);

            return await _mediator.Send(query);
        }

        private static Assembly GetQueriesAssembly()
        {
            return typeof(QueryService).Assembly;
        }
    }
}