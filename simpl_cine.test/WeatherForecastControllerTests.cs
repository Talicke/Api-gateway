using Microsoft.Extensions.Logging;
using Moq;
using simpl_cine.Controllers;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace simpl_cine.Tests
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;
        private readonly Mock<ILogger<WeatherForecastController>> _loggerMock;

        // Initialisation des objets avant chaque test
        public WeatherForecastControllerTests()
        {
            // Cr�ation du mock pour ILogger
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();

            // Instanciation du contr�leur avec le mock du logger
            _controller = new WeatherForecastController(_loggerMock.Object);
        }

        // Test simple pour v�rifier que Get retourne 5 WeatherForecasts
        [Fact]
        public void Get_ReturnsFiveWeatherForecasts()
        {
            // Act : appel de la m�thode Get
            var result = _controller.Get();

            // Assert : v�rification que le r�sultat contient bien 5 �l�ments
            Assert.NotNull(result); // Le r�sultat ne doit pas �tre nul
            Assert.Equal(5, result.Count()); // Il doit y avoir exactement 5 �l�ments

            // V�rifie que chaque �l�ment a un Summary valide
            Assert.All(result, item =>
                Assert.Contains(item.Summary, WeatherForecastController.Summaries));
        }

        // Test pour v�rifier que les temp�ratures sont dans la plage attendue
        [Fact]
        public void Get_ReturnsValidTemperatureRange()
        {
            // Act : appel de la m�thode Get
            var result = _controller.Get();

            // Assert : v�rifier que chaque �l�ment a une temp�rature entre -20 et 55
            Assert.All(result, item =>
                Assert.InRange(item.TemperatureC, -20, 55));
        }

        // Test pour s'assurer que la date est future
        [Fact]
        public void Get_ReturnsFutureDates()
        {
            // Act : appel de la m�thode Get
            var result = _controller.Get();

            // Assert : v�rifier que la date de chaque WeatherForecast est future
            Assert.All(result, item =>
                Assert.True(item.Date > DateOnly.FromDateTime(DateTime.Now)));
        }
    }
}
