using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flyingdot.Elgato.Keylight.Model;

namespace Flyingdot.Elgato.Keylight
{
    public class ElgatoApiClient
    {
        private readonly HttpClient _httpClient;

        public ElgatoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Put(ElgatoRequest request)
        {
            string json = JsonSerializer.Serialize<ElgatoRequest>(request);
            HttpResponseMessage responseMessage = await _httpClient.PutAsync(
                $"{_httpClient.BaseAddress}elgato/lights",
                new StringContent(json));
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
