using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SportsPro.Models
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
                new Customer { CustomerID = 1, FirstName = "Margareta", LastName = "Burgan", Address = "631 Ronald Regan Plaza", City = "Bronx", State = "New York", PostalCode = "10459", Phone = "917-364-9317", Email = "mburgan0@chicagotribune.com", CountryId = "J" },
                new Customer { CustomerID = 2, FirstName = "Sayre", LastName = "Pill", Address = "405 Hovde Trail", City = "Cleveland", State = "Ohio", PostalCode = "44111", Phone = "216-296-3042", Email = "spill1@gnu.org", CountryId = "J" },
                new Customer { CustomerID = 3, FirstName = "Gwendolen", LastName = "Ducker", Address = "031 Carberry Hil", City = "Dallas", State = "Texas", PostalCode = "75210", Phone = "214-852-3962", Email = "gducker2@clickbank.net", CountryId = "J" },
                new Customer { CustomerID = 4, FirstName = "Pearl", LastName = "Capron", Address = "161 Blackbird Alley", City = "San Diego", State = "California", PostalCode = "92165", Phone = "619-937-1709", Email = "pcapron3@amazon.co.jp", CountryId = "J" },
                new Customer { CustomerID = 5, FirstName = "Inger", LastName = "Haire", Address = "04860 Moulton Trail", City = "Grand Rapids", State = "Michigan", PostalCode = "49505", Phone = "616-432-4014", Email = "ihaire4@independent.co.uk", CountryId = "J" }
            );
        }
    }
}
