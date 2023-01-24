using Microsoft.AspNetCore.Mvc;

namespace MySchool.Web.Controllers;
[Route("employee")]
public class EmployeeController : Controller
{
	[HttpGet("login")]
	public ViewResult Login()
	{
		return View("Login");
	}

	[HttpGet("register")]
	public ViewResult Register()
	{
		return View("register");
	}
}
