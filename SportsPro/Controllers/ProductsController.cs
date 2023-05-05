using SportsPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
	public class ProductsController : Controller
	{
		private IRepository<Product> productData;

		public ProductsController(SportsProFinalContext ctx)
		{
			productData = new Repository<Product>(ctx);
		}

		public IActionResult Index()
		{
			ViewBag.Message = TempData["message"];
			var products = productData.List(new QueryOptions<Product> { OrderBy = p => p.ReleaseDate }).ToList();
			return View(products);
		}

		//ADD
		[HttpGet]
		public ViewResult Add()
		{
			ViewBag.Message = TempData["message"];
			ViewBag.Action = "Add";
			return View("Edit", new Product());
		}

		//EDIT
		[HttpGet]
		public ViewResult Edit(int id)
		{
			ViewBag.Message = TempData["message"];
			ViewBag.Action = "Edit";
			var product = productData.Get(id);
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				if (product.ProductId == 0)
				{
					//Upsert = update insert
					//Adding a new contact
					productData.Insert(product);
					TempData["message"] = $"{product.Name} was added";
				}
				else
				{
					//update
					productData.Update(product);
					TempData["message"] = $"{product.Name} was Updated";
				}
				TempData[nameof(product.Name)] = product.Name;
				productData.Save();
				return RedirectToAction("Index", "Products");
			}
			else
			{
				//validation didn't pass
				ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
				return View(product);
			}
		}

		[HttpGet]
		public ViewResult Delete(int id)
		{
			Product product = productData.Get(id) ?? new Product();
			return View(product);
		}

		[HttpPost]
		public RedirectToActionResult Delete(Product product)
		{
			productData.Delete(product);
			productData.Save();
			TempData["message"] = $"{product.Name} was Deleted";
			return RedirectToAction("Index", "Products");
		}
	}
}
