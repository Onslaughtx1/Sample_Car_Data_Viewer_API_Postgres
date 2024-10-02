using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample_Car_Data_Viewer_API_Postgres.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsDataController : ControllerBase
    {
        private readonly ILogger<CarsDataController> _logger;

        public CarsDataController(ILogger<CarsDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCarList")]
        public ActionResult<IEnumerable<CarsData>> GetCars()
        {
            var dbOps = new DatabaseOperations();
            var cars = dbOps.PgsqlConnection_GetCarsData();
            //var jsonString = JsonSerializer.Serialize(cars);
            //retirn jsonString;
            return cars;
        }
    }
}
