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

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for GeneratedQuotationUserControl.xaml
    /// </summary>
    public partial class ConfirmQuotationUserControl : UserControl
    {
        public ConfirmQuotationUserControl(DockingSetupModel dockingSetup)
        {
            InitializeComponent();
            var viewModel = new ConfirmQuotationViewModel(dockingSetup);
            DataContext = viewModel;
        }

        private void ConfirmQuotationUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ConfirmQuotationViewModel).LoadQuotationDetail();
            (this.DataContext as ConfirmQuotationViewModel).LoadGeneratedQuotation();
        }
    }
}
