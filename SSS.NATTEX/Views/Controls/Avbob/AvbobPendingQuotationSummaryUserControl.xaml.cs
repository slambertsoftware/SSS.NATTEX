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
    /// Interaction logic for AvbobPendingQuotationSummaryUserControl.xaml
    /// </summary>
    public partial class AvbobPendingQuotationSummaryUserControl : UserControl
    {
        public AvbobPendingQuotationSummaryUserControl(System.Windows.Window window, DockingSetupModel layoutModel, AvbobQuotationModel quotationModel, CurrentLogin currentLogin)
        {
            InitializeComponent();
            var viewModel = new AvbobPendingQuotationSummaryViewModel(window, layoutModel, quotationModel, currentLogin);
            DataContext = viewModel;
        }
    }
}
