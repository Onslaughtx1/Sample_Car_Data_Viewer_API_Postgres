namespace Sample_Car_Data_Viewer_API_Postgres.Server
{
    public class CarsData
    {
        public int? Id {  get; set; }
        public int? Mileage { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Fuel { get; set; }
        public string? Gear { get; set; }
        public string? OfferType { get; set; }
        public int? Hp { get; set; }
        public int? Year { get; set; }
    }
}
