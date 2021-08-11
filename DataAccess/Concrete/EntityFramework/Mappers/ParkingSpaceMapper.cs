using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork.Mappers
{
    public class ParkingSpaceMapper : IEntityTypeConfiguration<ParkingSpace>
    {

        public void Configure(EntityTypeBuilder<ParkingSpace> builder)
        {
            builder.ToTable("ParkingSpaces");
            builder.HasKey(m => m.ParkingSpaceId);
            builder.Property(m => m.ParkingSpaceId).HasColumnName("ParkingSpaceId");
            builder.Property(m => m.ParkingSpaceAdress).HasColumnName("ParkingSpaceAdress");
            builder.Property(m => m.TotalNumberParkingSpots).HasColumnName("TotalNumberParkingSpots");
            builder.Property(m => m.ChargeForHour).HasColumnName("ChargeForHour");
        }
    }
}