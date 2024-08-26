using BC.RecordUseExample.Backend.Infrastructure.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BC.RecordUseExample.Backend.Infrastructure
{
    public class SqlDbContext(DbContextOptions<SqlDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlDbContext).Assembly);
        }
    }
}
