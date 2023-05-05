using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SportsPro.Models
{
	internal class TechnicianConfig : IEntityTypeConfiguration<Technician>
	{
		public void Configure(EntityTypeBuilder<Technician> entity)
		{
			entity.HasData(
				new Technician { TechnicianId = -1, Name = "Assign a technician", Email = "", PhoneNumber = "" },
				new Technician { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", PhoneNumber = "800-555-0443" },
				new Technician { TechnicianId = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", PhoneNumber = "800-555-0449" },
				new Technician { TechnicianId = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", PhoneNumber = "800-555-0459" }
			);
		}
	}
}
