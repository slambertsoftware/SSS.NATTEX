using SSS.NATTEX.Models;
using SSS.NATTEX.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NewProspectiveMemberSchemeUserControl.xaml
    /// </summary>
    public partial class NewProspectiveMemberSchemeUserControl : UserControl
    {
        public NewProspectiveMemberSchemeUserControl(string coverAmount, CurrentLogin currentLogin, int pendingQuotationLoginID)
        {
            InitializeComponent();
            var viewModel = new NewProspectiveMemberSchemeViewModel(coverAmount, currentLogin, pendingQuotationLoginID);
            DataContext = viewModel;
        }

        public void AddProspectiveMembers(List<ProspectiveMember> members)
        {
            (this.DataContext as NewProspectiveMemberSchemeViewModel).ProspectiveMemberSchemes = new ObservableCollection<ProspectiveMemberScheme>();
            (this.DataContext as NewProspectiveMemberSchemeViewModel).AddProspectiveMembers(members);
            (this.DataContext as NewProspectiveMemberSchemeViewModel).ProcessProspectiveMembers();
        }

        public void ProcessProspectiveMembers()
        {
            (this.DataContext as NewProspectiveMemberSchemeViewModel).ProcessProspectiveMembers();
        }

        public List<ProspectiveMemberScheme>  GetProspectiveMemberSchemes()
        {
           return (this.DataContext as NewProspectiveMemberSchemeViewModel).ProspectiveMemberSchemes.ToList();
        }
    }
}
