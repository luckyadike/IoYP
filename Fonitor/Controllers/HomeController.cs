namespace Fonitor.Controllers
{
	using Fonitor.Filters;
	using System.Web.Http;
	using System.Web.Mvc;

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
	}
}
