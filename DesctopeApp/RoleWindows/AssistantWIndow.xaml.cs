using DesctopeApp.StartupHelpers;
using Microsoft.Win32;
using Services.Auth;
using Services.RoleServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesctopeApp.RoleWindows
{
    /// <summary>
    /// Interaction logic for AssistantWIndow.xaml
    /// </summary>
    public partial class AssistantWIndow : Window
    {
        private readonly IReportService reportService;
        private readonly WindowRepository windowRepository;
        private readonly ILogingHistoryService logingHistoryService;
        private readonly TimeSpan logoutDelay = new TimeSpan(0,10,0);
        private readonly DispatcherTimer logoutTimer = new DispatcherTimer();

        private readonly TimeSpan LogoutWarningDelay = new TimeSpan(0,0,10);
        private readonly DispatcherTimer LogoutWarningTimer = new DispatcherTimer();

        private readonly DispatcherTimer Timer = new DispatcherTimer();


        public AssistantWIndow(IReportService reportService, WindowRepository windowRepository, ILogingHistoryService logingHistoryService)
        {
            InitializeComponent();
            this.reportService = reportService;
            this.windowRepository = windowRepository;
            this.logingHistoryService = logingHistoryService;
        }


        private void Button_CreateReport(object sender, RoutedEventArgs e)
        {
            string reportName = ReportNameTextBox.Text;
            string data = ReportTextBox.Text;

            try
            {
                reportService.CreateReport(new Domain.Report(reportName, data));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogoutTick(object sender, EventArgs e)
        {
            MessageBox.Show("тебя закварцевали");
            windowRepository.LoginFactory.Create().Show();
            logingHistoryService.AddLog();
            this.Close();
        }

        private void LogoutWrningTick(object sender, EventArgs e)
        {
            LogoutWarningTimer.Stop();
            MessageBox.Show("Выйди или тебя закварцуют");
        }
        private void Click_logout(object sender, RoutedEventArgs e)
        {
            windowRepository.LoginFactory.Create().Show();
            logingHistoryService.AddLog();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logoutTimer.Tick += LogoutTick;
            logoutTimer.Interval = logoutDelay;
            logoutTimer.Start();

            LogoutWarningTimer.Tick += LogoutWrningTick;
            LogoutWarningTimer.Interval = LogoutWarningDelay;
            LogoutWarningTimer.Start();

            Timer.Tick += TimerTick;
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Start();
        }

        private TimeSpan TimeSpanTimer = TimeSpan.FromMinutes(10);
        private void TimerTick(object sender, EventArgs e)
        {
            TimeSpanTimer = TimeSpanTimer - TimeSpan.FromSeconds(1);
            TimerTextBlock.Text = TimeSpanTimer.ToString();
        }
    }
}
