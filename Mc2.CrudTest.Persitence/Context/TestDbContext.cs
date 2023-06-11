
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Context
{
    public class TestDbContext :DbContext,ITestDbContext
    {
        public TestDbContext()
        {
        }
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=DESKTOP-IQ90JPA;Database=Test_DB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
