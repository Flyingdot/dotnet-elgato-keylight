using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight.Model
{
    public class ElgatoRequest
    {
        public int NumberOfLights => 1;
        public Light[] Lights { get; set; }
    }
}

