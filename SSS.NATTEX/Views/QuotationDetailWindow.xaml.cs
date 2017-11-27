using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for QuotationDetailWindow.xaml
    /// </summary>
    public partial class QuotationDetailWindow : Window
    {
        public QuotationDetailWindow()
        {
            InitializeComponent();
        }

        public QuotationDetailWindow(LibertyPendingQuotation pendingQuotation)
        {
            InitializeComponent();
            var viewModel = new QuotationDetailViewModel(this, pendingQuotation);
            DataContext = viewModel;
        }

        public void LoadDocuments(List<LibertyPendingQuotationDocument> documents)
        {
            if (documents != null)
            {
                foreach (LibertyPendingQuotationDocument document in documents)
                {
                    if (File.Exists(document.CopyToFilePath) && (document.FileExtension == ".pdf"))
                    {
                        WebBrowser browser = new WebBrowser()
                        {
                            VerticalAlignment = VerticalAlignment.Stretch,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            MaxWidth = 800,
                            MaxHeight = 800
                        };
                        TabItem tab = new TabItem()
                        {
                            Header = document.FileDescription,
                            VerticalAlignment = VerticalAlignment.Stretch,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalContentAlignment = VerticalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                            MaxWidth = 800,
                            MaxHeight = 800,
                            Content = browser
                        };

                        browser.Navigate(new Uri(String.Format("file:///{0}", document.CopyToFilePath)));
                        DocumentTabController.Items.Add(tab);
                    }
                }
            }
        }
    }
}
