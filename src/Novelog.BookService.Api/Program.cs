using Novelog.BookService.Api.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, cfg) =>
    cfg.ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<BookService>();
app.Run();
