using System.Threading.Tasks;
using Flyingdot.Elgato.Keylight.Model;

namespace Flyingdot.Elgato.Keylight
{
    public class Elgato : IElgato
    {
        private readonly ElgatoApiClient _apiClient;

        public Elgato(ElgatoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task TurnOn(int brightnessValue = -1, int temperatureValue = -1)
        {
            await _apiClient.Put(new ElgatoRequest
                {
                    Lights = new[]
                    {
                        new Light {On = 1, Brightness = brightnessValue, Temperature = temperatureValue}
                    }
                }
            );
        }

        public async Task TurnOff()
        {
            await _apiClient.Put(new ElgatoRequest
                {
                    Lights = new[] {new Light {On = 0}}
                }
            );
        }
    }
}
