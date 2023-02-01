using Microsoft.EntityFrameworkCore;

namespace SP23.P01.Web.Data
{
    public class SeededData
    {
        public static void Initialize(IServiceProvider services)
        {
            //using (var scope = app.Services.CreateScope())
            //{
            //    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            //    dataContext.Database.Migrate();


            //    AddTrainStations(dataContext);
            //}


        }

        public static void AddTrainStations(DataContext dataContext)
        {
            var trainStations = dataContext.Set<TrainStation>();
            //if (trainStations.Any())
            //{
            //    return;
            //}


            trainStations.Add(new TrainStation
            {
                Name = "Hammond",
                Address = "Hammond, LA"
            });
            trainStations.Add(new TrainStation
            {
                Name = "NOLA",
                Address = "New Orleans, LA"
            });
            trainStations.Add(new TrainStation
            {
                Name = "Chicago",
                Address = "Chicago, IL"
            });


            dataContext.SaveChanges();
        }
        
    }
}
