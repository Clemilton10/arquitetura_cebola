using Microsoft.AspNetCore.Mvc;

namespace arq_cebola.Application.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
	}
}
