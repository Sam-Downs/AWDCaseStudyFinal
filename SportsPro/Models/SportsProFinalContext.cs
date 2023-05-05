//using Microsoft.EntityFrameworkCore;
//using SportsPro.Models;
//namespace SportsPro.Models
//{
//	public class SportsProContext : DbContext
//	{
//		public SportsProContext(DbContextOptions<SportsProContext> options) : base(options)
//		{ }

//		public DbSet<Product> Products { get; set; } = null!;

//		public DbSet<Technician> Technicians { get; set; } = null!;

//		public DbSet<Customer> Customers { get; set; } = null!;

//		public DbSet<Country> Countries { get; set; } = null!;

//		public DbSet<Incident> Incidents { get; set; } = null!;


//		protected override void OnModelCreating(ModelBuilder modelBuilder)
//		{
//			modelBuilder.Entity<Product>().HasData(
//				new Product { ProductId = 1, Code = "TRNY10", Name = "Tournament Master 1.0", Price = 4.99M, ReleaseDate = new DateTime(2018, 12, 1) },
//				new Product { ProductId = 2, Code = "LEAG10", Name = "League Scheduler 1.0", Price = 4.99M, ReleaseDate = new DateTime(2019, 5, 1) },
//				new Product { ProductId = 3, Code = "LEAGD10", Name = "League Scheduler Deluxe 1.0", Price = 7.99M, ReleaseDate = new DateTime(2019, 9, 1) }
//				);

//			modelBuilder.Entity<Technician>().HasData(
//				new Technician { TechnicianId = -1, Name = "Assign a technician", Email = "", PhoneNumber = "" },
//				new Technician { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", PhoneNumber = "800-555-0443" },
//				new Technician { TechnicianId = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", PhoneNumber = "800-555-0449" },
//				new Technician { TechnicianId = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", PhoneNumber = "800-555-0459" }
//				);

//			modelBuilder.Entity<Country>().HasData(
//				new Country { CountryId = "US", CountryName = "United States" },
//				new Country { CountryId = "NK", CountryName = "North Korea" },
//				new Country { CountryId = "I", CountryName = "Iceland" },
//				new Country { CountryId = "UK", CountryName = "United Kingdom" },
//				new Country { CountryId = "J", CountryName = "Japan" }
//				);

//			modelBuilder.Entity<Customer>().HasData(
//				new Customer { CustomerID = 1, FirstName = "Margareta", LastName = "Burgan", Address = "631 Ronald Regan Plaza", City = "Bronx", State = "New York", PostalCode = "10459", Phone = "917-364-9317", Email = "mburgan0@chicagotribune.com", CountryId = "J" },
//				new Customer { CustomerID = 2, FirstName = "Sayre", LastName = "Pill", Address = "405 Hovde Trail", City = "Cleveland", State = "Ohio", PostalCode = "44111", Phone = "216-296-3042", Email = "spill1@gnu.org", CountryId = "J" },
//				new Customer { CustomerID = 3, FirstName = "Gwendolen", LastName = "Ducker", Address = "031 Carberry Hil", City = "Dallas", State = "Texas", PostalCode = "75210", Phone = "214-852-3962", Email = "gducker2@clickbank.net", CountryId = "J" },
//				new Customer { CustomerID = 4, FirstName = "Pearl", LastName = "Capron", Address = "161 Blackbird Alley", City = "San Diego", State = "California", PostalCode = "92165", Phone = "619-937-1709", Email = "pcapron3@amazon.co.jp", CountryId = "J" },
//				new Customer { CustomerID = 5, FirstName = "Inger", LastName = "Haire", Address = "04860 Moulton Trail", City = "Grand Rapids", State = "Michigan", PostalCode = "49505", Phone = "616-432-4014", Email = "ihaire4@independent.co.uk", CountryId = "J" }
//				);

//			modelBuilder.Entity<Incident>().HasData(
//				new Incident { IncidentId = 1, CustomerID = 1, ProductId = 1, TechnicianId = 1, Title = "Could not install", Description = "Program couldn't install", DateOpened = new DateTime(2019, 9, 1) },
//				new Incident { IncidentId = 2, CustomerID = 4, ProductId = 3, TechnicianId = 3, Title = "Could not install", Description = "Big big problems it no install", DateOpened = new DateTime(2019, 9, 1) },
//				new Incident { IncidentId = 3, CustomerID = 2, ProductId = 2, TechnicianId = 2, Title = "Error Launching Program", Description = "It doesn't launch!!", DateOpened = new DateTime(2019, 9, 1) },
//				new Incident { IncidentId = 4, CustomerID = 5, ProductId = 2, TechnicianId = 1, Title = "Error Importing Data", Description = "NO IMPORT HELP!", DateOpened = new DateTime(2019, 9, 1) }
//				);

//		}
//	}
//}
