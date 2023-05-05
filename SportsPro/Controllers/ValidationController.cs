using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using SportsPro.Models.Validation;

namespace SportsPro.Controllers
{
	public class ValidationController : Controller
	{
		private IRepository<Customer> customerData;

		public ValidationController(SportsProFinalContext ctx)
		{
			customerData = new Repository<Customer>(ctx);
		}

		public JsonResult CheckCustomer(string email)
		{
			Customer customer = new Customer { Email = email };

			string msg = Validate.CheckCustomer((Repository<Customer>)customerData, customer);

			if (string.IsNullOrEmpty(msg))
			{
				// customer already exists, do something
				return Json(true);
			}
			else
			{
				// customer does not exist, do something else
				return Json(msg);
			}
		}
	}
}
