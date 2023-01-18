using DesctopeApp.StartupHelpers;
using Domain;
using Newtonsoft.Json.Linq;
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
    public partial class RegistrePatientWindow : Window
    {
        private readonly IServiceAuth serviceAuth;
        private readonly IGetIpService getIpService;
        private readonly WindowRepository windowRepository;
        private readonly CurUserInfo curUserInfo;

        public RegistrePatientWindow(IServiceAuth serviceAuth, IGetIpService getIpService, WindowRepository windowRepository,CurUserInfo curUserInfo)
        {
            InitializeComponent();
            this.serviceAuth = serviceAuth;
            this.getIpService = getIpService;
            this.windowRepository = windowRepository;
            this.curUserInfo = curUserInfo;
        }

        private async void Button_Registry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var passport = PassportValidate();
                var Insurece = InsurenceValidate();
                var person = PersonValidate();
                var identity = await IdentityValidate();

                int socialSecNumber = int.Parse(socialSecNumberTextBox.Text);
                string socialSecType = socialSecTypeTextBox.Text;
                string ein = einTextBox.Text;
                string phone = phoneTextBox.Text;
                string country = countryTextBox.Text;

                Patient newPatinet = new Patient(
                    identity,
                    person,
                    Insurece,
                    socialSecNumber,
                    socialSecType,
                    ein,
                    phone,
                    passport,
                    country,
                    "desktop");
                curUserInfo.Update(serviceAuth.RegistrePatient(newPatinet));

                windowRepository.RegPatientFactory.Create().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Passport PassportValidate()
        {
            string serias = PassportSeriasTextBox.Text;
            string number = PassportNumberTextBox.Text;
            return new Passport(serias,number);
        }
        private Insurance InsurenceValidate()
        {
            string name = InsurenceNameTextBox.Text;
            string address = InsurenceAddressTextBox.Text;
            string inn = InsurenceInnTextBox.Text;
            string paymentAccount = InsurencePaymentAccountTextBox.Text;
            string bik = InsurenceBikTextBox.Text;
            return new Insurance(name,address,inn,paymentAccount,bik);
        }
        private Person PersonValidate()
        {
            string FIO = PersonFIOTextBox.Text;
            DateTime birthday = DateTime.Parse((string)PersonBirthdayTextBox.Text);
            return new Person(FIO,birthday);
        }
        private async Task<Identity> IdentityValidate()
        {
            string ip = await getIpService.GetIp();
            string password = PasswordTextBox.Text;
            string passwordConfirm = PasswordTextBoxConfirm.Text;
            string login = LoginTextBox.Text;
            string name = NameTextBox.Text;

            if (string.IsNullOrEmpty(password) || !password.Equals(passwordConfirm))
                throw new ArgumentException("password incorrect");

            return new Identity(name, login, password, ip, Roles.patient);
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            windowRepository.LoginFactory.Create().Show();
            this.Close();
        }
    }
}
