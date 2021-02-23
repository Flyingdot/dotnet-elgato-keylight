using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Flyingdot.Elgato.Keylight
{
    static class Program
    {
        private const string Address = "192.168.1.188";
        private const int Port = 9123;

        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await Run(args, host.Services);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddHttpClient<ElgatoClient>());

        private static async Task Run(string[] args, IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            if (!args.Any() || !int.TryParse(args[0], out int onOffSwitch))
            {
                onOffSwitch = 1;
            }

            // simple turn on/off
            Console.WriteLine($"Switch: {onOffSwitch}");
            string data = $"{{\"numberOfLights\":1,\"lights\":[{{\"on\":{onOffSwitch}}}]}}";
            ElgatoClient elgato = provider.GetRequiredService<ElgatoClient>();
            await elgato.Put(Address, Port, data);
        }
    }
}
