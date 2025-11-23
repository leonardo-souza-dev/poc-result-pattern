using Foo.Api.Domain;

namespace Foo.Api.UseCases
{
    public class GetClientUseCase
    {
        public async Task<GetClientResponse> Handle(GetClientRequest request)
        {
            await Task.Delay(1);
            return GetClientResponse.Of(new Client(request.Id, request.Name));
        }
    }

    public sealed record GetClientRequest(int Id, string Name);

    public class GetClientResponse
    {
        public required int Id { get; init; }
        public required string Name { get; init; }

        public static GetClientResponse Of(Client client) => new() { Id = client.Id, Name = client.Name };
    }
}