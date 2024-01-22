using MinimalAPIExample.Domain.Models;

namespace MinimalAPIExample.Domain.Tests.Models;

[TestClass]
public class GameTests
{

    [DataRow(1, "A", "APublisher")]
    [DataRow(2, "B", "BPublisher")]
    [DataRow(3, "C", "CPublisher")]
    [DataRow(4, "D", "DPublisher")]
    [DataTestMethod]
    public void ToString(int id, string title, string publisher)
    {
        const string expectedFormat = """
                                       Id: {0}
                                       Title: {1}
                                       Publisher: {2}
                                       """;

        //Arrange
        var entity = new Game
        {
            Id = id,
            Title = title,
            Publisher = publisher
        };

        var expected = string.Format(expectedFormat, id, title, publisher);
        
        //Act
        var result = entity.ToString();

        //Assert
        result.Should().Be(expected);
    }
}