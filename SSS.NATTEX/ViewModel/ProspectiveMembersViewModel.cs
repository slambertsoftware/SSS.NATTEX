using SSS.NATTEX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.ViewModel
{
    public class ProspectiveMembersViewModel: MainViewModel
    {
        private ObservableCollection<ProspectiveMember> _procespectiveMembers;
        private bool _isMemberCheckListEnabled;

        public ObservableCollection<ProspectiveMember> ProspectiveMembers
        {
            get
            {
                return _procespectiveMembers;
            }
            set
            {
                _procespectiveMembers = value;
                this.RaisePropertyChanged("ProspectiveMembers");
            }
        }

        public bool IsMemberCheckListEnabled
        {
            get
            {
                return _isMemberCheckListEnabled;
            }
            set
            {
                _isMemberCheckListEnabled = value;
                this.RaisePropertyChanged("IsMemberCheckListEnabled");
            }
        }

        public ProspectiveMembersViewModel()
        {
            ProspectiveMembers = new ObservableCollection<ProspectiveMember>();
        }
    }
}
