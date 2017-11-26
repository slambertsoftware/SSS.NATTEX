using SSS.NATTEX.Models;
using SSS.NATTEX.ViewModel;
using SSS.NATTEX.Views.Controls;
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
using System.Windows.Xps.Packaging;

namespace SSS.NATTEX.Views
{
    /// <summary>
    /// Interaction logic for QuotationDocumentViewerWindow.xaml
    /// </summary>
    public partial class QuotationDocumentViewerWindow : Window
    {
        public QuotationDocumentViewerWindow(LibertyNewQuotation newQuotation, CurrentLogin currentLogin)
        {
            InitializeComponent();
            var viewModel = new QuotationDocumentViewerViewModel(this, newQuotation, currentLogin);
            DataContext = viewModel;
        }
    }
}
