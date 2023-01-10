using Domain;
using Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class ServiceAuth : IServiceAuth
    {
        ApplicationContext context;
        public ServiceAuth(ApplicationContext context) 
        {
            this.context = context;
        }
        public Identity Login(string login, string password)
        {
            User? user = context.Users.Where(u => u.identity.login.Equals(login)).SingleOrDefault();
            if (user != null)
            {
                return user.identity;
            }
            Patient? patient = context.Patients.Where(p => p.user.login.Equals(login)).SingleOrDefault();
            if (patient != null)
            {
                return patient.user;
            }

            throw null;
        }

        public void Logout(Identity user)
        {
            throw new NotImplementedException();
        }

        public Identity RegistreUser(User newUser)
        {
            User? user = context.Users.Where(u => u.identity.login.Equals(newUser.identity.login) && u.identity.Name.Equals(newUser.identity.Name)).SingleOrDefault();
            if (user != null) throw new ArgumentException();

            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser.identity;
        }
        public Identity RegistrePatient(Patient newPatient)
        {
            Patient? patient = context.Patients.Where(u => u.user.login.Equals(newPatient.user.login) && u.user.Name.Equals(newPatient.user.Name)).SingleOrDefault();
            if (patient != null) throw new ArgumentException();

            context.Patients.Add(newPatient);
            context.SaveChanges();
            return patient.user;
        }
    }
}
