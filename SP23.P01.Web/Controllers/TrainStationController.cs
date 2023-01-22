using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SP23.P01.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainStationController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Hammond", "New Orleans", "Chicago", "New York", "San Francisco"
        };

        private static readonly string[] Addresses = new[]
        {
        "Hammond", "New Orleans", "Chicago", "New York", "San Francisco"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public TrainStationController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTrainStation")]
        public IEnumerable<TrainStation> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new TrainStation
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Address = Addresses[Random.Shared.Next(Addresses.Length)]
            })
            .ToArray();
        }
    }
}
