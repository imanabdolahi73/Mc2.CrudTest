using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Persistence.Context;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            
            var app = builder.Build();

            builder.Services.AddScoped<ITestDbContext, TestDbContext>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}