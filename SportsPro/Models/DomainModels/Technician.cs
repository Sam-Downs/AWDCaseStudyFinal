using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
	public class Technician
	{
		public int TechnicianId { get; set; }
		
		[Required(ErrorMessage = "Please enter a Technician Name!")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a Technician Email!")]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a Technician Phone Number!")]
		[Phone]
		public string PhoneNumber { get; set; } = string.Empty;

		public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Email?.ToString();
	}
}
