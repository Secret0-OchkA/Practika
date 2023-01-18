using DesctopeApp.StartupHelpers;
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
    /// Interaction logic for AddBiomaterialDialog.xaml
    /// </summary>
    public partial class AddBiomaterialDialog : Window
    {
        private readonly IBloodService bloodService;

        public AddBiomaterialDialog(IBloodService bloodService)
        {
            InitializeComponent();
            this.bloodService = bloodService;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private async void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string name = TextBox_Patient.Text;
            DateTime? date = DatePiker_Date.SelectedDate;
            if (date == null)
            {
                MessageBox.Show("Date not selected");
                return;
            }

            int code;
            if (!int.TryParse(TextBox_Barcode.Text, out code))
            {
                MessageBox.Show("not code");
                return;
            }

            try
            {
                await bloodService.AddBloodAsync(name,code,date.Value);
                DialogResult = true;
            }
            catch (ArgumentException) { MessageBox.Show("Not found patient"); }
        }
    }
}
