namespace Abstractions.ServiceContracts
{
    public interface IServiceRequest
    {
        string Type { get; }
        string Data { get; }
    }
}
