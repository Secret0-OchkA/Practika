using DesctopeApp.StartupHelpers;
using Domain;
using Infrastructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Services.Auth;
using Services.RoleServices;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DesctopeApp.RoleWindows
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly WindowRepository windowRepository;
        private readonly ApplicationContext context;
        private readonly ILogingHistoryService logingHistoryService;

        public AdminWindow(WindowRepository windowRepository, ApplicationContext context, ILogingHistoryService logingHistoryService)
        {
            InitializeComponent();
            this.windowRepository = windowRepository;
            this.context = context;
            this.logingHistoryService = logingHistoryService;
        }

        private void Click_Logout(object sender, RoutedEventArgs e)
        {
            logingHistoryService.AddLog();
            windowRepository.LoginFactory.Create().Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HistoryDatatable.ItemsSource = context.History.ToList();
        }
    }
}
