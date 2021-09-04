using Core.Entities.Concrete;
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
        DbSet<User> Users { get; set; }
        DbSet<OperationClaim> OperationClaims { get; set; }
        DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = (localdb)\MSSQLLocalDB; Database = CarDB; Trusted_connection = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMapper());
            modelBuilder.Entity<Car>().Property(c => c.CarId).ValueGeneratedNever();
            modelBuilder.ApplyConfiguration(new EmployeeMapper());
            modelBuilder.Entity<Employee>().Property(c => c.EmployeeId).ValueGeneratedNever();
            modelBuilder.ApplyConfiguration(new ParkingSpaceMapper());
            modelBuilder.Entity<ParkingSpace>().Property(c => c.ParkingSpaceId).ValueGeneratedNever();
        }
    }

}
