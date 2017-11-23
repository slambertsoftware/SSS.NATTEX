using SSS.NATTEX.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for QuotationTypeUserControl.xaml
    /// </summary>
    public partial class NewQuotationUserControl : UserControl
    {

        public NewQuotationUserControl(DockingSetupModel layoutModel, CurrentLogin currentLogin)
        {
            InitializeComponent();
            var viewModel = new NewQuotationViewModel(layoutModel, currentLogin);
            DataContext = viewModel;
        }

        private void fileDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as NewQuotationViewModel).UpdateUploadFileDescription();
        }

        private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as NewQuotationViewModel).UpdateValidationStatus();
        }

        private void NewQuotationControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtCustomerName.Focus();
        }
    }
}
