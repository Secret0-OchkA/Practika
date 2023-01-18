using Domain;
using Microsoft.EntityFrameworkCore.Storage;
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

        Order order = new Order();

        private async void Button_Click_AddService(object sender, RoutedEventArgs e)
        {
            Service? serv = await serviceManager.GerById((int)ComboBox_Services.SelectedValue);
            if (serv == null) return;
            Blood? blo = await bloodService.GetById((int)ComboBox_Blood.SelectedValue);
            if (blo == null) return;

            if(order.Patient == null) 
            { 
                Patient? patient = await patientManager.GetById((int)ComboBox_Patient.SelectedValue);
                if (patient == null) return;
                order.Patient = patient;
            }

            order.serviceInOrders.Add(new ServiceInOrder { service = serv, PatientBlood = blo});
            ComboBox_Patient.IsEnabled = false;

            ListBox_Order.Items.Add(new KeyValuePair<string, int>($"{blo.barcode}---{serv.Name}---{serv.Code}", order.serviceInOrders.Count - 1));
        }

        private void Button_Click_RemoveService(object sender, RoutedEventArgs e)
        {
            order.serviceInOrders.RemoveAt(ListBox_Order.SelectedIndex);
            ListBox_Order.Items.RemoveAt(ListBox_Order.SelectedIndex);
            if (order.serviceInOrders.Count <= 0) ComboBox_Patient.IsEnabled = true;
        }

        private void CalculateCost()
        {
            decimal cost = 0;
            foreach (var item in order.serviceInOrders)
                cost += item.service.Price;

            Label_Cost.Content = cost.ToString();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_Services.ItemsSource = await serviceManager.GetServices();
            ComboBox_Patient.ItemsSource = await patientManager.GetAll();
            ComboBox_Patient.SelectedItem = ComboBox_Patient.Items.Count > 0? ComboBox_Patient.Items[0] : null;
        }

        private async void ComboBox_Patient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ComboBox_Blood.ItemsSource = await bloodService.GetBloodByPatient((int)comboBox.SelectedValue);
                ComboBox_Blood.SelectedItem = ComboBox_Blood.Items.Count > 0 ? ComboBox_Blood.Items[0] : null;
            }
        }
    }
}
