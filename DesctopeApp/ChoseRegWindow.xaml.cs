using DesctopeApp.StartupHelpers;
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
using System.Windows.Shapes;

namespace DesctopeApp
{
    /// <summary>
    /// Логика взаимодействия для ChoseRegWindow.xaml
    /// </summary>
    public partial class ChoseRegWindow : Window
    {
        private readonly WindowRepository windowRepository;

        public ChoseRegWindow(WindowRepository windowRepository)
        {
            InitializeComponent();
            this.windowRepository = windowRepository;
        }

        private void OpenRegWorkerWindow(object sender, RoutedEventArgs e)
        {
            windowRepository.RegWorkerFactory.Create().Show();
            this.Close();
        }

        private void OpenRegPatientWindow(object sender, RoutedEventArgs e)
        {
            windowRepository.RegPatientFactory.Create().Show();
            this.Close();
        }
    }
}
