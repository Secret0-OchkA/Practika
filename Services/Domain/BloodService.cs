using Domain;
using Infrastructura;
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
    }
}
