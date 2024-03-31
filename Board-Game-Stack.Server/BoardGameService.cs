using System.Net.Http;
using System.Threading.Tasks;
using Board_Game_Stack.Server.Models;
using Newtonsoft.Json;

public class BoardGameGeekService
{
    private readonly HttpClient _httpClient;

    public BoardGameGeekService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new System.Uri("https://boardgamegeek.com/xmlapi2/");
    }

    public async Task<Game> GetBoardGameInfo(int gameId)
    {
        var response = await _httpClient.GetStringAsync($"thing?id={gameId}");
        return JsonConvert.DeserializeObject<Game>(response);
    }
}


