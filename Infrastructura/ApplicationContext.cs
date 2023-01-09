using Domain;
using Infrastructura.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructura
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Blood> bloods { get; protected set; } = null!;
        public DbSet<Patient> Patients { get; protected set; } = null!;
        public DbSet<Service> Services { get; protected set; } = null!;
        public DbSet<BloodService> bloodServices { get; protected set; } = null!;
        public DbSet<User> Users { get; protected set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=databaseLite.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BloodServiceMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
