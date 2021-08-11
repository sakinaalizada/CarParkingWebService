using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork.Mappers
{
   public class CarMapper: IEntityTypeConfiguration<Car>
   {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(m => m.CarId);
            builder.Property(m => m.ArrivalTime).HasColumnName("ArrivalTime");
            builder.Property(m => m.DepartureTime).HasColumnName("DepartureTime");
            builder.Property(m => m.TotalTime).HasColumnName("TotalTime");
            builder.Property(m => m.CarId).HasColumnName("CarId");
            builder.Property(m => m.CarPlate).HasColumnName("CarPlate");
            builder.Property(m => m.TotalTime).HasColumnName("TotalTime");
            builder.Property(m => m.Status).HasColumnName("Status");
            builder.Property(m => m.ParkingSpaceId).HasColumnName("ParkingSpaceId");
        }
    }
}