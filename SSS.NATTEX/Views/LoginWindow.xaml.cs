using SSS.NATTEX.ViewModel;
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

namespace SSS.NATTEX.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(System.Windows.Window window)
        {
            InitializeComponent();
            var viewModel = new LoginViewModel(window);
            DataContext = viewModel;
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LoginViewModel).Password = txtPassword.Password;
        }

        private void LoginControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
