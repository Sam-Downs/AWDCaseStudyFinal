using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.Models.ViewModels;

namespace SportsPro.Controllers
{
	public class IncidentsController : Controller
	{
		private IRepository<Incident> incidentRepo;
		private IRepository<Customer> customerRepo;
		private IRepository<Product> productRepo;
		private IRepository<Technician> technicianRepo;
		private IRepository<Country> countryRepo;

		public IncidentsController(SportsProFinalContext ctx)
		{
			incidentRepo = new Repository<Incident>(ctx);
			customerRepo = new Repository<Customer>(ctx);
			productRepo = new Repository<Product>(ctx);
			technicianRepo = new Repository<Technician>(ctx);
			countryRepo = new Repository<Country>(ctx);
		}

		[Route("[controller]s/{id?}")]
		public IActionResult Index(string id = "all")
		{
			List<Incident> incidents;
			if (id == "all")
			{
				incidents = (List<Incident>)incidentRepo.List(new QueryOptions<Incident>
				{
					OrderBy = a => a.Title
				});
			}
			else if (id == "unassigned")
			{
				incidents = incidentRepo.List(new QueryOptions<Incident> { Where = i => i.TechnicianId == -1 })
					.OrderBy(i => i.Title).ToList();
			}
			else if (id == "open")
			{
				incidents = incidentRepo.List(new QueryOptions<Incident> { Where = i => i.DateClosed == null })
					.OrderBy(i => i.Title).ToList();
			}
			else
			{
				incidents = (List<Incident>)incidentRepo.List(new QueryOptions<Incident>
				{
					OrderBy = a => a.Title
				});
			}
			ViewBag.SelectedFilter = id;

			ViewBag.Customers = customerRepo.List(new QueryOptions<Customer>
			{
				OrderBy = a => a.FirstName
			});

			ViewBag.Products = productRepo.List(new QueryOptions<Product>
			{
				OrderBy = a => a.Name
			});

			// Assuming you have a countryRepo for countries
			ViewBag.Countries = countryRepo.List(new QueryOptions<Country>
			{
				OrderBy = a => a.CountryName
			});


			ViewBag.Technicians = technicianRepo.List(new QueryOptions<Technician>
			{
				OrderBy = a => a.Name
			});

			return View(incidents);
		}

		//ADD
		[HttpGet]
		public IActionResult Add()
		{
			var model = new IncidentViewModel
			{
				Incident = new Incident(),
				Customers = customerRepo.List(new QueryOptions<Customer>
				{
					OrderBy = a => a.FirstName
				}),

				Products = productRepo.List(new QueryOptions<Product>
				{
					OrderBy = a => a.Name
				}),

				Technicians = technicianRepo.List(new QueryOptions<Technician>
				{
					OrderBy = a => a.Name
				}),

				Action = "Add"
			};
			return View(model);
		}

		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var model = new IncidentViewModel
			{
				Incident = GetIncident(id)!,
				Customers = customerRepo.List(new QueryOptions<Customer>
				{
					OrderBy = a => a.FirstName
				}),

				Products = productRepo.List(new QueryOptions<Product>
				{
					OrderBy = a => a.Name
				}),

				Technicians = technicianRepo.List(new QueryOptions<Technician>
				{
					OrderBy = a => a.Name
				}),
				Action = "Edit"
			};
			if (model.Incident == null)
			{
				model.Incident = new Incident();
				model.Incident.IncidentId = id;
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(IncidentViewModel model)
		{
			model.Action = (model.Incident.IncidentId == 0) ? "Add" : "Edit";
			model.Technicians = technicianRepo.List(new QueryOptions<Technician>
			{
				OrderBy = a => a.Name
			});

			model.Customers = customerRepo.List(new QueryOptions<Customer>
			{
				OrderBy = a => a.FirstName
			});

			model.Products = productRepo.List(new QueryOptions<Product>
			{
				OrderBy = a => a.Name
			});

			if (ModelState.IsValid)
			{
				if (model.Incident.IncidentId == 0)
				{
					//Upsert = update insert
					//Adding a new contact
					incidentRepo.Insert(model.Incident);
				}
				else
				{
					//update
					incidentRepo.Update(model.Incident);
				}
				incidentRepo.Save();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				//validation didnt pass
				model.Action = (model.Incident.IncidentId == 0) ? "Add" : "Edit";
				model.Technicians = technicianRepo.List(new QueryOptions<Technician>
				{
					OrderBy = a => a.Name
				});

				model.Customers = customerRepo.List(new QueryOptions<Customer>
				{
					OrderBy = a => a.FirstName
				});

				model.Products = productRepo.List(new QueryOptions<Product>
				{
					OrderBy = a => a.Name
				});
				return View(model);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var incident = GetIncident(id);
			ViewBag.Customers = customerRepo.List(new QueryOptions<Customer>
			{
				OrderBy = a => a.FirstName
			});
			return View(incident);
		}

		[HttpPost]
		public IActionResult Delete(Incident incident)
		{
			incidentRepo.Delete(incident);
			incidentRepo.Save();
			return RedirectToAction("Index", "Home");
		}

		private Incident GetIncident(int id)
		{
			var classOptions = new QueryOptions<Incident>
			{
				Where = c => c.IncidentId == id
			};
			return incidentRepo.Get(classOptions) ?? new Incident();
		}
	}
}
