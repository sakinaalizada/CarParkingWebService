using DataAccess.Concrete.EntityFrameWork.Mappers;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class CarParkingContext : DbContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<ParkingSpace> ParkingSpaces { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = (localdb)\MSSQLLocalDB; Database = CarDB; Trusted_connection = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMapper());
            modelBuilder.ApplyConfiguration(new EmployeeMapper());
            modelBuilder.ApplyConfiguration(new ParkingSpaceMapper());
        }
    }

}
