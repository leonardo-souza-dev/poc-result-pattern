using Foo.Api.UseCases;

namespace Foo.Application.UnitTests;

public class GetClientUseCaseTests
{
    [Test]
    public async Task FooTest()
    {
        // Arrange
        var sut = new GetClientUseCase();

        // Act
        var actual = await sut.Handle(new GetClientRequest(1, "John Doe"));

        // Assert
        Assert.That(actual, Is.InstanceOf<GetClientResponse>());
        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.EqualTo(1));
            Assert.That(actual.Name, Is.EqualTo("John Doe"));
        });

    }
}
