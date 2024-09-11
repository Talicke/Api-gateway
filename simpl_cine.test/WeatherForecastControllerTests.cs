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
            // Création du mock pour ILogger
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();

            // Instanciation du contrôleur avec le mock du logger
            _controller = new WeatherForecastController(_loggerMock.Object);
        }

        // Test simple pour vérifier que Get retourne 5 WeatherForecasts
        [Fact]
        public void Get_ReturnsFiveWeatherForecasts()
        {
            // Act : appel de la méthode Get
            var result = _controller.Get();

            // Assert : vérification que le résultat contient bien 5 éléments
            Assert.NotNull(result); // Le résultat ne doit pas être nul
            Assert.Equal(5, result.Count()); // Il doit y avoir exactement 5 éléments

            // Vérifie que chaque élément a un Summary valide
            Assert.All(result, item =>
                Assert.Contains(item.Summary, WeatherForecastController.Summaries));
        }

        // Test pour vérifier que les températures sont dans la plage attendue
        [Fact]
        public void Get_ReturnsValidTemperatureRange()
        {
            // Act : appel de la méthode Get
            var result = _controller.Get();

            // Assert : vérifier que chaque élément a une température entre -20 et 55
            Assert.All(result, item =>
                Assert.InRange(item.TemperatureC, -20, 55));
        }

        // Test pour s'assurer que la date est future
        [Fact]
        public void Get_ReturnsFutureDates()
        {
            // Act : appel de la méthode Get
            var result = _controller.Get();

            // Assert : vérifier que la date de chaque WeatherForecast est future
            Assert.All(result, item =>
                Assert.True(item.Date > DateOnly.FromDateTime(DateTime.Now)));
        }
    }
}
