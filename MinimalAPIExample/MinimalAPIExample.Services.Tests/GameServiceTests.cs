using MinimalAPIExample.Domain.Models;
using MinimalAPIExample.Domain.Services;

namespace MinimalAPIExample.Services.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        private IGameService gameService;

        [TestInitialize]
        public void TestInitialize()
        {
            gameService = new GameService(true);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            gameService = null!;
        }
        
        [TestMethod]
        public void GetAllGames()
        {
            var games = gameService.GetGames();
            games.Should().NotBeEmpty();
            games.Count.Should().Be(15);

            foreach (var game in games)
            {
                Console.WriteLine(game.ToString());
            }
        }

        [TestMethod]
        public void AddGame()
        {
            try
            {
                var newGame = new Game
                {
                    Id = 16,
                    Title = "Dat one game",
                    Publisher = "Awesome Town"
                };

                gameService.AddGame(newGame);
            }
            catch
            {
                Assert.Fail("Should not have failed to add Game.");
            }
        }


        [DataRow(2, "Super Mario Odyssey")]
        [DataRow(12, "Spider-Man")]
        [DataTestMethod]
        public void GetGame(int id, string expectedTitle)
        {
            var game = gameService.GetGame(id);
            game.Should().NotBeNull();
            game.Title.Should().Be(expectedTitle);
        }

        [DataRow(2, "Not Super Mario Odyssey")]
        [DataRow(12, "Not Spider-Man")]
        [DataTestMethod]
        public void UpdateGame(int id, string newTitle)
        {
            gameService.UpdateGame(id, new () { Title = newTitle });
            var game = gameService.GetGame(id);
            game.Should().NotBeNull();
            game.Title.Should().Be(newTitle);
        }

        [DataRow(2)]
        [DataRow(13)]
        [DataRow(4)]
        [DataTestMethod]
        public void DeleteGame(int id)
        {
            var isDeleted = gameService.DeleteGame(id);
            isDeleted.Should().BeTrue();
        }
    }
}