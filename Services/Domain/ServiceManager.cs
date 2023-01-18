using Domain;
using Infrastructura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public interface IServiceManager
    {
        Task<Service?> GerById(int id);
        Task<List<Service>> GetServices();
    }

    public class ServiceManager : IServiceManager
    {
        private readonly ApplicationContext context;

        public ServiceManager(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Service>> GetServices()
        {
            return await context.Services.ToListAsync();
        }
        public async Task<Service?> GerById(int id)
        {
            return await context.Services.SingleOrDefaultAsync(s => s.Code == id);
        }
    }
}
