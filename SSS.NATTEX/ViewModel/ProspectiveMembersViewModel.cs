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
        #region fields
        private ObservableCollection<ProspectiveMember> _procespectiveMembers;
        private bool _isMemberCheckListEnabled;
        #endregion

        #region properties
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
        #endregion

        #region constructors
        public ProspectiveMembersViewModel()
        {
            ProspectiveMembers = new ObservableCollection<ProspectiveMember>();
        }
        #endregion

        #region methods
        public void AddProspectiveMember(ProspectiveMember member)
        {
            if (this.ProspectiveMembers == null)
            {
                this.ProspectiveMembers = new ObservableCollection<ProspectiveMember>();
            }
            this.ProspectiveMembers.Add(member);
        }

        public void RemoveProspectiveMember(ProspectiveMember member)
        {
            this.ProspectiveMembers.Remove(member);
        }

        #endregion
    }
}
