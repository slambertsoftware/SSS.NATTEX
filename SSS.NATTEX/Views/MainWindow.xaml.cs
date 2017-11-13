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
using System.Windows.Shapes;

namespace SSS.NATTEX.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewQuotationWindow window = new NewQuotationWindow();
            window.Owner = Application.Current.MainWindow;
            Point point = GetWindowPosition();

            window.Left = point.X;
            window.Top  = point.Y;
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
