namespace MySchool.Web.Middlewares;

public class TokenRedirectMiddleware
{
	private readonly RequestDelegate _next;
	public TokenRedirectMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public Task InvokeAsync(HttpContext context)
	{
		if(context.Request.Cookies.TryGetValue("X-Access-Token", out var token))
		{
			if(!string.IsNullOrEmpty(token))
			{
				context.Request.Headers.Add("Authorization", $"Bearer {token}");
			}
		}
		return _next(context);
	}
}
