using System;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Flyingdot.Elgato.Keylight.Model;
using Microsoft.Extensions.Logging;

namespace Flyingdot.Elgato.Keylight
{
    public class ElgatoApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ElgatoApiClient> _logger;

        public ElgatoApiClient(HttpClient httpClient, ILogger<ElgatoApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task Put(ElgatoRequest request)
        {
            try
            {
                string json = JsonSerializer.Serialize(request);
                HttpResponseMessage responseMessage = await _httpClient.PutAsync(
                    $"{_httpClient.BaseAddress}elgato/lights",
                    new StringContent(json));
                responseMessage.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                _logger.LogError("Elgato API Request failed: {ErrorMessage}", e.Message);
            }
        }

        public async Task<ElgatoResponse> Get()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ElgatoResponse>(
                    $"{_httpClient.BaseAddress}elgato/lights");
                return response;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError("Elgato API Request failed: {ErrorMessage}", e.Message);
                throw;
            }
        }
    }
}
