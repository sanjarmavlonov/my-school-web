using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Common.Utils;
using MySchool.Services.Interfaces.Services;

namespace MySchool.Web.Controllers
{
	public class AllStudentsController : Controller
	{
		private readonly IStudentService _studentService;
		private readonly int _pageSize = 20;

		public AllStudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet("")]
		[AllowAnonymous]
		public async Task<ViewResult> GetAllAsync(int page = 1)
		{
			var res = Ok(await _studentService.GetAllAsync(new PaginationParams(page, _pageSize)));
			return View(res);
		}
	}
}
