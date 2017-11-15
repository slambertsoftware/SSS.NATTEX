using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class ProcessedDataModel
    {
        public List<AgeGroup> AgeGroups { get; set; }
        public MemberSchemeGroup MemberSchemeGroups { get; set; }
        public MemberSchemeGroupListModel  MemberSchemeGroupList { get; set; }
    }
}
