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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewUserControl MainViewUserControl { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new HomeViewModel(this);
            DataContext = viewModel;
        }

        public void UpdateContent(string action)
        {
            if (action == "Logged In")
            {
                MainBorder.Background = null;
                this.MainViewUserControl = new MainViewUserControl((this.DataContext as HomeViewModel).CurrentLogin);
                ContentGrid.Children.Add(this.MainViewUserControl);
            }
            else
            {
                ContentGrid.Children.RemoveAt(0);
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/home1.jpg", UriKind.Absolute));
                MainBorder.Background = brush;
            }
        }

        public void UpdateNavigationControl(ConfirmedQuotation message)
        {
            if (this.MainViewUserControl != null)
            {
                this.MainViewUserControl.UpdateNavigation(message);
            }
        }

        public void UpdateNavigationControl()
        {
            if (this.MainViewUserControl != null)
            {
                this.MainViewUserControl.UpdateNavigation();
            }
        }
    }
}
