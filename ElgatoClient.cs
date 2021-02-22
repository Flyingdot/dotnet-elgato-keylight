using System.Net.Http;
using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight
{
    public class ElgatoClient
    {
        private readonly HttpClient _httpClient;

        public ElgatoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Put(string address, int port, string data)
        {
            HttpResponseMessage responseMessage = await _httpClient.PutAsync($"http://{address}:{port}/elgato/lights",
                new StringContent(data));
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
