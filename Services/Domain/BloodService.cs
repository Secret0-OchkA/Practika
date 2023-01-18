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
    public interface IBloodService
    {
        Task AddBloodAsync(string patientName, int code, DateTime date);
        Task<List<Blood>> GetBloodByPatient(int patientId);
        Task<Blood?> GetById(int bloodId);
    }

    public class BloodService : IBloodService
    {
        private readonly ApplicationContext context;
        private readonly IPatientManager patientManager;

        public BloodService(ApplicationContext context, IPatientManager patientManager)
        {
            this.context = context;
            this.patientManager = patientManager;
        }

        public async Task AddBloodAsync(string patientName, int code, DateTime date)
        {
            Patient? patient = await patientManager.GetByName(patientName);

            if (patient == null) throw new ArgumentException("Not found patient");

            Blood blood = new Blood(patient, code, date);
            context.Bloods.Add(blood);
            await context.SaveChangesAsync();
        }

        public async Task<List<Blood>> GetBloodByPatient(int patientId)
        {
            return await context.Bloods.Where(b => b.Patient.Id == patientId).ToListAsync();
        }

        public async Task<Blood?> GetById(int bloodId)
            => await context.Bloods.SingleOrDefaultAsync(b => b.Id == bloodId);
    }
}
