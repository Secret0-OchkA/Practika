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

            optionsBuilder.UseSqlite("Data source=databaseLite.db");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
