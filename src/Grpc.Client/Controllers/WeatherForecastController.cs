using Grpc.Client.Grpc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.Client.Controllers
{
    [ApiController]
    [Route("weather-forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastGrpc _weatherForecastGrpc;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastGrpc weatherForecastGrpc)
        {
            _logger = logger;
            _weatherForecastGrpc = weatherForecastGrpc;
        }

        [HttpGet("temperature/celsius/{temperatureC:int}")]
        public async Task<IEnumerable<WeatherForecast>> Get(int temperatureC)
        {
            var summary = await _weatherForecastGrpc.GetSummary(temperatureC);

            var rng = new Random();
            return Enumerable.Range(1, 3)
                .Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = temperatureC,
                    Summary = summary
                })
                .ToArray();
        }
    }
}
