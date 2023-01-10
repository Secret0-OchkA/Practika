using Domain;
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

    public LoginWindow(IServiceAuth serviceAuth)
    {
        InitializeComponent();
        this.serviceAuth = serviceAuth;
    }

    private void Button_Login_Click(object sender, RoutedEventArgs e)
    {
        string login = LoginTextBox.Text;
        string password = LoginTextBox.Text;

        try
        {
            Identity? user = serviceAuth.Login(login, password);
            if (user == null)
            {
                MessageBox.Show("Login error");
            }


            MessageBox.Show($"Login: {user.login}, Name: {user.Name}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void Button_Registry_Click(object sender, RoutedEventArgs e)
    {

    }
}


