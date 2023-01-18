using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class CurUserInfo
    { 
        public CurUserInfo() { }

        public string login = string.Empty;
        public string Name = string.Empty;
        public string ip = string.Empty;
        public Roles role = Roles.unknow;
        public DateTime lastenter = DateTime.Now;
    }

    public static class CurUserInfoExtension
    {
        public static CurUserInfo Clear(this CurUserInfo curUserInfo)
        {
            curUserInfo.login = string.Empty;
            curUserInfo.Name = string.Empty;
            curUserInfo.ip = string.Empty;
            curUserInfo.role = Roles.unknow;
            curUserInfo.lastenter = DateTime.Now;
            return curUserInfo;
        }
        public static CurUserInfo Update(this CurUserInfo curUserInfo, string login, string name, string ip, DateTime lastenter, Roles role) 
        {
            curUserInfo.login = login;
            curUserInfo.Name = name;
            curUserInfo.ip = ip;
            curUserInfo.role = role;
            curUserInfo.lastenter = lastenter;
            return curUserInfo;
        }
        public static CurUserInfo Update(this CurUserInfo curUserInfo, Identity identity)
        {
            curUserInfo.Update(identity.login, identity.Name, identity.Ip, DateTime.Now, identity.role);
            return curUserInfo;
        }
    }
}
