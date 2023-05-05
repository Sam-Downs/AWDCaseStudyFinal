using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
	public class TechniciansController : Controller
	{
		private IRepository<Technician> technicianData;

		public TechniciansController(SportsProFinalContext ctx)
		{
			technicianData = new Repository<Technician>(ctx);
		}

		public IActionResult Index()
		{
			var technicians = technicianData.List(new QueryOptions<Technician> { OrderBy = t => t.Name }).ToList();
			return View(technicians);
		}

		//ADD
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Technician());
		}

		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var technician = technicianData.Get(id);
			return View(technician);
		}

		[HttpPost]
		public IActionResult Edit(Technician technician)
		{
			if (ModelState.IsValid)
			{
				if (technician.TechnicianId == 0)
				{
					//Upsert = update insert
					//Adding a new contact
					technicianData.Insert(technician);
				}
				else
				{
					//update
					technicianData.Update(technician);
				}
				technicianData.Save();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				//validation didnt pass
				ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
				return View(technician);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var technician = technicianData.Get(id);
			return View(technician);
		}

		[HttpPost]
		public IActionResult Delete(Technician technician)
		{
			technicianData.Delete(technician);
			technicianData.Save();
			return RedirectToAction("Index", "Home");
		}
	}
}
