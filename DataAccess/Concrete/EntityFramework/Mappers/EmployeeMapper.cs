using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameWork.Mappers
{
    public class EmployeeMapper : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(m => m.EmployeeId);
            builder.Property(m => m.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(m => m.EmployeeFirstName).HasColumnName("EmployeeFirstName");
            builder.Property(m => m.EmployeeLastName).HasColumnName("EmployeeLastName");
            builder.Property(m => m.EmployeeSalary).HasColumnName("EmployeeSalary");
            builder.Property(m => m.ParkingSpaceId).HasColumnName("ParkingSpaceId");
        }
    }
}
