using Microsoft.EntityFrameworkCore;

namespace DWAS_T2111E_MaiHuyHoat.Models
{
    public class PracDBContext : DbContext
    {
        public PracDBContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.EmployeeId, pe.ProjectId});
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
