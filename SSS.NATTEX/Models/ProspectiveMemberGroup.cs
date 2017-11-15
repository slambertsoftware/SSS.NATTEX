using SSS.NATTEX.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class ProspectiveMemberGroup : MainViewModel
    {
        #region properties
        private string _groupName;
        private ObservableCollection<ProspectiveMember> _prospectiveMembers;

        #endregion
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
                this.RaisePropertyChanged("GroupName");
            }

        }

        public ObservableCollection<ProspectiveMember> ProspectiveMembers
        {
            get
            {
                return _prospectiveMembers;
            }
            set
            {
                _prospectiveMembers = value;
                this.RaisePropertyChanged("ProspectiveMembers");
            }

        }
    }
}
