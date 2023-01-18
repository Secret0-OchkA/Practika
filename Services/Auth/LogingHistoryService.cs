using Services.Auth;
using Domain;
using Infrastructura;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public interface ILogingHistoryService
    {
        void AddErrorLogin(string login);
        void AddLog();
    }

    public class LogingHistoryService : ILogingHistoryService
    {
        private readonly ApplicationContext context;
        private readonly CurUserInfo curUser;

        public LogingHistoryService(ApplicationContext context, CurUserInfo curUser)
        {
            this.context = context;
            this.curUser = curUser;
        }
        public void AddLog()
        {
            context.History.Add(new HistoryRow(curUser.login, true, curUser.lastenter, DateTime.Now));
            context.SaveChanges();
        }
        public void AddErrorLogin(string login)
        {
            context.History.Add(new HistoryRow(login, false, DateTime.Now, null));
            context.SaveChanges();
        }
    }
}
