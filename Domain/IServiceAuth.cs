using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IServiceAuth
    {
        Identity? Login(string login, string password);
        void Logout(Identity user);
        Identity RegistreUser(User newUser);
        Identity RegistrePatient(Patient newPatient);
    }
}
