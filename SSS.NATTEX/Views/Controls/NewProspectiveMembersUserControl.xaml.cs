using SSS.NATTEX.Models;
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

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for NewProspectiveMembersUserControl.xaml
    /// </summary>
    public partial class NewProspectiveMembersUserControl : UserControl
    {
        public NewProspectiveMembersUserControl()
        {
            InitializeComponent();
            var viewModel = new ProspectiveMembersViewModel();
            DataContext = viewModel;
        }

        public void AddProspectiveMember(ProspectiveMember member)
        {
            (this.DataContext as ProspectiveMembersViewModel).AddProspectiveMember(member);
        }

        public void RemoveProspectiveMember(ProspectiveMember member)
        {
            (this.DataContext as ProspectiveMembersViewModel).RemoveProspectiveMember(member);
        }
    }
}
