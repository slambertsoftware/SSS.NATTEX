using SSS.NATTEX.DAL;
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
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.Views
{
    /// <summary>
    /// Interaction logic for NewQuotationWindow.xaml
    /// </summary>
    public partial class NewQuotationWindow : Window
    {
        public CurrentLogin CurrentLogin { get; set; }
        public NewQuotationWindow(CurrentLogin currentLogin)
        {
            InitializeComponent();
            this.CurrentLogin = currentLogin;
            StartQuotationProcess();
        }

        public void StartQuotationProcess()
        {
            DockingSetupModel layoutSetup = new DockingSetupModel();

             var document = new LayoutDocument()
            {
                ContentId   = "QM-001",
                IsActive    = true,
                Title       = "1. NEW QUOTATION SETUP",
                CanClose    = false,
                CanFloat    = true,
                IsMaximized = false,
                IconSource  = new BitmapImage(new Uri(@"../../Resources/Images/quote_4_24.png", UriKind.Relative))
            };
            layoutSetup.DockingManager = dockingManager;
            layoutSetup.DocumentPaneGroup = documentsPaneGroup;
            layoutSetup.DocumentPane = documentsPane;
            layoutSetup.Document = document;
            layoutSetup.LeftAnchorablePane = leftAnchorablePane;
            layoutSetup.RightAnchorablePane = rightAnchorablePane;
            layoutSetup.LeftAnchorable = null;
            layoutSetup.RightAnchorable = null;
            layoutSetup.LeftContentGrid = null;
            layoutSetup.LeftContentGrid = null;
            layoutSetup.RightContentGrid = null;
            layoutSetup.LeftAnchorablePane.Parent = layoutPanel;

            document.Content = new NewQuotationUserControl(layoutSetup, this.CurrentLogin);
            documentsPane.Children.Add(document);
            document.PreviousContainerIndex = documentsPane.Children.IndexOf(document);
            document.Parent = documentsPane;
            document.DockAsDocument();
        }
    }
}
