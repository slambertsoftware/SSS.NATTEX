using SSS.NATTEX.Models;
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
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainViewUserControl : UserControl
    {
        public CurrentLogin CurrentLogin { get; set; }
        public NavigationPaneUserControl NavigationControl { get; set; }
        public LayoutAnchorable Anchorable { get; set; }

        public MainViewUserControl(CurrentLogin currentLogin)
        {
            InitializeComponent();
            this.CurrentLogin = currentLogin;
        }

        private void mnuLibertyNewQuotation_Click(object sender, RoutedEventArgs e)
        {
            NewQuotationWindow window = new NewQuotationWindow(this.CurrentLogin);
            window.Owner = Application.Current.MainWindow;
            Point point = GetWindowPosition();

            window.Left = point.X;
            window.Top = point.Y;
            window.ShowDialog();
        }



        private void mnuAvbobNewQuotation_Click(object sender, RoutedEventArgs e)
        {
            AvbobNewQuotationWindow window = new AvbobNewQuotationWindow(this.CurrentLogin);
            window.Owner = Application.Current.MainWindow;
            Point point = GetWindowPosition();

            window.Left = point.X;
            window.Top = point.Y;
            window.ShowDialog();
        }

        private Point GetWindowPosition()
        {
            Point point = new Point();
            double windowWidth = Application.Current.MainWindow.ActualWidth;
            double windowHeight = Application.Current.MainWindow.ActualHeight;
            point.X = (Application.Current.MainWindow.ActualWidth / 3);
            point.Y = (windowHeight / 6);

            return point;
        }

        public void UpdateNavigation(ConfirmedQuotation message)
        {
            if (this.NavigationControl == null)
            {
                this.NavigationControl = new NavigationPaneUserControl(message);
            }
            else
            {
                this.NavigationControl.UpdatePendingQuotations(message);
            }
            if (this.NavigationControl.GetNumOfPendingQuotations() > 0)
            {
                this.Anchorable.IsVisible = true;
            }
            else
            {
                this.Anchorable.IsVisible = false;
            }
        }

        public void UpdateNavigation()
        {
            if (this.NavigationControl == null)
            {
                this.NavigationControl = new NavigationPaneUserControl();
                UpdateControlLayout();
            }
            if (this.NavigationControl.GetNumOfPendingQuotations() > 0)
            {
                this.Anchorable.IsVisible = true;
            }
            else
            {
                this.Anchorable.IsVisible = false;
            }
        }

        private void UpdateControlLayout()
        {
            this.Anchorable = new LayoutAnchorable()
            {
                ContentId = "AB-001",
                CanAutoHide = true,
                AutoHideHeight = 200,
                IsActive = true,
                Title = "WORK LIST",
                CanClose = true,
                CanFloat = false,
                IsMaximized = false,
                Content = this.NavigationControl,
                IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_4_24.png", UriKind.Relative))
            };

            this.Anchorable.Content = this.NavigationControl;
            leftAnchorablePane.Children.Add(this.Anchorable);
            this.Anchorable.PreviousContainerIndex = leftAnchorablePane.Children.IndexOf(this.Anchorable);
            this.Anchorable.Parent = leftAnchorablePane;
        }
    }
}
