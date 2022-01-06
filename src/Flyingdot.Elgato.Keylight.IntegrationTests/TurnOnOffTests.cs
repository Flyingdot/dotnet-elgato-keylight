using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Flyingdot.Elgato.Keylight.IntegrationTests;

public class TurnOnOffTests : IDisposable
{
    private readonly Elgato _sut;
    private readonly ElgatoApiClient _apiClient;

    public TurnOnOffTests()
    {
        _apiClient = new ElgatoApiClient(
            new HttpClient { BaseAddress = new Uri("http://192.168.1.188:9123")},
            NullLogger<ElgatoApiClient>.Instance);
        _sut = new Elgato(_apiClient);
        SetLightsToDefaultState();
    }

    [Fact]
    public async Task TurnOn()
    {
        await _sut.TurnOn();

        var currentState = await _apiClient.Get();
        Assert.Equal(1, currentState.Lights[0].On);
    }

    [Fact]
    public async Task TurnOff()
    {
        await _sut.TurnOn();
        await _sut.TurnOff();

        var currentState = await _apiClient.Get();
        Assert.Equal(0, currentState.Lights[0].On);
    }

    private void SetLightsToDefaultState()
    {
        _sut.TurnOff();
    }

    public void Dispose()
    {
        SetLightsToDefaultState();
    }
}
