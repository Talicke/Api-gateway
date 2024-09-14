using Xunit;

namespace simpl_cine.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void TemperatureF_ShouldReturnCorrectFahrenheitValue()
        {
            // Arrange
            var forecast = new WeatherForecast
            {
                TemperatureC = 0 // 0°C correspond à 32°F
            };

            // Act
            var temperatureF = forecast.TemperatureF;

            // Assert
            Assert.Equal(32, temperatureF);
        }

        [Fact]
        public void Date_ShouldSetAndGetCorrectValue()
        {
            // Arrange
            var forecast = new WeatherForecast();
            var expectedDate = new DateOnly(2024, 9, 12);

            // Act
            forecast.Date = expectedDate;

            // Assert
            Assert.Equal(expectedDate, forecast.Date);
        }

        [Fact]
        public void Summary_ShouldBeNullInitially()
        {
            // Arrange
            var forecast = new WeatherForecast();

            // Act & Assert
            Assert.Null(forecast.Summary);
        }

        [Fact]
        public void Summary_ShouldSetAndGetCorrectValue()
        {
            // Arrange
            var forecast = new WeatherForecast();
            var expectedSummary = "Sunny";

            // Act
            forecast.Summary = expectedSummary;

            // Assert
            Assert.Equal(expectedSummary, forecast.Summary);
        }
    }
}
