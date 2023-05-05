using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SportsPro.Models
{
	internal class IncidentConfig : IEntityTypeConfiguration<Incident>
	{
		public void Configure(EntityTypeBuilder<Incident> entity)
		{
			entity.HasData(
				new Incident { IncidentId = 1, CustomerID = 1, ProductId = 1, TechnicianId = 1, Title = "Could not install", Description = "Program couldn't install", DateOpened = new DateTime(2019, 9, 1) },
				new Incident { IncidentId = 2, CustomerID = 4, ProductId = 3, TechnicianId = 3, Title = "Could not install", Description = "Big big problems it no install", DateOpened = new DateTime(2019, 9, 1) },
				new Incident { IncidentId = 3, CustomerID = 2, ProductId = 2, TechnicianId = 2, Title = "Error Launching Program", Description = "It doesn't launch!!", DateOpened = new DateTime(2019, 9, 1) },
				new Incident { IncidentId = 4, CustomerID = 5, ProductId = 2, TechnicianId = 1, Title = "Error Importing Data", Description = "NO IMPORT HELP!", DateOpened = new DateTime(2019, 9, 1) }
			);
		}
	}
}
