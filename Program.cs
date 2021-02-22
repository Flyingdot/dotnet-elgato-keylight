using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flyingdot.Elgato.Keylight
{
    static class Program
    {
        private const string Address = "192.168.1.188";
        private const int Port = 9123;

        static async Task Main(string[] args)
        {
            Console.WriteLine("dotnet-elgato-keylight");

            if (!args.Any() || !int.TryParse(args[0], out int onOffSwitch))
            {
                onOffSwitch = 1;
            }

            // simple turn on/off
            Console.WriteLine($"Switch: {onOffSwitch}");
            string data = $"{{\"numberOfLights\":1,\"lights\":[{{\"on\":{onOffSwitch}}}]}}";
            var elgato = new ElgatoClient(new HttpClient()); // TODO: DI
            await elgato.Put(Address, Port, data);
        }
    }
}
