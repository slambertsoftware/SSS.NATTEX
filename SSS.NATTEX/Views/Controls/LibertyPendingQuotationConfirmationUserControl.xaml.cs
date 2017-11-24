using SSS.NATTEX.DAL;
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
    public partial class LibertyPendingQuotationConfirmationUserControl : UserControl
    {
        public LibertyPendingQuotationConfirmationUserControl(DockingSetupModel dockingSetupModel, LibertyNewQuotation newQuotation)
        {
            InitializeComponent();
            var viewModel = new LibertyPendingQuotationConfirmationViewModel(dockingSetupModel, newQuotation);
            DataContext = viewModel;
        }
    }
}
