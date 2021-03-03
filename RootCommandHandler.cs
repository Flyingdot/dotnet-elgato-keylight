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
            var onValue = context.ParseResult.ValueForOption<bool>("--on");
            var offValue = context.ParseResult.ValueForOption<bool>("--off");
            try
            {
                if (onValue) await _elgato.TurnOn();
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
