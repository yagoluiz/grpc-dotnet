using Grpc.Net.Client;
using Grpc.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Grpc.Client.Grpc
{
    public class WeatherForecastGrpc : IWeatherForecastGrpc
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherForecastGrpc> _logger;

        public WeatherForecastGrpc(
            IConfiguration configuration,
            ILogger<WeatherForecastGrpc> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<string> GetSummary(int temperatureC)
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",
                true);

            var host = _configuration["GrpcServiceHost"];

            _logger.LogInformation($"Host client: {host}");

            var channel = GrpcChannel.ForAddress(host);
            var client = new Summary.SummaryClient(channel);

            var reply = await client.SaySummaryAsync(new TemperatureRequest
            {
                Celsius = temperatureC
            });

            _logger.LogInformation($"Summary client: {reply.Summary}");

            return reply.Summary;
        }
    }
}
