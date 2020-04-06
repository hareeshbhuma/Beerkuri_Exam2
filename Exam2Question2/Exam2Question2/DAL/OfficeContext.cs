using Exam2Question2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Exam2Question2.DAL
{
    public class OfficeContext : DbContext
    {

        public OfficeContext() : base("OfficeContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}