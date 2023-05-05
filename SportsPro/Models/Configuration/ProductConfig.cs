using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsPro.Models
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                new Product { ProductId = 1, Code = "TRNY10", Name = "Tournament Master 1.0", Price = 4.99M, ReleaseDate = new DateTime(2018, 12, 1) },
                new Product { ProductId = 2, Code = "LEAG10", Name = "League Scheduler 1.0", Price = 4.99M, ReleaseDate = new DateTime(2019, 5, 1) },
                new Product { ProductId = 3, Code = "LEAGD10", Name = "League Scheduler Deluxe 1.0", Price = 7.99M, ReleaseDate = new DateTime(2019, 9, 1) }
            );
        }
    }
}
