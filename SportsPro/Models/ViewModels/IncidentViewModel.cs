namespace SportsPro.Models.ViewModels
{
	public class IncidentViewModel
	{
		public Incident Incident { get; set; } = new Incident();
		public string Action { get; set; } = string.Empty;

		public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
		public IEnumerable<Product> Products { get; set; } = new List<Product>();
		public IEnumerable<Technician> Technicians { get; set; } = new List<Technician>();
	}
}
