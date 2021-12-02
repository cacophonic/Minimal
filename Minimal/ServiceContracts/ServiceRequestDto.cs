using Abstractions.ServiceContracts;

namespace Minimal.ServiceContracts
{
    public class ServiceRequestDto : IServiceRequest
    {
        public string? Type { get; set; }

        public string? Data { get; set; }
    }
}