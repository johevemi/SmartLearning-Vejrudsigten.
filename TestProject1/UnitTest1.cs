using System;
using Xunit;
using NSubstitute;
using Vejrudsigten.Services;
using Moq;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Regn", 10, "Sne", -2, "Vejret skifter fra Sne til Regn med en stigning i temperatur fra -2 grader til 10 grader")]
        [InlineData("Sne", -2, "Skyet", 5, "Vejret skifter fra Skyet til Sne med en fald i temperatur fra 5 grader til -2 grader")]
        [InlineData("Klart vejr", 20, "Klart vejr", 20, "Det bliver igen Klart vejr med samme temperatur som i går på 20 grader")]
        public void Test1(string todayInfoConditions, double todayInfoTemperature, string yesterdayInfoConditions, double yesterdayInfoTemperature, string expected)
        {
            var sut = new WeatherMessageCreator();
            var actual = sut.GetWeatherMessage(todayInfoConditions, todayInfoTemperature, yesterdayInfoConditions, yesterdayInfoTemperature);

            Assert.Equal(expected, actual);
        }
    }
}
