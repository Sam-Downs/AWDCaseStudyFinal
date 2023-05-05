using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SportsPro.Models
{
	internal class CountryConfig : IEntityTypeConfiguration<Country>
	{
		public void Configure(EntityTypeBuilder<Country> entity)
		{
			entity.HasData(
				new Country { CountryId = "US", CountryName = "United States" },
				new Country { CountryId = "NK", CountryName = "North Korea" },
				new Country { CountryId = "I", CountryName = "Iceland" },
				new Country { CountryId = "UK", CountryName = "United Kingdom" },
				new Country { CountryId = "J", CountryName = "Japan" }
			);
		}
	}
}
