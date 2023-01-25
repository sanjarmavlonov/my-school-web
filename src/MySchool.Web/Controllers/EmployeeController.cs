using Microsoft.AspNetCore.Mvc;

using MySchool.Services.Dtos.Employees;
using MySchool.Services.Interfaces.Services;

namespace MySchool.Web.Controllers;
[Route("employee")]
public class EmployeeController : Controller
{
	private readonly IEmployeeService _service;

	public EmployeeController(IEmployeeService service)
	{
		_service = service;
	}

	[HttpGet("login")]
	public ViewResult Login()
	{
		return View("Login");
	}

	[HttpGet("register")]
	public ViewResult Register()
	{
		return View("Register");
	}
	[HttpPost("register")]
	public async Task<IActionResult> Register(EmployeeRegisterDto dto)
	{
		if(ModelState.IsValid)
			if(await _service.RegisterAsync(dto))
				return RedirectToAction("login", "employee", new { area = "" });
			else
				return RedirectToAction("register", "employee", new { area = "" });
		else
			return RedirectToAction("register", "employee", new { area = "" });
	}
	[HttpPost("login")]
	public async Task<IActionResult> Login(EmployeeLoginDto dto)
	{
		if(ModelState.IsValid)
		{
			try
			{
				var token = await _service.LoginAsync(dto);
				HttpContext.Response.Cookies.Append("X-Access-Token", token);
				return RedirectToAction("", "overall");
			}
			catch
			{
				return Login();
			}
		}
		else
		{
			return Login();
		}
	}
}
