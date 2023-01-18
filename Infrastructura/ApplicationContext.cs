using Domain;
using Infrastructura.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructura
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Blood> Bloods { get; protected set; } = null!;
        public DbSet<Patient> Patients { get; protected set; } = null!;
        public DbSet<Service> Services { get; protected set; } = null!;
        public DbSet<BloodService> bloodServices { get; protected set; } = null!;
        public DbSet<User> Users { get; protected set; } = null!;
        public DbSet<Report> Reports { get; protected set; } = null!;
        public DbSet<HistoryRow> History { get; protected set; } = null!;
        public DbSet<Order> Orders { get; protected set; } = null!;
        public DbSet<ServiceInOrder> ServiceInOrder { get; protected set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=testdb;User Id=app;Password=Secret123;Encrypt=false;TrustServerCertificate=true");
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
