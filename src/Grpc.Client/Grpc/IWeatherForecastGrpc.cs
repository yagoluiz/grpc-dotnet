using System.Threading.Tasks;

namespace Grpc.Client.Grpc
{
    public interface IWeatherForecastGrpc
    {
        Task<string> GetSummary(int temperatureC);
    }
}
