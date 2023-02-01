using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP23.P01.Web.Data;
using System.Linq;



namespace SP23.P01.Web.Controllers
{
    [Route("api/stations")]
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


        [HttpGet]
        public ActionResult<TrainStationDto[]> GetAll()
        {
            var trains = _dataContext.Set<TrainStation>();
            var results = trains.Select(x => new TrainStationDto
            {
                id = x.id,
                Name = x.Name,
                Address = x.Address,
            }).ToList();

            return Ok(results);
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<TrainStation> GetById(int id)
        {

            //This is the example they showed in class
            var trains = _dataContext.Set<TrainStation>();
            var result = trains.Where(x => x.id == id).Select(x => new TrainStationDto
            {
                id = x.id,
                Name = x.Name,
                Address = x.Address,
            }).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }


            //My old way of doing it
            //if (id <= 0)
            //{
            //    return NotFound();
            //}

            //if (id > _dataContext.TrainStations.Count())
            //{
            //    return NotFound();
            //}

            //var trainStationToReturn = _dataContext
            //    .TrainStations
            //    .Select(x => new TrainStation
            //    {
            //    id = x.id,
            //    Name = x.Name,
            //    Address = x.Address
            //    })
            //    .FirstOrDefault(x => x.id == id);


            //return Ok(trainStationToReturn);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<TrainStation> Create(TrainStationDto trainStationToCreate)
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



            if (trainStationToCreate.Name.Length >= 120)
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

            var trainStationToReturn = new TrainStationDto
            {
                id = trainStationToAdd.id,
                Name = trainStationToAdd.Name,
                Address = trainStationToAdd.Address
            };


            return CreatedAtAction(nameof(GetById), new { id = trainStationToReturn.id }, trainStationToReturn);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var trainStationToDelete = _dataContext
                .TrainStations
                .FirstOrDefault(x => x.id == id);
            if (trainStationToDelete == null)
            {
                return NotFound();
            }
            _dataContext.TrainStations.Remove(trainStationToDelete);
            _dataContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] TrainStationDto trainStation)
        {
            if (trainStation == null)
            {
                return NotFound();
            }

            var trainStationToUpdate = _dataContext.TrainStations.FirstOrDefault(x => x.id == id);

            if (trainStationToUpdate == null)
            {
                return NotFound();
            }

            if (trainStation.Name == null || trainStation.Name == "")
            {
                return NotFound();
            }

            if (trainStation.Name.Length >= 120)
            {
                return BadRequest(400);
            }

            if (trainStation.Address == null || trainStation.Address == "")
            {
                return NotFound();
            }

            trainStationToUpdate.Name = trainStation.Name;
            trainStationToUpdate.Address = trainStation.Address;

            _dataContext.SaveChanges();

            return Ok(trainStationToUpdate);


        }
    }
}
