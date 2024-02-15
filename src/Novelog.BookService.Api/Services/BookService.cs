using Grpc.Core;

namespace Novelog.BookService.Api.Services;

public class BookService : BookServiceDefinition.BookServiceDefinitionBase
{
    public override Task<CreateBookResponse> CreateBookUnary(CreateBookRequest request, ServerCallContext context)
    {
        // validate & persist book

        return Task.FromResult(new CreateBookResponse
        {
            Id = Guid.NewGuid().ToString()
        });
    }
}
