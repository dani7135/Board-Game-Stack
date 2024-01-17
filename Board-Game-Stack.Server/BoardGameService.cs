using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class BoardGameGeekService
{
    private readonly HttpClient _httpClient;

    public BoardGameGeekService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new System.Uri("https://boardgamegeek.com/xmlapi2/");
    }

    public async Task<BoardGameInfo> GetBoardGameInfo(int gameId)
    {
        var response = await _httpClient.GetStringAsync($"thing?id={gameId}");
        return JsonConvert.DeserializeObject<BoardGameInfo>(response);
    }
}

public class BoardGameInfo
{
    // Define the properties you want to extract from the API response
    public int Id { get; set; }
    public string Name { get; set; }
    // Add other properties as needed
}
