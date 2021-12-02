// See https://aka.ms/new-console-template for more information
using Abstractions.ServiceContracts;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using System.Text;
using System.Text.Json;

new LoadTests().QueryLoadTest();

    public class LoadTests
    {
        internal class ServiceRequest : IServiceRequest
        {
            public ServiceRequest(string type, dynamic data)
            {
                Type = type;
                Data = JsonSerializer.Serialize(data, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            public string Type { get; }

            public string Data { get; }

            public string AsJson()
            {
                return JsonSerializer.Serialize(this, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
            }
        }

        public void QueryLoadTest()
        {
            var httpFactory = HttpClientFactory.Create();

            var step1 = Step.Create("step 1", clientFactory: httpFactory, execute: async context =>
            {
                var query = new ServiceRequest("Application.Components.Prime.Queries.GetPrimeNumber", new { NthPrime = 50000 });

                var request = Http.CreateRequest("POST", "https://localhost:7293/queries/executequery")
                    .WithBody(new StringContent(query.AsJson(), Encoding.UTF8, "application/json"));

                var response = await Http.Send(request, context);

                return response;
            });

            var scenario = ScenarioBuilder
                .CreateScenario("Query Scenario", step1)
                .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(10)));

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
        }
    }
