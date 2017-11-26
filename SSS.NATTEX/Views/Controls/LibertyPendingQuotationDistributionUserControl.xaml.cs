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
    /// Interaction logic for PrintQuotationUserControl.xaml
    /// </summary>
    public partial class LibertyPendingQuotationDistributionUserControl : UserControl
    {
        public LibertyPendingQuotationDistributionUserControl(DockingSetupModel dockingSetup, LibertyNewQuotation quotationModel, CurrentLogin currentLogin)
        {
            InitializeComponent();
            var viewModel = new LibertyPendingQuotationDistributionViewModel(dockingSetup, quotationModel, currentLogin);
            DataContext = viewModel;
        }

        private void ExportDistributionUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LibertyPendingQuotationDistributionViewModel).LoadExportOptions();
            (this.DataContext as LibertyPendingQuotationDistributionViewModel).LoadDistributionOptions();
        }
    }
}
