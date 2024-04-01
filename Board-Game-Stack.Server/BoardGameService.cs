using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Board_Game_Stack.Server.Models;
using Newtonsoft.Json;

public class BoardGameGeekService
{
    private readonly HttpClient _httpClient;

    public BoardGameGeekService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("https://boardgamegeek.com/xmlapi2/");
    }

    public async Task<Game> GetThingInfoAsync(string thingType, int thingId)
    {
        if (string.IsNullOrEmpty(thingType))
        {
            throw new ArgumentException("Thing type cannot be null or empty.", nameof(thingType));
        }

        if (thingId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(thingId), "Thing ID must be a positive integer.");
        }

        try
        {
            var response = await _httpClient.GetAsync($"thing?type={thingType}&id={thingId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var game = JsonConvert.DeserializeObject<Game>(content);
            return game;
        }
        catch (HttpRequestException ex)
        {
            // Log or handle the exception appropriately
            throw new Exception("Failed to retrieve thing information.", ex);
        }
    }

    private void ValidateGameId(int gameId)
    {
        if (gameId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(gameId), "Game ID must be a positive integer.");
        }
    }
}

public class BoardGameGeekServiceException : Exception
{
    public BoardGameGeekServiceException(string message) : base(message) { }

    public BoardGameGeekServiceException(string message, Exception innerException) : base(message, innerException) { }
}
