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

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainViewUserControl : UserControl
    {
        public CurrentLogin CurrentLogin { get; set; }
        public MainViewUserControl(CurrentLogin currentLogin)
        {
            InitializeComponent();
            this.CurrentLogin = currentLogin;
        }

        private void mnuNewQuotation_Click(object sender, RoutedEventArgs e)
        {
            NewQuotationWindow window = new NewQuotationWindow(this.CurrentLogin);
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
    }
}
