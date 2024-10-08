using Microsoft.AspNetCore.Mvc;

namespace Sample_Car_Data_Viewer_API_Postgres.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[Produces("application/json")]
    public class CarsDataController : ControllerBase
    {
        private readonly ILogger<CarsDataController> _logger;
        readonly ICarsRepository _carsRepository;
        public CarsDataController(ILogger<CarsDataController> logger, ICarsRepository carsRepository)
        {
            _logger = logger;
            _carsRepository = carsRepository;
        }

        [HttpGet(Name = "GetCarList")]
        public ActionResult<IEnumerable<CarsData>> GetAllCars()
        {
            var dbOps = new DatabaseOperations();
            var cars = dbOps.PgsqlConnection_GetCarsData();

            return cars;
        }

        [HttpGet(Name = "GetFirstTenCarsFromList")]
        public string GetFirstTenCars()
        {
            var dbOps = new DatabaseOperations();
            var cars = dbOps.PgsqlConnection_GetFirstTenCarsData();

            return cars;
        }


        [HttpGet(Name = "GetFirstTenCarsInMemory")]
        public ActionResult<List<CarsData>> GetCarsFromMemory()
        {
            return Ok(_carsRepository.GetCarsData());
        }
    }
}
