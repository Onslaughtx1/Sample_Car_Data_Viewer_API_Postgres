using Microsoft.EntityFrameworkCore;

namespace Sample_Car_Data_Viewer_API_Postgres.Server
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CarsData");
        }
        public DbSet<CarsData> CarsDataList { get; set; }

    }
}
