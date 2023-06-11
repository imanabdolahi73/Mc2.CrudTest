using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Common;
using Mc2.CrudTest.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);
   
// Add services to the container.
builder.Services.AddScoped<ITestDbContext, TestDbContext>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
