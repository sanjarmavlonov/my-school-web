using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using MySchool.Services.Interfaces;

namespace MySchool.Services.Service.Common;

public class IdentityService : IIdentityService
{
	private IHttpContextAccessor _accessor;

	public IdentityService(IHttpContextAccessor accessor)
	{
		_accessor = accessor;
	}
	public long? Id
	{
		get
		{
			var res = _accessor.HttpContext.User.FindFirst("Id");
			return res is not null ? long.Parse(res.Value) : null;
		}
	}

	public string Name
	{
		get
		{
			var res = _accessor.HttpContext.User.FindFirst("Name");
			return res is null ? string.Empty : res.Value;
		}
	}

	public string Email
	{
		get
		{
			var res = _accessor.HttpContext.User.FindFirst("Email");
			return res is null ? string.Empty : res.Value;
		}
	}
}
