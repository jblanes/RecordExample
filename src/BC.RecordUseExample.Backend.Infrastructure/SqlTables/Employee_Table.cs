using BC.RecordUseExample.Backend.Infrastructure.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BC.RecordUseExample.Backend.Infrastructure.SqlTables
{
    internal class Employee_Table : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> e)
        {
            e.ToTable("Employee", "Payroll");

            e.HasKey(p => p.Id);
            e.Property(p => p.Id).UseIdentityColumn();
        }
    }
}
