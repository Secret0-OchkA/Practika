using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.internetServices
{
    public class GetIpService : IGetIpService
    {
        public GetIpService() { }

        public async Task<string> GetIp()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://checkip.dyndns.org/");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
