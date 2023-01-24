using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MySchool.Services.Common.Utils;
using MySchool.Services.Interfaces.Services;

namespace MySchool.Web.Controllers
{
	[Route("students")]
	public class StudentsController : Controller
	{
		private readonly IStudentService _studentService;
		private readonly int _pageSize = 20;

		public StudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet("now")]
		[AllowAnonymous]
		public async Task<ViewResult> GetAllAsync(int page = 1)
		{
			var res = await _studentService.GetAllAsync(new PaginationParams(page, _pageSize));
			return View("Studying", res);
		}
	}
}
