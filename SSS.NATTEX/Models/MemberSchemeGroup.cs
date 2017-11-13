using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class MemberSchemeGroup
    {
        public List<ProspectiveMember> Members { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
    }
}
