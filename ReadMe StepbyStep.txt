
Commit: git init
----------------------------------------------------------------
001: Change Clean Architecture

	Add Domain
	Add Application
	Add Common
	Add Persistence

Commit: Change & Add Clean Architecture
----------------------------------------------------------------
002: install EF Core

	NuGet\Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.0-preview.1.23111.4
	NuGet\Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.0-preview.1.23111.4
	NuGet\Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.0-preview.1.23111.4
	NuGet\Install-Package Microsoft.EntityFrameworkCore.Relational -Version 8.0.0-preview.1.23111.4

003: Add Context
	Add Customer.cs in Domain.Entities
	Add TestDbContext in Persistence.Context
	
	Add in AppSettings
	"ConnectionStrings": {
		"TestConnection": "Data Source=DESKTOP-IQ90JPA;Initial Catalog=Test_DB;Integrated Security=True;TrustServerCertificate=True"
		}

	Add in Program.cs
	builder.Services.AddDbContext<TestDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection"));
            });
	
Commit: Add Context
----------------------------------------------------------------
004: Add ResultDto.cs in Common

005 Add CustomerRepository
	CustomerRepository.cs
	ICustomerRepository.cs
	AddCustomerDto.cs
	EditCustomerDto.cs

006: Add Service To Program.cs
	builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

Commit: Add CustomerRepository
----------------------------------------------------------------

007: Add Swagger , Add CustomerController in New Api Project

                                                        *************---------As you said, I changed the architecture----------*************





