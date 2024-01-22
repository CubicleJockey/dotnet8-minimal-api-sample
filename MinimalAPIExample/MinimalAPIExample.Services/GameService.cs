using MinimalAPIExample.Domain.Models;
using MinimalAPIExample.Domain.Services;

namespace MinimalAPIExample.Services;

/// <summary>
/// Mock Game Service for Minimal Web Api Example
/// </summary>
public class GameService : IGameService
{
    private readonly List<Game> games;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="preInitialize">Initialize with some test data.</param>
    public GameService(bool preInitialize = false)
    {
        if (preInitialize)
        {
            games =
            [
                new() { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Publisher = "Nintendo" },
                new() { Id = 2, Title = "Super Mario Odyssey", Publisher = "Nintendo" },
                new() { Id = 3, Title = "Mario Kart 8 Deluxe", Publisher = "Nintendo" },
                new() { Id = 4, Title = "Animal Crossing: New Horizons", Publisher = "Nintendo" },
                new() { Id = 5, Title = "Halo Infinite", Publisher = "Xbox Game Studios" },
                new() { Id = 6, Title = "Gears 5", Publisher = "Xbox Game Studios" },
                new() { Id = 7, Title = "Forza Horizon 5", Publisher = "Xbox Game Studios" },
                new() { Id = 8, Title = "Sea of Thieves", Publisher = "Xbox Game Studios" },
                new() { Id = 9, Title = "God of War", Publisher = "Sony Interactive Entertainment" },
                new() { Id = 10, Title = "The Last of Us Part II", Publisher = "Sony Interactive Entertainment" },
                new() { Id = 11, Title = "Ghost of Tsushima", Publisher = "Sony Interactive Entertainment" },
                new() { Id = 12, Title = "Spider-Man", Publisher = "Sony Interactive Entertainment" },
                new() { Id = 13, Title = "Ratchet & Clank: Rift Apart", Publisher = "Sony Interactive Entertainment" },
                new() { Id = 14, Title = "Uncharted 4: A Thief's End", Publisher = "Sony Interactive Entertainment" },
                new() { Id = 15, Title = "Final Fantasy VII Remake", Publisher = "Square Enix" }
            ];
        }
    }
    
    /// <summary>
    /// Get all games
    /// </summary>
    /// <returns>Collection of Games</returns>
    public ICollection<Game> GetGames() => games;

    /// <summary>
    /// Get a game by its id
    /// </summary>
    /// <param name="id">ID of game</param>
    /// <returns>A game found by its ID or default</returns>
    public Game? GetGame(int id) => games.FirstOrDefault(game => game.Id == id);

    /// <summary>
    /// Adds a game to the collection.
    /// </summary>
    /// <param name="game">Game to be added to the collection.</param>
    public void AddGame(Game game) => games.Add(game);

    /// <summary>
    /// Update an existing game
    /// </summary>
    /// <param name="id">ID of game to update.</param>
    /// <param name="game">Update information for existing game.</param>
    public void UpdateGame(int id, Game game)
    {
        var toUpdate = games.FirstOrDefault(g => g.Id == id);
        if (toUpdate != default)
        {
            if (!string.IsNullOrWhiteSpace(game.Title))
            {
                toUpdate.Title = game.Title;
            }

            if (!string.IsNullOrWhiteSpace(game.Publisher))
            {
                toUpdate.Publisher = game.Publisher;
            }
        }
    }

    /// <summary>
    /// Game to delete
    /// </summary>
    /// <param name="id">ID of the game to delete.</param>
    /// <returns>True if game successfully deleted, else false.</returns>
    public bool DeleteGame(int id)
    {
        var toRemove = games.FirstOrDefault(game => game.Id == id);
        return toRemove != default && games.Remove(toRemove);
    }
}