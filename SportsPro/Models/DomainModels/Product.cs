using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SportsPro.Models
{
    public class Product
    {
        public Product() => Customers = new HashSet<Customer>();

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a Product Code!")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Product Name!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Product Price!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a Product Release Date!")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public ICollection<Customer> Customers { get; set; }
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Code?.ToString();

    }
}
