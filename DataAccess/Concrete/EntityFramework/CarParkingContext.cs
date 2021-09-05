using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFrameWork.Mappers;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class CarParkingContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
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
