using DesctopeApp.StartupHelpers;
using Domain;
using Services.Auth;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesctopeApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    private readonly IServiceAuth serviceAuth;
    private readonly ILogingHistoryService logingHistoryService;
    private readonly WindowRepository windowRepository;
    private readonly CurUserInfo curUserInfo;

    public LoginWindow(IServiceAuth serviceAuth, ILogingHistoryService logingHistoryService, WindowRepository windowRepository, CurUserInfo curUserInfo)
    {
        InitializeComponent();
        this.serviceAuth = serviceAuth;
        this.logingHistoryService = logingHistoryService;
        this.windowRepository = windowRepository;
        this.curUserInfo = curUserInfo;
    }

    private void Button_Login_Click(object sender, RoutedEventArgs e)
    {
        string login = LoginTextBox.Text;
        string password = PasswortTextBox.Password;

        try
        {
            Identity? user = serviceAuth.Login(login, password);
            if (user == null)
            {
                MessageBox.Show("incorrect login or pasword");
                logingHistoryService.AddErrorLogin(login);

                return;
            }

            curUserInfo.Update(user);

            switch (user.role)
            {
                case Roles.patient:
                    windowRepository.PatientFActory.Create().Show(); break;

                case Roles.Admin:
                    windowRepository.AdminFactory.Create().Show(); break;

                case Roles.Assistant:
                    windowRepository.AssistantFactory.Create().Show(); break;

                case Roles.Accountant:
                    windowRepository.AccountantWindow.Create().Show(); break;

                default:
                case Roles.unknow: throw new ArgumentException("Incorrect role");
            }

            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void Button_Registry_Click(object sender, RoutedEventArgs e)
    {
        windowRepository.ChoseRegFactory.Create().Show();
        this.Close();
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        ShowPassword.Visibility = Visibility.Visible;
        PasswortTextBox.Visibility = Visibility.Hidden;
    }

    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        ShowPassword.Visibility = Visibility.Hidden;
        PasswortTextBox.Visibility = Visibility.Visible;
    }
}


