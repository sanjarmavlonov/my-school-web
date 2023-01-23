using MySchool.Services.Common.Helpers;
using MySchool.Services.Common.Security;
using MySchool.Services.Interfaces.Common;
using MySchool.Services.Interfaces.Services;
using MySchool.Services.Service.Common;
using MySchool.Services.Service;
using My_School.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ICasher, Casher>();
builder.Services.AddScoped<IDtoHelper, DtoHelper>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IHasher, Hasher>();
builder.Services.AddScoped<IPaginatorService, PaginatorService>();
builder.Services.AddScoped<IConfirmationService, ConfirmationService>();
builder.Services.AddScoped<IEmailManager, EmailManager>();
builder.Services.AddScoped<IViewModelHelper, ViewModelHelper>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICharterService, CharterService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IOverallService, OverallService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.ConfigureDataAccess();
builder.ConfigureAuth();
var app = builder.Build();


if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
