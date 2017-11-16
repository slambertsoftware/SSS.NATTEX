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

        #region fields
        private string _groupSchemeName;
        private string _groupName;
        private string _groupCoverAmount;
        private ObservableCollection<ProspectiveMember> _prospectiveMembers;

        #endregion

        #region properties
        public string GroupSchemeName
        {
            get
            {
                return _groupSchemeName;
            }
            set
            {
                _groupSchemeName = value;
                this.RaisePropertyChanged("GroupSchemeName");
            }

        }

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

        public string GroupCoverAmount
        {
            get
            {
                return _groupCoverAmount;
            }
            set
            {
                _groupCoverAmount = value;
                this.RaisePropertyChanged("GroupCoverAmount");
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
        #endregion
    }
}
