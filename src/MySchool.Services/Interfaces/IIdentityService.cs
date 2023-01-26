namespace MySchool.Services.Interfaces;

public interface IIdentityService
{
	public long? Id { get; }
	public string Name { get; }
	public string Email { get; }
}
