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
    /// Interaction logic for ApplicationConfigurationWindow.xaml
    /// </summary>
    public partial class ApplicationConfigurationWindow : Window
    {
        public ApplicationConfigurationWindow()
        {
            InitializeComponent();
            var viewModel = new ApplicationConfigurationViewModel();
            DataContext = viewModel;
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ApplicationConfigurationViewModel).AccessPassword = txtAccessPassword.Password;
        }

        private void ApplicationConfigurator_Loaded(object sender, RoutedEventArgs e)
        {
            cboServer.Items.Add(".");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 3;
        }
    }
}
