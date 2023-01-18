using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.internetServices
{
    public interface IGetIpService
    {
        Task<string> GetIp();
    }
    public class GetIpService : IGetIpService
    {
        private readonly Regex ipreg = new Regex(@"([0-9]{1,3}[\.]){3}[0-9]{1,3}");
        public GetIpService() { }

        public async Task<string> GetIp()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://checkip.dyndns.org/");
            string content = await response.Content.ReadAsStringAsync();
            string ip = ipreg.Match(content).Value;
            return ip;
        }
    }
}
