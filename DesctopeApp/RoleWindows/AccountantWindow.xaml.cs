using Microsoft.Identity.Client;
using Microsoft.Win32;
using Services.RoleServices;
using System;
using System.Collections.Generic;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Shapes;
using System.IO;
using DesctopeApp.StartupHelpers;
using Services.Auth;
using Domain;

namespace DesctopeApp.RoleWindows
{
    /// <summary>
    /// Interaction logic for AccountantWindow.xaml
    /// </summary>
    public partial class AccountantWindow : Window
    {
        private readonly IReportService reportService;
        private readonly WindowRepository windowRepository;
        private readonly ILogingHistoryService logingHistoryService;

        public CurUserInfo CurUser { get; }

        public AccountantWindow(IReportService reportService,WindowRepository windowRepository, ILogingHistoryService logingHistoryService)
        {
            InitializeComponent();
            this.reportService = reportService;
            this.windowRepository = windowRepository;
            this.logingHistoryService = logingHistoryService;
            UpdateReportList();
        }

        private void Button_CreateReport(object sender, RoutedEventArgs e)
        {
            string reportName = ReportNameTextBox.Text;
            string data = ReportTextBox.Text;

            try
            {
                reportService.CreateReport(new Domain.Report(reportName, data));
                UpdateReportList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateReportList()
        {
            var reports = reportService.GetReports().Select(r => r.name);
            
            ReportsListBox.ItemsSource = reports;
        }

        private async void ReportsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string file = ReportsListBox.SelectedItem.ToString() ?? "";

            LoadReportTextBlock.Text = reportService.GetReport(file).data;
        }

        private void Click_logout(object sender, RoutedEventArgs e)
        {
            logingHistoryService.AddLog();
            windowRepository.LoginFactory.Create().Show();
            this.Close();
        }
    }
}
