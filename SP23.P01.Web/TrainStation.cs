using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace SP23.P01.Web
{
    //Integers are already required by Entity Framework, String are by default nullable
    public class TrainStation
    {
        public int id { get;set; }
        public string Name { get;set; }
        public string Address { get; set; }

    }

    public class TrainStationCreateDto
    {
        //This is another way of doing OnModelBuilding that is in the DataContext class
        //I left this here as an example
        //[Required, MaxLength(120)]
        public string Name { get; set; }
        //[Required]
        public string Address { get; set; }
    }

    public class TrainStationDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set;}
    }


    //This is something he showed in class that is not required for P01, but may be useful or helpful for configuring the TrainStation later
    
    //This is important to make configurations work, do for each class
    public class TrainStationConfiguration : IEntityTypeConfiguration<TrainStation>
    {
        public void Configure(EntityTypeBuilder<TrainStation> builder)
        {
            builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(120);

            builder
                .Property(x => x.Address)
                .IsRequired();
        }
    }


}
