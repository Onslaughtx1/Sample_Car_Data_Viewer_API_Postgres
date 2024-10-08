using Microsoft.EntityFrameworkCore;
using static Sample_Car_Data_Viewer_API_Postgres.Server.CarsRepository;

namespace Sample_Car_Data_Viewer_API_Postgres.Server
{
    public class CarsRepository : ICarsRepository
    {
        public CarsRepository()
        {
            using (var context = new ApiContext())
            {
                var carsData = new List<CarsData>
                {
                        new CarsData
                        {
                            Id = 1,
                            Mileage = 1000,
                            Make = "Ford",
                            Model = "Mustang",
                            Fuel = "Petrol",
                            Gear = "Manual",
                            OfferType = "Used",
                            Hp = 100,
                            Year = 1999
                        },
                        new CarsData
                        {
                            Id = 2,
                            Mileage = 2000,
                            Make = "Dodge",
                            Model = "Challenger",
                            Fuel = "Petrol",
                            Gear = "Manual",
                            OfferType = "Used",
                            Hp = 200,
                            Year = 1969
                        },
                        new CarsData
                        {
                            Id = 3,
                            Mileage = 2000,
                            Make = "Chevrolet",
                            Model = "Camaro",
                            Fuel = "Petrol",
                            Gear = "Manual",
                            OfferType = "Used",
                            Hp = 300,
                            Year = 1974
                        }
                };
                context.CarsDataList.AddRange(carsData);
                context.SaveChanges();
            }
        }
        public List<CarsData> GetCarsData()
        {
            using (var context = new ApiContext())
            {
                var list = context.CarsDataList
                    //.Include(a => a.CarsData)
                    .ToList();
                return list;
            }
        }

    }
}
