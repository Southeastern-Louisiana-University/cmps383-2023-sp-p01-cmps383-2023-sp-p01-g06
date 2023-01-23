using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace SP23.P01.Web.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<WeatherForecast> Forecasts { get; set; }
    public DbSet<TrainStation> TrainStations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //This is where you make certain fields required

    }
}
