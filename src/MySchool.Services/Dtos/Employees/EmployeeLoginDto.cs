
using System.ComponentModel.DataAnnotations;

using MySchool.Services.Attributes;

namespace MySchool.Services.Dtos.Employees;

public class EmployeeLoginDto
{
	[Required, Email]
	public string Email { get; set; } = string.Empty;
	[Required, MaxLength(16, ErrorMessage = "Max Length 16"), MinLength(8, ErrorMessage = "Min Length 8")]
	public string Password { get; set; } = string.Empty;
}
