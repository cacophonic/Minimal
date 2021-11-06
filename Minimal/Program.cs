using Abstractions.Services;
using Minimal.ServiceContracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
var app = builder.Build();

app.MapGet("/", (HttpContext context) => "Running...");

app.MapPost("/Queries/ExecuteQuery", (ServiceRequestDto request, IQueryService queryService) => queryService.ExecuteQuery(request));

app.MapPost("/Commands/ExecuteCommand", (ServiceRequestDto request, ICommandService commandService) => commandService.ExecuteCommand(request));

app.MapPost("/Commands/ExecuteCommandWithResult", (ServiceRequestDto request, ICommandService commandService) => commandService.ExecuteCommandWithResult(request));

app.Run();
