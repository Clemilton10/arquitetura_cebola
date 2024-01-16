# Arquitetura Cebola

## Perguntas:

-   A Estrutura está certa?
-   Qual a diferença entre o `ProductService` e o `ProductRepository`?
    -   Qual seria a necessidade de ambos?
-   Me explique melhor sobre o `Mapper`
    -   Onde e como devo usar?
-   As empresas usam o `identity Server`?
    -   Como `personalizar` o login e logout?

## Estrutura de Pastas

```csharp
📁 Properties
	...
📁 wwwroot
	...
📁 Application
	📁 Controllers
		📄 HomeController.cs
		📄 ProductController.cs
	📁 DTOs // Data Transfer Object // Model
		📄 ProductDTO.cs
📁 Core
	📁 Interfaces
		📄 IProductService.cs
	📁 Mappings
		📄 IProductProfile.cs
	📁 Models // Entidades
		📄 ErrorViewModel.cs
		📄 Product.cs
	📁 Services
		📄 ProductService.cs
📁 Infrastructure
	📁 Persistence
		📄 AppDbContext.cs
	📁 Repositories
		📄 ProductRepository.cs
📁 Presentation
	📁 Views
		📁 Home
			📄 Index.cshtml
			📄 Privacy.cshtml
		📁 Product
			📄 Index.cshtml
			📄 Create.cshtml
		📁 Shared
			📄 _layout.cshtml
			📄 _ValidationScriptsPartial.cshtml
			📄 Error.cshtml
		📄 _ViewImports.cshtml
		📄 _ViewStart.cshtml
```

## Criar o projeto

![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) Aplicativo Web do ASP.NET Core (Model-View-Controller)

```sh
dotnet new mvc -f net6.0 -n cebola
dotnet sln add cebola
```

## Pacotes

📝 cebola/cebola.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
	<PropertyGroup>
		<TargetFramework>net6.0</TargetFramework>
		<Nullable>enable</Nullable>
		<ImplicitUsings>enable</ImplicitUsings>
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
		<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.13">
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
			<PrivateAssets>all</PrivateAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="7.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.3" />
		<PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="6.5.0" />
		<PackageReference Include="System.Linq.Dynamic.Core" Version="1.3.5" />
		<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="6.0.0" />
	</ItemGroup>
</Project>
```

## Configurações do servidor e portas

📝 cebola/Properties/launchSettings.json

```json
{
	"profiles": {
		"arq_cebola": {
			"commandName": "Project",
			"dotnetRunMessages": true,
			"launchBrowser": true,
			"applicationUrl": "https://localhost:5001;http://localhost:5000",
			"environmentVariables": {
				"ASPNETCORE_ENVIRONMENT": "Development"
			}
		}
	}
}
```

## Configurações do banco de dados

📝 cebola/appsettings.json

```json
{
	"ConnectionStrings": {
		"sqliteDb": "Data Source=product.db",
		"sqlServerDb": "Server=(LocalDb)\\MSSQLLocalDB;Database=product;Trusted_Connection=True;TrustServerCertificate=True;"
	},
	"Logging": {
		"LogLevel": {
			"Default": "Information",
			"Microsoft.AspNetCore": "Warning"
		}
	},
	"AllowedHosts": "*"
}
```

## Conexão com banco de dados

📝 cebola/Program.cs

```csharp
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
```

## Injeção de dependência

📝 cebola/Program.cs

```csharp
// Registre os repositorios no container de injecao de dependencia
builder.Services
	.AddScoped<IProductService, ProductService>();
builder.Services
	.AddScoped<ProductRepository>();
```

## Injeção de dependência do Mapper

```csharp
// injecao de dependencia do Mapper
builder.Services.AddAutoMapper(typeof(Program));
```

## Configurando as novas pastas das Views

```csharp
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
```

## Criando o banco de dados na inicialização

```csharp
// Cria o banco de dados e aplica as migracoes na inicializacao
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider
	.GetRequiredService<AppDbContext>();
	dbContext.Database.EnsureCreated();
	// dbContext.Database.Migrate();
}
```

## Adicionando os links

📝 cebola/Presentations/Views/Shared/\_layout.cshtml

```csharp
<li class="nav-item">
	<a class="nav-link text-dark" asp-area="" asp-controller="Product" asp-action="Index">Product</a>
</li>
<li class="nav-item">
	<a class="nav-link text-dark" asp-area="" asp-controller="Product" asp-action="Create">Create</a>
</li>
```
