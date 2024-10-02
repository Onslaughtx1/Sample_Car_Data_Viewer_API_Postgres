using Npgsql;
using System.Data;
using Dapper;

namespace Sample_Car_Data_Viewer_API_Postgres.Server
{
    public class DatabaseOperations
    {
        public List<CarsData> PgsqlConnection_GetCarsData()
        {
            var carsList = new List<CarsData>();

            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString: "Server=IP;Port=5432;User Id=postgres;Password=MyPassword!;Database=postgres;"))
            {
                string query = "SELECT * FROM cars.rawdata";
                dbConnection.Open();
                var carsListTest = dbConnection.Query<CarsData>(query).ToList();
                //return dbConnection.Query<CarsData>(query).ToList();
                return carsList;
            }
        }
    }
}
