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
using ChatDemoExam.DataBaseModel;
using ChatDemoExam.Classes;
using ChatDemoExam.Windows;
using System.Net;

namespace ChatDemoExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PsBPassword.Password) || string.IsNullOrEmpty(TxtLogin.Text))
            {
                MessageBox.Show("Please fill in the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var auth = ConnectingClass.connect.Employee.Where(z => z.Password == PsBPassword.Password && z.Username == TxtLogin.Text).FirstOrDefault();
                if (auth != null)
                {
                    MainWindow.emp = auth; 
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    MessageBox.Show($"Welcome {auth.Name}", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    App.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Authorization error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
           
        }
    }
}
