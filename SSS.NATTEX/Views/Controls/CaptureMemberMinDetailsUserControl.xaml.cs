using SSS.NATTEX.Models;
using SSS.NATTEX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for CaptureMemberUserControl.xaml
    /// </summary>
    public partial class CaptureMemberMinDetailsUserControl : UserControl
    {
        public CaptureMemberMinDetailsUserControl(DockingSetupModel layoutModel, NewQuotation quotationModel)
        {
            InitializeComponent();
            var viewModel = new CaptureMemberMinDetailsViewModel(layoutModel, quotationModel);
            DataContext = viewModel;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            (sender as TextBox).Focus();
        }

        private bool IsYearRangeValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 1900 && i <= DateTime.Now.Year;
        }

        private void IdNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.DataContext as CaptureMemberMinDetailsViewModel).ValidateIDNumber();
            (this.DataContext as CaptureMemberMinDetailsViewModel).UpdateBirthDateDetails();
        }


        private void NumberOfPrespectiveMembers_LostFocus(object sender, RoutedEventArgs e)
        {
           (this.DataContext as CaptureMemberMinDetailsViewModel).UpdateRemainingMembers();
        }

        private void BirthYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as CaptureMemberMinDetailsViewModel).UpdateCentury();
            (this.DataContext as CaptureMemberMinDetailsViewModel).ValidateBirthYear();
        }


        private void BirthDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as CaptureMemberMinDetailsViewModel).ValidateBirthDay();
        }

        private void BirthMonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as CaptureMemberMinDetailsViewModel).ValidateBirthMonth();
        }

        private void CaptureMemberDetailsControl_Loaded(object sender, RoutedEventArgs e)
        {
            idNumber.Focus();
        }
    }
}
