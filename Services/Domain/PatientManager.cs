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
    public interface IPatientManager
    {
        Task<Patient?> GetByName(string name);
    }

    public class PatientManager : IPatientManager
    {
        private readonly ApplicationContext context;

        public PatientManager(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Patient?> GetByName(string name)
        {
            return await context.Patients.SingleOrDefaultAsync(p => p.person.Name.Equals(name));
        }
    }
}
