using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
	//[Route("Home/About")]
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
