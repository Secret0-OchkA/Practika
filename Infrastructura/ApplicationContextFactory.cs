using Infrastructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=testdb;User Id=app;Password=Secret123;Encrypt=false;TrustServerCertificate=true");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
