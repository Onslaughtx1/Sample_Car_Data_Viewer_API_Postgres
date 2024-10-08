using CsvHelper;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace Sample_Car_Data_Viewer_API_Postgres.Server
{
    public class ParseCsv
    {
        public void GetFirst10CarsFromCsv()
        {
            using (var reader = new StreamReader("\\autoscout24-germany-dataset.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CarsData>();
            }
        }
    }
}
