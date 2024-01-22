using System.ComponentModel.DataAnnotations;

namespace MinimalAPIExample.Domain.Models;

/// <summary>
/// Game Entity
/// </summary>
public class Game
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required] 
    public string Publisher { get; set; } = null!;

    public override string ToString()
    {
        var format = $"""
        Id: {Id}
        Title: {Title}
        Publisher: {Publisher}              
        """;

        return format.Trim();
    }
}