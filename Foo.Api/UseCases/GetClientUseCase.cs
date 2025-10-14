using Foo.Api.Domain;
using Foo.Api.Infrastructure;
using Foo.Api.Repository;
using TheLibrary;

namespace Foo.Api.UseCases
{
    public class GetClientUseCase(IClientRepository clientRepository)
    {
        public Result<CreateClientResponse> Handle(GetClientRequest? request)
        {
            if (request == null)
            {
                return Result<CreateClientResponse>.Failure("Invalid request.", FooResultStatus.InvalidRequest);
            }
            
            var client = clientRepository.GetByName(request.Name);
            if (client == null)
            {
                return Result<CreateClientResponse>.Failure("Client not found.", FooResultStatus.ClientNotFound);
            }
            
            return Result<CreateClientResponse>.Success(CreateClientResponse.Of(client), FooResultStatus.Success);
        }
    }

    public sealed class GetClientRequest
    {
        public required string Name { get; init; }
    }
    
    public class CreateClientResponse
    {
        public required int Id { get; init; }
        public required string Name { get; init; }

        public static CreateClientResponse Of(Client client)
        {
            return new CreateClientResponse { Id = client.Id, Name = client.Name };
        }
    }
}