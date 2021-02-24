using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight
{
    public interface IElgato
    {
        Task TurnOn();
        Task TurnOff();
    }
}