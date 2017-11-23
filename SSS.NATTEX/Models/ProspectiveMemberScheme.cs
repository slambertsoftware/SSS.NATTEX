using SSS.NATTEX.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class ProspectiveMemberScheme:  MainViewModel, IEquatable<ProspectiveMemberScheme>
    {
        #region fields
        private string _schemeName;
        private ObservableCollection<ProspectiveMemberGroup> _prospectiveMemberGroup;
        #endregion

        #region properties
        public int ID { get; set; }
        public string SchemeName
        {
            get
            {
                return _schemeName;
            }
            set
            {
                _schemeName = value;
                this.RaisePropertyChanged("SchemeName");
            }
        }
        public ObservableCollection<ProspectiveMemberGroup> ProspectiveMemberGroups
        {
            get
            {
                return _prospectiveMemberGroup;
            }
            set
            {
                _prospectiveMemberGroup = value;
                this.RaisePropertyChanged("ProspectiveMemberGroup");
            }
        }
        #endregion

        #region constructors
        public ProspectiveMemberScheme(string schemeName)
        {
            SchemeName = schemeName;
            if (this.ProspectiveMemberGroups == null)
            {
                this.ProspectiveMemberGroups = new ObservableCollection<ProspectiveMemberGroup>();
            }
        }
        #endregion

        public void AddProspectiveMemberGroup(ProspectiveMemberGroup memberGroup)
        {
            this.ProspectiveMemberGroups.Add(memberGroup);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ProspectiveMemberScheme objAsPart = obj as ProspectiveMemberScheme;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public bool Equals(ProspectiveMemberScheme other)
        {
            if (other == null) return false;
            return (this.SchemeName.Equals(other.SchemeName));
        }
    }
}
