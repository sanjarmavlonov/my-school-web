using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services.Common.Validations;

public class PasswordValidator
{
	public static (bool IsValid, string Message) IsStrong(string password)
	{
		bool isDigit = password.Any(x => char.IsDigit(x));
		bool isLower = password.Any(x => char.IsLower(x));
		bool isUpper = password.Any(x => char.IsUpper(x));
		if (!isLower)
			return (IsValid: false, Message: "Parolda hech bo'lmaganda 1 ta kichik harf bo'lishi kerak!");
		if (!isUpper)
			return (IsValid: false, Message: "Parolda hech bo'lmaganda 1 ta katta harf bo'lishi kerak!");
		if (!isDigit)
			return (IsValid: false, Message: "Parolda hech bo'lmaganda 1 ta raqam bo'lishi kerak!");

		return (IsValid: true, Message: "Parol to'g'ri");
	}
}
