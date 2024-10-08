namespace Sample_Car_Data_Viewer_API_Postgres.Server
{
    public interface ICarsRepository
    {
        public List<CarsData> GetCarsData();
        
    }
}
