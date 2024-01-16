# Arquitetura Cebola

## Explicação

Onde terminou o curso do Balta:

[https://github.com/Clemilton10/md_dotnet](https://github.com/Clemilton10/md_dotnet)

## Perguntas:

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

A Estrutura do meu projeto `cebola` está certa?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Embora a definição de `Injeção de dependência` ser `reaproveitamento de funcionalidades`:

|    Escopo | Definição                                                      |
| --------: | :------------------------------------------------------------- |
| Transient | Uma nova instância a cada solicitação.                         |
|    Scoped | Uma instância por solicitação HTTP.                            |
| Singleton | Uma instância única compartilhada entre todas as solicitações. |

Quando devo usar um ou outro?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Qual a diferença entre o `ProductService` e o `ProductRepository`?

-   Qual seria a necessidade de ambos?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Me explique melhor sobre o `Mapper`

-   Onde e como devo usar?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

As empresas usam o `identity Server`?

-   Como `personalizar` o login e logout?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Porque o método `put` não funciona no formulário de uma página `Razor`(Update)?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Tem como ativar o `highlight` no `Markdown` no ![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) Visual Stúdio?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Você sabe como criar um `Snippet` no ![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) Visual Stúdio?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Como você lida com o `git` no ![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) Visual Stúdio?

</div>

<div style="padding:20px;border:1px solid #58a6ff;border-radius:10px;margin-bottom:20px;margin-top:10px;width:700px;">

Quando vocês vão fazer testes, usam `xUnit`?

-   Que outras ferramentas usam?
-   [https://github.com/Clemilton10/xUnit_teste](https://github.com/Clemilton10/xUnit_teste)

</div>

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
