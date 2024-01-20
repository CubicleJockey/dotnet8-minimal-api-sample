using MinimalAPIExample.Domain.Models;
using MinimalAPIExample.Domain.Services;

namespace MinimalAPIExample.Services;

public class GameService : IGameService
{
    private readonly ICollection<Game> games;

    public GameService(bool preInitialize = false)
    {
        if (preInitialize)
        {
            games = new List<Game>
            {
                new () { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Publisher = "Nintendo" },
                new () { Id = 2, Title = "Super Mario Odyssey", Publisher = "Nintendo" },
                new () { Id = 3, Title = "Mario Kart 8 Deluxe", Publisher = "Nintendo" },
                new () { Id = 4, Title = "Animal Crossing: New Horizons", Publisher = "Nintendo" },
                new () { Id = 5, Title = "Halo Infinite", Publisher = "Xbox Game Studios" },
                new () { Id = 6, Title = "Gears 5", Publisher = "Xbox Game Studios" },
                new () { Id = 7, Title = "Forza Horizon 5", Publisher = "Xbox Game Studios" },
                new () { Id = 8, Title = "Sea of Thieves", Publisher = "Xbox Game Studios" },
                new () { Id = 9, Title = "God of War", Publisher = "Sony Interactive Entertainment" },
                new () { Id = 10, Title = "The Last of Us Part II", Publisher = "Sony Interactive Entertainment" },
                new () { Id = 11, Title = "Ghost of Tsushima", Publisher = "Sony Interactive Entertainment" },
                new () { Id = 12, Title = "Spider-Man", Publisher = "Sony Interactive Entertainment" },
                new () { Id = 13, Title = "Ratchet & Clank: Rift Apart", Publisher = "Sony Interactive Entertainment" },
                new () { Id = 14, Title = "Uncharted 4: A Thief's End", Publisher = "Sony Interactive Entertainment" },
                new () { Id = 15, Title = "Final Fantasy VII Remake", Publisher = "Square Enix" } // Available on PlayStation
            };
        }
    }
    
    public ICollection<Game> GetGames() => games;

    public Game? GetGame(int id) => games.FirstOrDefault(game => game.Id == id);

    public void AddGame(Game game) => games.Add(game);

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

    public bool DeleteGame(int id)
    {
        var toRemove = games.FirstOrDefault(game => game.Id == id);
        return toRemove != default && games.Remove(toRemove);
    }
}