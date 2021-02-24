using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight
{
    public class Elgato : IElgato
    {
        private readonly ElgatoApiClient _apiClient;

        public Elgato(ElgatoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task TurnOn()
        {
            await _apiClient.Put("{\"numberOfLights\": 1, \"lights\":[{\"on\": 1}]}");
        }

        public async Task TurnOff()
        {
            await _apiClient.Put("{\"numberOfLights\": 1, \"lights\":[{\"on\": 0}]}");
        }
    }
}
