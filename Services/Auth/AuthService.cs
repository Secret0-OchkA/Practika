using Domain;
using Infrastructura;
using Microsoft.EntityFrameworkCore;
using Services.BizServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public interface IServiceAuth
    {
        Identity? Login(string login, string password);
        void Logout(Identity user);
        Identity RegistreUser(User newUser);
        Identity RegistrePatient(Patient newPatient);
    }

    public class ServiceAuth : IServiceAuth
    {
        ApplicationContext context;
        private readonly IHasherService hasherService;

        public ServiceAuth(ApplicationContext context, IHasherService hasherService) 
        {
            this.context = context;
            this.hasherService = hasherService;
        }

        private readonly TimeSpan loginDelay = new TimeSpan(0, 0, 0);

        public Identity? Login(string login, string password)
        {
            string hashPassword = hasherService.GetHash(password);

            User? user = context.Users
                .Where(u => u.identity.login.Equals(login) && u.identity.password.Equals(hashPassword))
                .SingleOrDefault();

            if (user != null)
            {
                if (DateTime.Now - user.lastenter < loginDelay) return null;

                return user.identity;
            }
            
            Patient? patient = context.Patients
                .Where(p => p.user.login.Equals(login) && p.user.password.Equals(hashPassword))
                .SingleOrDefault();

            if (patient != null)
            {
                return patient.user;
            }

            return null;
        }

        public void Logout(Identity user)
        {
            throw new NotImplementedException();
        }

        public Identity RegistreUser(User newUser)
        {
            User? user = context.Users.Where(u => u.identity.login.Equals(newUser.identity.login) && u.identity.Name.Equals(newUser.identity.Name)).SingleOrDefault();
            if (user != null) throw new ArgumentException("not uniq login or name");

            Patient? patient = context.Patients.Where(u => u.user.login.Equals(newUser.identity.login) && u.user.Name.Equals(newUser.identity.Name)).SingleOrDefault();
            if (patient != null) throw new ArgumentException("not uniq login or name");

            newUser.identity.password = hasherService.GetHash(newUser.identity.password);

            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser.identity;
        }
        public Identity RegistrePatient(Patient newPatient)
        {
            Patient? patient = context.Patients.Where(u => u.user.login.Equals(newPatient.user.login) && u.user.Name.Equals(newPatient.user.Name)).SingleOrDefault();
            if (patient != null) throw new ArgumentException("not uniq login or name");

            User? user = context.Users.Where(u => u.identity.login.Equals(newPatient.user.login) && u.identity.Name.Equals(newPatient.user.Name)).SingleOrDefault();
            if (user != null) throw new ArgumentException("not uniq login or name");

            newPatient.user.password = hasherService.GetHash(newPatient.user.password);

            context.Patients.Add(newPatient);
            context.SaveChanges();
            return newPatient.user;
        }
    }
}
