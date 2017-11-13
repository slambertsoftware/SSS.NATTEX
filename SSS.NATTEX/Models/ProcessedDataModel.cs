using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class ProcessedDataModel
    {
        public List<AgeGroupModel> AgeGroups { get; set; }
        public MemberSchemeGroup MemberSchemeGroups { get; set; }
        public MemberSchemeGroupListModel  MemberSchemeGroupList { get; set; }
    }
}
