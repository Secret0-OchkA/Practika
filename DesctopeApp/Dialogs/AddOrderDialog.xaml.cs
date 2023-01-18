using Services.Domain;
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

namespace DesctopeApp.Dialogs
{
    /// <summary>
    /// Interaction logic for AddOrderDialog.xaml
    /// </summary>
    public partial class AddOrderDialog : Window
    {
        private readonly IBloodService bloodService;
        private readonly IPatientManager patientManager;
        private readonly IServiceManager serviceManager;

        public AddOrderDialog(IBloodService bloodService, IPatientManager patientManager, IServiceManager serviceManager)
        {
            InitializeComponent();
            this.bloodService = bloodService;
            this.patientManager = patientManager;
            this.serviceManager = serviceManager;
        }

        

        private void Button_Click_AddService(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_RemoveService(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_Services.ItemsSource = await serviceManager.GetServices();
            ComboBox_Patient.ItemsSource = await patientManager.GetAll();
        }
    }
}
