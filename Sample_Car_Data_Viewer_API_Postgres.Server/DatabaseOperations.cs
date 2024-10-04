using Npgsql;
using System.Data;
using Dapper;
using System.Text.Json;

namespace Sample_Car_Data_Viewer_API_Postgres.Server
{
    public class DatabaseOperations
    {
        public List<CarsData> PgsqlConnection_GetCarsData()
        {
            //Instantiate a new instance of List<CarData>
            var carsList = new List<CarsData>();

            //Create a valid connection string
            var connectionStringBuilder = File.ReadLines(@"C:/Temp/ConnectionString.txt").First();

            //Use the valid Conn String to 
            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString: connectionStringBuilder))
            {
                //Select all records from DB
                string query = "SELECT * FROM cars.rawdata";

                dbConnection.Open();
                var carsListTest = dbConnection.Query<CarsData>(query).ToList();

                return carsListTest;
            }
        }

        public string PgsqlConnection_GetFirstTenCarsData()
        {
            //Instantiate a new instance of List<CarData>
            var carsList = new List<CarsData>();

            //Create a valid connection string
            var connectionStringBuilder = File.ReadLines(@"C:/Temp/ConnectionString.txt").First();

            //Use the valid Conn String to 
            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString: connectionStringBuilder))
            {
                //Select all records from DB
                //string query = "SELECT * FROM cars.rawdata";

                //Select 10 for better efficiency
                string query = "SELECT * FROM cars.rawdata ORDER BY id LIMIT 10;";

                dbConnection.Open();
                var carsListTest = dbConnection.Query<CarsData>(query).ToList();

                //Create Options for Sewrialiser
                var options = new JsonSerializerOptions { WriteIndented = true };

                //Use if applying to FULL list
                //var carsListJson = JsonSerializer.Serialize(carsListTest.Take(10), options);

                //Otherwise serialise the 10
                var carsListJson = JsonSerializer.Serialize(carsListTest, options);

                return carsListJson;
            }
        }
    }
}
