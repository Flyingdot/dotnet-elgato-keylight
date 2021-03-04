using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
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
            => await BuildCommandline()
                .UseHost(_ => Host.CreateDefaultBuilder(),
                    host =>
                    {
                        host.ConfigureServices(services =>
                        {
                            services
                                .AddTransient<IElgato, Elgato>()
                                .AddHttpClient<ElgatoApiClient>(client =>
                                {
                                    client.BaseAddress = new Uri($"http://{Address}:{Port}");
                                });
                        }).UseCommandHandler<RootCommand, RootCommandHandler>();
                    })
                .UseDefaults()
                .Build()
                .InvokeAsync(args);

        private static CommandLineBuilder BuildCommandline()
        {
            var root = new RootCommand(@"TODO description")
            {
                new Option<bool>("--on", () => false),
                new Option<bool>("--off", () => false),
                new Option<int>("--brightness", () => -1)
                    .FromAmong(Enumerable.Range(0, 101).Select(i => i.ToString()).ToArray())
            };

            return new CommandLineBuilder(root);
        }
    }
}
