using Microsoft.AspNetCore.Mvc;

using MySchool.Services.Interfaces;
using MySchool.Services.ViewModels.Employees;

namespace MySchool.Web.ViewComponents;

public class AccountViewComponent : ViewComponent
{
	private readonly IIdentityService _identity;

	public AccountViewComponent(IIdentityService identity)
	{
		_identity = identity;
	}
	public IViewComponentResult Invoke()
	{
		EmployeeShortViewModel viewModel;
		if(_identity.Id.HasValue)
		{
			viewModel = new EmployeeShortViewModel()
			{
				Id = (long)_identity.Id,
				Email = _identity.Email,
				Name = _identity.Name,
			};
		}
		else
		{
			viewModel = new EmployeeShortViewModel()
			{
				Id = 0,
				Email = "",
				Name = "Log In"
			};
		}
		return View(viewModel);
	}
}
