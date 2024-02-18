using Grpc.Core;

namespace Novelog.BookService.Api.Services;

public class BookService : BookServiceDefinition.BookServiceDefinitionBase
{
    private readonly ILogger<BookService> _logger;

    public BookService(ILogger<BookService> logger) => _logger = logger;

    public override Task<CreateBookResponse> CreateBook(CreateBookRequest request, ServerCallContext context)
    {
        // validate & persist book

        return Task.FromResult(new CreateBookResponse
        {
            Id = Guid.NewGuid().ToString()
        });
    }

    public override async Task<CreateBooksResponse> CreateBooks(
        IAsyncStreamReader<CreateBookRequest> requestStream,
        ServerCallContext context)
    {
        int totalAdded = 0;
        while (await requestStream.MoveNext())
        {
            var req = requestStream.Current;
            _logger.LogInformation("received book: {@Book}", req);
            totalAdded++;
        }

        return new CreateBooksResponse
        {
            TotalAdded = totalAdded
        };
    }
}
