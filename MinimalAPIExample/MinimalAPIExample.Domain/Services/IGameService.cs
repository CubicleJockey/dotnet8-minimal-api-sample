using MinimalAPIExample.Domain.Models;

namespace MinimalAPIExample.Domain.Services;

public interface IGameService
{
    ICollection<Game> GetGames();
    Game? GetGame(int id);
    void AddGame(Game game);
    void UpdateGame(int id, Game game);
    bool DeleteGame(int id);
}