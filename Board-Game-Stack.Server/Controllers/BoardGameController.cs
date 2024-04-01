using Board_Game_Stack.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

[ApiController]
[Route("[controller]")]
public class BoardGameController : ControllerBase
{
    private readonly BoardGameGeekService _boardGameGeekService;

    public BoardGameController(BoardGameGeekService boardGameGeekService)
    {
        _boardGameGeekService = boardGameGeekService;
    }

    [HttpGet("{thingType}/{thingId}")]
    public async Task<ActionResult<XDocument>> GetThingInfo(string thingType, int thingId)
    {
        try
        {
            var thingInfo = await _boardGameGeekService.GetThingInfoAsync(thingType, thingId);
            return Ok(thingInfo);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Failed to retrieve thing information.");
        }
    }
}