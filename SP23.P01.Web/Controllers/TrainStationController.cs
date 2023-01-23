using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP23.P01.Web.Data;
using System.Linq;



namespace SP23.P01.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainStationController : ControllerBase
    {
        private DataContext _dataContext;

        private readonly ILogger<TrainStationController> _logger;
        public TrainStationController(DataContext dataContext, ILogger<TrainStationController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        private static readonly string[] Names = new[]
        {
        "Hammond", "New Orleans", "Chicago", "New York", "San Francisco"
        };

        private static readonly string[] Addresses = new[]
        {
        "Hammond", "New Orleans", "Chicago", "New York", "San Francisco"
        };


        [HttpGet(Name = "GetRandomTrainStation")]
        public IEnumerable<TrainStation> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new TrainStation
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Address = Addresses[Random.Shared.Next(Addresses.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id:int}", Name = "GetStationById")]
        public ActionResult<TrainStation> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (id > _dataContext.TrainStations.Count())
            {
                return BadRequest();
            }

            var trainStationToReturn = _dataContext
                .TrainStations
                .Select(x => new TrainStation
                {
                id = x.id,
                Name = x.Name,
                Address = x.Address
                })
                .FirstOrDefault(x => x.id == id);
            

            

            return Ok(trainStationToReturn);

        }


        [HttpPost]
        public ActionResult<TrainStation> Create([FromBody] TrainStationCreateDto trainStationToCreate)
        {
            if (trainStationToCreate.Name == "" || trainStationToCreate.Name == null)
            {
                return BadRequest(400);
            }


            var alreadyExists = _dataContext.TrainStations.Any(x => x.Name == trainStationToCreate.Name);

            if (alreadyExists)
            {
                return BadRequest(400);
            }



            if (trainStationToCreate.Name.Length > 120)
            {
                return BadRequest(400);
            }

            if (trainStationToCreate.Address == "" || trainStationToCreate.Address == null)
            {
                return BadRequest(400);
            }

            var trainStationToAdd = new TrainStation
            {
                Name = trainStationToCreate.Name,
                Address = trainStationToCreate.Address,
            };

            _dataContext.TrainStations.Add(trainStationToAdd);
            _dataContext.SaveChanges();

            var trainStationToReturn = new TrainStation
            {
                id = trainStationToAdd.id,
                Name = trainStationToAdd.Name,
                Address = trainStationToAdd.Address
            };


            return Created("api/TrainStation/" + trainStationToAdd.id, trainStationToAdd.Name);
        }
    }
}
