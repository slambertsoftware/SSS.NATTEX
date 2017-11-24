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
    public partial class LibertyNewQuotationUserControl : UserControl
    {

        public LibertyNewQuotationUserControl(DockingSetupModel layoutModel, CurrentLogin currentLogin)
        {
            InitializeComponent();
            var viewModel = new LibertyNewQuotationViewModel(layoutModel, currentLogin);
            DataContext = viewModel;
        }

        private void fileDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LibertyNewQuotationViewModel).UpdateUploadFileDescription();
        }

        private void NewQuotationControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtCustomerName.Focus();
        }

        private void txtCustomerName_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LibertyNewQuotationViewModel).ValidateCustomerName();
        }

        private void txtCustommerAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LibertyNewQuotationViewModel).ValidateCustomerAddress();
        }

        private void txtCustomerEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LibertyNewQuotationViewModel).ValidateCustomerEmail();
        }

        private void txtCustomerOtherInfo_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtCustomerContactNo_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LibertyNewQuotationViewModel).ValidateCustomerContactNumber();
        }
    }
}
