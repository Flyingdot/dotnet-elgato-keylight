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

        public async Task TurnOn(int brightnessValue = -1)
        {
            await _apiClient.Put($"{{\"numberOfLights\": 1, \"lights\":[{{\"on\": 1, \"brightness\": {brightnessValue}}}]}}");
        }

        public async Task TurnOff()
        {
            await _apiClient.Put("{\"numberOfLights\": 1, \"lights\":[{\"on\": 0}]}");
        }
    }
}
