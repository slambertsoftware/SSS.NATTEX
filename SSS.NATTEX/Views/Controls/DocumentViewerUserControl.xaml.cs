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
using System.Windows.Xps.Packaging;

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for DocumentViewerUserControl.xaml
    /// </summary>
    public partial class DocumentViewerUserControl : UserControl
    {
        public DocumentViewerUserControl(XpsDocument xpsDocument)
        {
            InitializeComponent();
            var viewModel = new DocumentViewerViewModel(xpsDocument);
            DataContext = viewModel;
            DocumentViewer.Document = xpsDocument.GetFixedDocumentSequence();
            Document.Navigate("file:///" + @"file:///C:/Users/trebmals/Documents/Makro%20Order.pdf");
        }
    }
}
