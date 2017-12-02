using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class AvbobPolicyScheduleItem
    {
        public string PolicyNumber { get; set; }
        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string CoverAmount { get; set; }
        public bool IsHeadersItem { get; set; }
        public bool IsPolicyScheduleDataItem { get; set; }
        public bool IsPolicyScheduleSummaryItem { get; set; }
    }
}
