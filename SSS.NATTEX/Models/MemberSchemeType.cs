using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class MemberSchemeType
    {
        public string SchemGroupName { get; set; }
        public string Description { get; set; }
        public ObservableCollection<ProspectiveMember> Members { get; set; }
        public ObservableCollection<List<ProspectiveMember>> MembersList { get; set; }

        public MemberSchemeType(string schemeName, string description)
        {
            SchemGroupName = schemeName;
            Description = description;
            Members = new ObservableCollection<ProspectiveMember>();
            MembersList = new ObservableCollection<List<ProspectiveMember>>();
        }
    }
}
