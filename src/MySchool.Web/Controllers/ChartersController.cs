using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MySchool.Services.Common.Utils;
using MySchool.Services.Interfaces.Services;

namespace MySchool.Web.Controllers
{
	[Route("charters")]
	public class ChartersController : Controller
	{
		private readonly ICharterService _charterService;
		private readonly int _pageSize = 20;

		public ChartersController(ICharterService charterService)
		{
			_charterService = charterService;
		}

		[HttpGet("")]
		[AllowAnonymous]
		public async Task<ViewResult> GetAllAsync(int page = 1)
		{
			var res = await _charterService.GetAll(new PaginationParams(page, _pageSize));
			return View("All", res);
		}
	}
}
