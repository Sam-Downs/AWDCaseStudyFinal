using SportsPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsPro.Models.ViewModels;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private IRepository<Customer> customerData;
        private IRepository<Product> productData;

        public RegistrationController(SportsProFinalContext ctx)
        {
            customerData = new Repository<Customer>(ctx);
            productData = new Repository<Product>(ctx);
        }


        [HttpGet]
        public IActionResult GetCustomer()
        {
            var viewModel = new RegistrationViewModel
            {
                Customers = customerData.List(new QueryOptions<Customer>
                {
                    OrderBy = a => a.FirstName
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetCustomer(RegistrationViewModel viewModel)
        {
            if (viewModel.Customer.CustomerID == 0)
            {
                ModelState.AddModelError(nameof(viewModel.Customer.CustomerID), "You must select a customer.");
                viewModel.Customers = customerData.List(new QueryOptions<Customer>
                {
                    OrderBy = a => a.FirstName
                });

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", new { id = viewModel.Customer.CustomerID });
            }
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var vm = new RegistrationViewModel();

            vm.Customer = customerData.Get(new QueryOptions<Customer>
            {
                Includes = "Products",
                Where = c => c.CustomerID == id
            });

            vm.Products = productData.List(new QueryOptions<Product>
            {
                OrderBy = p => p.Name
            });

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(RegistrationViewModel model, int CustomerID)
        {
            var customer = customerData.Get(CustomerID);
            var product = productData.Get(model.Product.ProductId);

            if (!customer.Products.Contains(product))
            {
                customer.Products.Add(product);
                customerData.Save();
                TempData["message"] = $"{product.Name} was registered for {customer.FullName}";
            }
            else
            {
                TempData["message"] = $"{product.Name} is already registered for {customer.FullName}";
            }

            return RedirectToAction("Index", CustomerID);
        }
    }
}