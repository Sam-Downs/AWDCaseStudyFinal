using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SportsPro.Models
{
	public class Incident
	{
		public int IncidentId { get; set; }

		//RELATIONS WITH PRODUCTS, CUSTOMERS, TECHNICIANS
		// ------------------------------------------------------------------------ //

		[Required(ErrorMessage = "Please enter a Customer!")]
		public int? CustomerID { get; set; }                      //FK property

		[ValidateNever]
		public Customer Customer { get; set; } = null!;          //Navigation property

		[Required(ErrorMessage = "Please enter a Product!")]
		public int? ProductId { get; set; }                       //FK property

		[ValidateNever]
		public Product Product { get; set; } = null!;            //Navigation property

		[Required(ErrorMessage = "Please enter a Technician!")]
		public int? TechnicianId { get; set; }                    //FK property

		[ValidateNever]
		public Technician Technican { get; set; } = null!;       //Navigation property

		// ------------------------------------------------------------------------ //

		[Required(ErrorMessage = "Please enter a Title!")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a Description!")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter an Open Date!")]
		public DateTime DateOpened { get; set; } = DateTime.Now;

		public DateTime? DateClosed { get; set; } = null;

	}
}
