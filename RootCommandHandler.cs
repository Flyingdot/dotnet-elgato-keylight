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
            Console.WriteLine("!!!!");
            await _elgato.TurnOn();
            return 0;
        }
    }
}