using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Common.Utils;
using MySchool.Services.Interfaces.Services;

namespace MySchool.Web.Controllers
{
	public class AllChartersController : Controller
	{
		private readonly ICharterService _charterService;
		private readonly int _pageSize = 20;

		public AllChartersController(ICharterService charterService)
		{
			_charterService = charterService;
		}

		[HttpGet("")]
		[AllowAnonymous]
		public async Task<ViewResult> GetAllAsync(int page = 1)
		{
			var res =  Ok(await _charterService.GetAll(new PaginationParams(page, _pageSize)));
			return View(res);
		}
	}
}
