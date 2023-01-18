using DesctopeApp.StartupHelpers;
using Domain;
using Services.Auth;
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
    public partial class RegistreWorkerWindow : Window
    {
        private readonly IServiceAuth serviceAuth;
        private readonly IGetIpService getIpService;
        private readonly WindowRepository windowRepository;
        private readonly CurUserInfo curUserInfo;

        public RegistreWorkerWindow(IServiceAuth serviceAuth, IGetIpService getIpService, WindowRepository windowRepository, CurUserInfo curUserInfo)
        {
            InitializeComponent();
            this.serviceAuth = serviceAuth;
            this.getIpService = getIpService;
            this.windowRepository = windowRepository;
            this.curUserInfo = curUserInfo;
        }

        private async void Button_Registry_Click(object sender, RoutedEventArgs e)
        {
            string ip = await getIpService.GetIp();
            string password = PasswordTextBox.Text;
            string passwordConfirm = PasswordTextBoxConfirm.Text;
            string login = LoginTextBox.Text;
            string name = NameTextBox.Text;

            Roles role = (Roles)ComboBoxRole.SelectedItem;
            if(role == Roles.unknow)
            {
                MessageBox.Show("incorrect role");
                return;
            }

            if(string.IsNullOrEmpty(password) || !password.Equals(passwordConfirm))
            {
                MessageBox.Show("password incorrect");
                return;
            }

            Identity identity = new Identity(name, login, password, ip, role);
            User newUser = new User(identity,new List<int>());
            try
            {
                curUserInfo.Update(serviceAuth.RegistreUser(newUser));
                switch (role)
                {
                    case Roles.Admin:
                        windowRepository.AdminFactory.Create().Show();
                        this.Close();
                        break;
                    case Roles.Assistant:
                        windowRepository.AssistantFactory.Create().Show();
                        this.Close();
                        break;
                    case Roles.Accountant:
                        windowRepository.AccountantWindow.Create().Show();
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            windowRepository.LoginFactory.Create().Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxRole.ItemsSource = new List<Roles>() { Roles.Admin, Roles.Assistant, Roles.Accountant };
            ComboBoxRole.SelectedIndex = 0;
        }
    }
}
