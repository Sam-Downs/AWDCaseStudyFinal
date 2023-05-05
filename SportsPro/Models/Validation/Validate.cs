namespace SportsPro.Models.Validation
{
	public static class Validate
	{
		public static string CheckCustomer(Repository<Customer> CustomerData, Customer customer)
		{
			var dbCust = CustomerData.Get(new QueryOptions<Customer>
			{
				Where = c => c.Email == customer.Email && c.CustomerID != customer.CustomerID,
			});

			if (dbCust == null)
			{
				return "";
			}
			else
			{
				return $"{customer.Email} is already in use.";
			}
		}
	}
}
