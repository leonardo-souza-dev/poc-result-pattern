using Foo.Api.Domain;
using Foo.Api.Repository;
using ResultPattern;

namespace Foo.Api.UseCases
{
    public class GetClientUseCase(IClientRepository clientRepository)
    {
        public async Task<Result<GetClientResponse>> Handle(GetClientRequest request)
        {
            if (request.Name.Split().Count() != 2)
                return Result<GetClientResponse>.AsFailure(Failure.Of(FailureConstants.ValidationError, "Erro de validação."));

            var client = clientRepository.GetByName(request.Name);
            if (client == null)
                return Result<GetClientResponse>.AsFailure(Failure.Of(FailureConstants.ResourceNotFound, "O cliente solicitado não foi encontrado."));

            return Result<GetClientResponse>.AsSuccess(GetClientResponse.Of(client));
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