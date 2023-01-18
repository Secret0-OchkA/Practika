using DesctopeApp.RoleWindows;
using DesctopeApp.StartupHelpers;
using Domain;
using Infrastructura;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Auth;
using Services.BizServices;
using Services.internetServices;
using Services.RoleServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesctopeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public static CurUserInfo curuser { get; private set; } = new CurUserInfo();

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IServiceAuth, ServiceAuth>();
                    services.AddTransient<IGetIpService, GetIpService>();
                    services.AddTransient<IHasherService, HasherService>();

                    services.AddTransient<IReportService, ReportService>();
                    services.AddTransient<ILogingHistoryService, LogingHistoryService>();

                    services.AddDbContext<ApplicationContext>();

                    services.AddWindowFactory<LoginWindow>();
                    services.AddWindowFactory<RegistreWorkerWindow>();
                    services.AddWindowFactory<RegistrePatientWindow>();
                    services.AddWindowFactory<ChoseRegWindow>();
                    services.AddWindowFactory<AdminWindow>();
                    services.AddWindowFactory<AccountantWindow>();
                    services.AddWindowFactory<AssistantWIndow>();
                    services.AddWindowFactory<PatientWindow>();

                    services.AddTransient<WindowRepository>();

                    services.AddSingleton(curuser);
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<IAbstractWindowFactory<LoginWindow>>().Create();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }
}
