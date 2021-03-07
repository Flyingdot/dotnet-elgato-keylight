using System;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight
{
    public class RootCommandHandler : ICommandHandler
    {
        private readonly IElgato _elgato;

        public RootCommandHandler(IElgato elgato)
        {
            _elgato = elgato;
        }

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            bool onValue = context.ParseResult.ValueForOption<bool>("--on");
            bool offValue = context.ParseResult.ValueForOption<bool>("--off");
            int brightnessValue = context.ParseResult.ValueForOption<int>("--brightness");
            int temperaturerValue = context.ParseResult.ValueForOption<int>("--temperature");

            try
            {
                if (onValue && brightnessValue > -1 && temperaturerValue > -1) await _elgato.TurnOn(brightnessValue, temperaturerValue);
                else if (onValue) await _elgato.TurnOn();
                else if (offValue) await _elgato.TurnOff();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 0;
        }
    }
}
