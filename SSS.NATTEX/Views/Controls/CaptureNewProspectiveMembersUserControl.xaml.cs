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
    /// Interaction logic for CaptureNewProspectiveMembersUserControl.xaml
    /// </summary>
    public partial class CaptureNewProspectiveMembersUserControl : UserControl
    {
        public CaptureNewProspectiveMembersUserControl(DockingSetupModel layoutModel, NewQuotation quotationModel, CurrentLogin currentLogin)
        {
            InitializeComponent();
            var viewModel = new CaptureNewProspectiveMembersViewModel(layoutModel, quotationModel, currentLogin);
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
            (this.DataContext as CaptureNewProspectiveMembersViewModel).ValidateIDNumber();
            (this.DataContext as CaptureNewProspectiveMembersViewModel).UpdateBirthDateDetails();
        }


        private void NumberOfPrespectiveMembers_LostFocus(object sender, RoutedEventArgs e)
        {
           (this.DataContext as CaptureNewProspectiveMembersViewModel).UpdateRemainingMembers();
        }

        private void BirthYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as CaptureNewProspectiveMembersViewModel).UpdateCentury();
            (this.DataContext as CaptureNewProspectiveMembersViewModel).ValidateBirthYear();
        }


        private void BirthDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as CaptureNewProspectiveMembersViewModel).ValidateBirthDay();
        }

        private void BirthMonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as CaptureNewProspectiveMembersViewModel).ValidateBirthMonth();
        }

        private void CaptureMemberDetailsControl_Loaded(object sender, RoutedEventArgs e)
        {
            idNumber.Focus();
        }
    }
}
