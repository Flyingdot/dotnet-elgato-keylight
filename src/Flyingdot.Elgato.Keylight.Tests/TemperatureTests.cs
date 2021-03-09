using Xunit;
using Flyingdot.Elgato.Keylight;

namespace Flyingdot.Elgato.Keylight.Tests
{
    public class TemperatureTests
    {
        [Theory]
        [InlineData(7000, 142)]
        [InlineData(4500, 222)]
        [InlineData(3000, 333)]
        public void FromKelvinToMired(int valueInK, int expected)
        {
            int actual = Temperature.FromKelvinToMired(valueInK);

            Assert.Equal(actual, expected);
        }
    }
}
