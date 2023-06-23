using Microsoft.AspNetCore.Mvc;
using SoundsGoodCRM.DAO;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SoundsGoodCRM
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// add authentication
			builder.Services.AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(o => o.LoginPath = "/Home/Login");


			builder.Services.AddControllersWithViews()
				
				// needed for localization and validation
				.AddViewOptions(options =>
				{
					options.HtmlHelperOptions.ClientValidationEnabled = true;
					options.HtmlHelperOptions.Html5DateRenderingMode =
						Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode.CurrentCulture;
				})
				.AddDataAnnotationsLocalization()
				.AddMvcLocalization()
				.Services
				// needed for localization and validation
				.AddMvc(options => { options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); })
				.AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });


			//Add DbContext for the dependency injection 
			builder.Services.AddDbContext<SampleContext>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			// user authentication and authorization
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=ListOfOrders}/{id?}");

			app.Run();
		}
	}
}