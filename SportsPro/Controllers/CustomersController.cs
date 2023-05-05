using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using SportsPro.Models.Validation;

namespace SportsPro.Controllers
{
	public class CustomersController : Controller
	{
		private Repository<Customer> customerData { get; set; }
		private Repository<Country> countryData { get; set; }
		public CustomersController(SportsProFinalContext ctx)
		{
			customerData = new Repository<Customer>(ctx);
			countryData = new Repository<Country>(ctx);
		}

		public IActionResult Index()
		{
			var customers = customerData.List(new QueryOptions<Customer>
			{
				OrderBy = a => a.FirstName
			});
			return View(customers);
		}

		//ADD
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			ViewBag.Countries = countryData.List(new QueryOptions<Country>
			{
				OrderBy = a => a.CountryName
			});
			return View("Edit", new Customer());
		}


		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			ViewBag.Countries = countryData.List(new QueryOptions<Country>
			{
				OrderBy = a => a.CountryName
			});
			var c = this.GetCustomer(id);
			return View(c);
		}

		[HttpPost]
		public IActionResult Edit(Customer customer)
		{
			string msg = Validate.CheckCustomer(customerData, customer);
			if (!string.IsNullOrEmpty(msg))
			{
				ModelState.AddModelError(nameof(customer.Email), msg);
			}

			if (ModelState.IsValid)
			{
				if (customer.CustomerID == 0)
				{
					//Upsert = update insert
					//Adding a new contact
					customerData.Insert(customer);
				}
				else
				{
					//update
					customerData.Update(customer);
				}
				customerData.Save();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				//validation didnt pass
				ViewBag.Action = (customer.CustomerID == 0) ? "Add" : "Edit";
				ViewBag.Countries = countryData.List(new QueryOptions<Country>
				{
					OrderBy = a => a.CountryName
				});
				return View(customer);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var c = this.GetCustomer(id);
			return View(c);
		}

		[HttpPost]
		public IActionResult Delete(Customer customer)
		{
			customerData.Delete(customer);
			customerData.Save();
			return RedirectToAction("Index", "Home");
		}

		private Customer GetCustomer(int id)
		{
			var classOptions = new QueryOptions<Customer>
			{
				Where = c => c.CustomerID == id
			};
			return customerData.Get(classOptions) ?? new Customer();
		}
	}
}
