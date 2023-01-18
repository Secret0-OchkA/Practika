using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.BizServices
{
    public interface IHasherService
    {
        string GetHash(string key);
    }
    public class HasherService : IHasherService
    {
        public string GetHash(string key)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: key,
                salt: Encoding.ASCII.GetBytes("SecretKey"),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 32));

            return hashed;
        }
    }
}
