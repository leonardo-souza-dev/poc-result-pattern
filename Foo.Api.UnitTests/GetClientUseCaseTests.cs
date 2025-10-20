using Foo.Api.Repository;
using Foo.Api.UseCases;
using ResultPattern;

namespace Foo.Application.UnitTests;

public class GetClientUseCaseTests
{
    [Test]
    public async Task FooTest()
    {
        // Arrange
        var sut = new GetClientUseCase(new ClientRepository());

        // Act
        var result = await sut.Handle(new GetClientRequest(1, "John Doe"));

        // Assert
        Assert.That(result, Is.InstanceOf<Result<GetClientResponse>>());
        Assert.That(result.Data, Is.InstanceOf<GetClientResponse>());
        Assert.That(result.Data.Id, Is.EqualTo(1));
        Assert.That(result.Data.Name, Is.EqualTo("John Doe"));
    }
}