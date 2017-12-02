using SSS.NATTEX.Models;
using SSS.NATTEX.ViewModel.Avbob;
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

namespace SSS.NATTEX.Views.Controls.Avbob
{
    /// <summary>
    /// Interaction logic for AvbobNewQuotationUserControl.xaml
    /// </summary>
    public partial class AvbobNewQuotationUserControl : UserControl
    {
        public AvbobNewQuotationUserControl(DockingSetupModel layoutModel, CurrentLogin currentLogin)
        {
            InitializeComponent();
            var viewModel = new AvbobNewQuotationViewModel(layoutModel, currentLogin);
            DataContext = viewModel;
        }

        private void NewAvbobQuotationControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerContactNo_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AvbobNewQuotationViewModel).ValidateCustomerContactNumber();
        }

        private void CustomerEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AvbobNewQuotationViewModel).ValidateCustomerEmail();
        }

        private void CustomerOtherInfo_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CustommerAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AvbobNewQuotationViewModel).ValidateCustomerAddress();
        }

        private void CustomerName_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AvbobNewQuotationViewModel).ValidateCustomerName();
        }

        private void FileDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AvbobNewQuotationViewModel).UpdateUploadFileDescription();
        }

        private void ImportFileNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AvbobNewQuotationViewModel).ValidateImportFileName();
        }
    }
}
