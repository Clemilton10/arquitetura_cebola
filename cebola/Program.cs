using AutoMapper;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace arq_cebola
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Abrindo o arquivo appsettings.json
			builder.Configuration
				.AddJsonFile(
					"appsettings.json",
					optional: false,
					reloadOnChange: true
				);

			// Pegando a string de conexao do appsettings.json
			string connectionString = builder.Configuration
				.GetConnectionString("sqlServerDb");

			// Configure o banco de dados SQLite
			builder.Services
				.AddDbContext<AppDbContext>(
					options =>
					//options.UseSqlite(connectionString)
					options.UseSqlServer(connectionString)
				);

			// Registre os repositorios no container de injecao de dependencia
			builder.Services
				.AddScoped<IProductService, ProductService>();
			builder.Services
				.AddScoped<ProductRepository>();

			// injecao de dependencia do Mapper
			builder.Services.AddAutoMapper(typeof(Program));

			// Configuração do MVC
			builder.Services
			.AddControllersWithViews()
			.AddRazorOptions(options =>
			{
				options.ViewLocationFormats
				.Add("/Presentation/Views/{1}/{0}" + RazorViewEngine.ViewExtension);

				options.ViewLocationFormats
				.Add("/Presentation/Views/Product/{0}" + RazorViewEngine.ViewExtension);

				options.ViewLocationFormats
				.Add("/Presentation/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
			});

			var app = builder.Build();

			// Cria o banco de dados e aplica as migracoes na inicializacao
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider
				.GetRequiredService<AppDbContext>();
				dbContext.Database.EnsureCreated();
				// dbContext.Database.Migrate();
			}

			if (!app.Environment.IsDevelopment())
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
		}
	}
}