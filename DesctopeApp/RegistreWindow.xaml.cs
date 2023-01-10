using Domain;
using Services.internetServices;
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
    /// Логика взаимодействия для RegistreWindow.xaml
    /// </summary>
    public partial class RegistreWindow : Window
    {
        private readonly IServiceAuth serviceAuth;
        private readonly IGetIpService getIpService;

        public RegistreWindow(IServiceAuth serviceAuth, IGetIpService getIpService)
        {
            InitializeComponent();
            this.serviceAuth = serviceAuth;
            this.getIpService = getIpService;
        }

        private async void Button_Registry_Click(object sender, RoutedEventArgs e)
        {
            string ip = await getIpService.GetIp();
            string password = PasswordTextBox.Text;
            string passwordConfirm = PasswordTextBoxConfirm.Text;
            string login = LoginTextBox.Text;
            string name = NameTextBox.Text;

            if(string.IsNullOrEmpty(password) || !password.Equals(passwordConfirm))
            {
                MessageBox.Show("password incorrect");
                return;
            }

            Identity identity = new Identity(name, login, password, ip);
            User newUser = new User(identity,new List<int>(),Roles.Admin,DateTime.Now);
            serviceAuth.RegistreUser(newUser);
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
