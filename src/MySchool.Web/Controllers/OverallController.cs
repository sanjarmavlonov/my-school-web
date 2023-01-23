using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Interfaces.Services;

namespace MySchool.Web.Controllers
{
	public class OverallController : Controller
	{
		private readonly IOverallService _overallService;

		public OverallController(IOverallService overallService)
		{
			_overallService = overallService;
		}

		[Route("")]
		public async Task<ViewResult> Index()
		{
			var overall = Ok(await _overallService.GetInfo());
			return View(overall);
		}
	}
}
