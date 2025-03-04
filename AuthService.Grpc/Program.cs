using AuthService.Grpc.Services;
using AuthService.Infrastructure.ServiceExtensions;
using AuthService.Application.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
//app.MapGrpcService<AuthServiceBase>();
app.Run();
