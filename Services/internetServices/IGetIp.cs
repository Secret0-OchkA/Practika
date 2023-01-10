using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.internetServices
{
    public interface IGetIpService
    {
        Task<string> GetIp();
    }
}
