using Board_Game_Stack.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Stack.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardGameController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BoardGameController> _logger;

        public BoardGameController(ILogger<BoardGameController> logger)
        {
            _logger = (ILogger<BoardGameController>?)logger;
        }

        [HttpGet(Name = "GetBoardGame")]
        public IEnumerable<Game> Get()
        {
            var random = new Random();

            var games = Enumerable.Range(1, 5).Select(index => new Game
            {
                Title = $"Game {index}",
                PlayingTimer = random.Next(30, 121), // Random playing time between 30 and 120 minutes
                YearPublished = $"{DateTime.Now.Year - index}",
                Summary = $"Summary for Game {index}"
            }).ToArray();

            return games;
        }

    }
}
