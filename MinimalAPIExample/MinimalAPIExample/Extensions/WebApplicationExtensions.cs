using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPIExample.Domain.Models;
using MinimalAPIExample.Domain.Services;

namespace MinimalAPIExample.Extensions;

public static class WebApplicationExtensions
{
    private const string GAME_ENDPOINT_BASE = "games";
    
    /// <summary>
    /// Configure the Game Service API Endpoints
    /// </summary>
    /// <param name="application">Extensions for the WebApplication Class</param>
    public static void ConfigureGameServiceEndpoints(this WebApplication application)
    {
        ConfigureGetEndpoints(application);
        ConfigurePostEndpoints(application);
        ConfigurePutEndpoints(application);
        ConfigureDeleteEndpoints(application);
    }

    #region Helper Methods

    private static void ConfigureGetEndpoints(IEndpointRouteBuilder application)
    {
        application.MapGet($"/{GAME_ENDPOINT_BASE}", (IGameService gameService) => TypedResults.Ok(gameService.GetGames()))
                   .WithName("GetGames");

        application.MapGet($"/{GAME_ENDPOINT_BASE}/{{id}}", Results<Ok<Game>, NotFound> (IGameService gameService, int id) =>
        {
            var game = gameService.GetGame(id);
            return game is { } ? TypedResults.Ok(game) : TypedResults.NotFound();
        }).WithName("GetGameById");
    }

    private static void ConfigurePostEndpoints(IEndpointRouteBuilder application)
    {
        application.MapPost($"/{GAME_ENDPOINT_BASE}", (IGameService gameService, Game newGame) =>
        {
            gameService.AddGame(newGame);
            return TypedResults.Created($"/{GAME_ENDPOINT_BASE}/{newGame.Id}", newGame);
        }).WithName("AddGame");
    }

    private static void ConfigurePutEndpoints(IEndpointRouteBuilder application)
    {
        application.MapPut($"/{GAME_ENDPOINT_BASE}/{{id}}", (IGameService gameService, int id, Game updatedGame) =>
        {
            gameService.UpdateGame(id, updatedGame);
            return TypedResults.Ok();
        }).WithName("UpdateGame");
    }

    private static void ConfigureDeleteEndpoints(IEndpointRouteBuilder application)
    {
        application.MapDelete($"/{GAME_ENDPOINT_BASE}/{{id}}", (IGameService gameService, int id) =>
        {
            var isDeleted = gameService.DeleteGame(id);
            return TypedResults.Ok(new { Deleted = isDeleted });
        }).WithName("DeleteGame");
    }
    
    #endregion Helper Methods
}