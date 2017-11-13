using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class MemberSchemeGroupListModel
    {
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public List<List<ProspectiveMember>> GroupList { get; set; }
    }
}
