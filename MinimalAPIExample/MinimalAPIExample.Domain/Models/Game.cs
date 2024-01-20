namespace MinimalAPIExample.Domain.Models;

public class Game
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }

    public override string ToString()
    {
        var format = $"""
        Id: {Id}
        Title: {Title}
        Publisher: {Publisher}              
        """;

        return format;
    }
}