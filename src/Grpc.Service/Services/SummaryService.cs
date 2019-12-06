using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Grpc.Service
{
    public class SummaryService : Summary.SummaryBase
    {
        private readonly ILogger<SummaryService> _logger;

        public SummaryService(ILogger<SummaryService> logger)
        {
            _logger = logger;
        }

        public override Task<SummaryReply> SaySummary(TemperatureRequest request, ServerCallContext context)
        {
            var summary = new SummaryReply
            {
                Summary = GetSummary(request.Celsius)
            };

            _logger.LogInformation($"Summary service: {summary}");

            return Task.FromResult(summary);
        }

        private static string GetSummary(int temperature) =>
            temperature switch
            {
                var temp when (temp <= 0) => "Freezing",
                var temp when (temp <= 10) => "Cool",
                var temp when (temp <= 20) => "Balmy",
                var temp when (temp <= 30) => "Hot",
                var temp when (temp <= 40) => "Sweltering",
                _ => "Scorching"
            };
    }
}
