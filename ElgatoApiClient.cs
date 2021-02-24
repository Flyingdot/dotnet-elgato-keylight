using System.Net.Http;
using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight
{
    public class ElgatoApiClient
    {
        private readonly HttpClient _httpClient;

        public ElgatoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Put(string data)
        {
            HttpResponseMessage responseMessage = await _httpClient.PutAsync(
                $"{_httpClient.BaseAddress}elgato/lights",
                new StringContent(data));
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
