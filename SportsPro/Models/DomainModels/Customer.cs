using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SportsPro.Models
{
	public class Customer
	{
		// initialize navigation property collection in constructor
		public Customer() => Products = new HashSet<Product>();
		public int CustomerID { get; set; }

		[DisplayName("First Name")]
		[Required(ErrorMessage = "Please enter a First Name!")]
		[StringLength(51, MinimumLength = 1, ErrorMessage = "Please enter a First Name that fits length required message!")]
		[RegularExpression("^[a-z ,A-Z.'-]+$", ErrorMessage = "Valid Charactors include (A-Z) (a-z) (' space -)")]
		public string FirstName { get; set; } = string.Empty;

		[DisplayName("Last Name")]
		[Required(ErrorMessage = "Please enter a Last Name!")]
		[StringLength(51, MinimumLength = 1, ErrorMessage = "Please enter a last Name that fits length required message!")]
		[RegularExpression("^[a-z ,A-Z.'-]+$", ErrorMessage = "Valid Charactors include (A-Z) (a-z) (' space -)")]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter an Address!")]
		[StringLength(51, MinimumLength = 1)]
		public string Address { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a City!")]
		[StringLength(51, MinimumLength = 1)]
		public string City { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a State!")]
		[StringLength(51, MinimumLength = 1)]
		public string State { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a Postal Code!")]
		[StringLength(21, MinimumLength = 1)]
		[DisplayName("Postal Code")]
		public string PostalCode { get; set; } = string.Empty;
		[Phone]
		[RegularExpression("^\\s*(?:\\+?(\\d{1,3}))?[-. (]*(\\d{3})[-. )]*(\\d{3})[-. ]*(\\d{4})(?: *x(\\d+))?\\s*$", ErrorMessage = "Phone number is not valid!")]
		public string? Phone { get; set; }
		[EmailAddress]
		[Remote("CheckCustomer", "Validation")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Please enter a country!")]
		[DisplayName("Country")]
		public string? CountryId { get; set; } = string.Empty; //FK property

		[ValidateNever]
		public Country Country { get; set; } = null!;         //Navigation property

		public string FullName => FirstName + " " + LastName; //Read-only property

		public ICollection<Product> Products { get; set; }

		public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.ToString();
	}
}
