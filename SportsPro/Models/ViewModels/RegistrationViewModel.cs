using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models.ViewModels
{
	public class RegistrationViewModel
	{
		[Required(ErrorMessage = "Please select a customer")]
		public Customer Customer { get; set; } = null!;
		public Product Product { get; set; } = null!;
		public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
		public IEnumerable<Product> Products { get; set; } = new List<Product>();
	}
}
