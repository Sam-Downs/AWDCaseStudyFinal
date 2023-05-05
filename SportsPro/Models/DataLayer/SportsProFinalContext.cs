using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DomainModels;

namespace SportsPro.Models
{
	public class SportsProFinalContext : IdentityDbContext<User>
    {
		public SportsProFinalContext(DbContextOptions<SportsProFinalContext> options) : base(options)
		{ }
		public DbSet<Product> Products { get; set; } = null!;

		public DbSet<Technician> Technicians { get; set; } = null!;

		public DbSet<Country> Countries { get; set; } = null!;

		public DbSet<Customer> Customers { get; set; } = null!;

		public DbSet<Incident> Incidents { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfig());
			modelBuilder.ApplyConfiguration(new TechnicianConfig());
			modelBuilder.ApplyConfiguration(new CountryConfig());
			modelBuilder.ApplyConfiguration(new CustomerConfig());
			modelBuilder.ApplyConfiguration(new IncidentConfig());
		}
	}
}
