using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight
{
    public interface IElgato
    {
        Task TurnOn(int brightnessValue = -1, int temperature = -1);
        Task TurnOff();
    }
}
