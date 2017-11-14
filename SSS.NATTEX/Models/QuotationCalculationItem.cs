using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class QuotationCalculationItem
    {
        public string SchemeGroup { get; set; }
        public string NumOfGroups { get; set; }
        public string NumOfMembers { get; set; }
        public string CoverAmount { get; set; }
        public string TotalAmount { get; set; }
        public string TotalMembers { get; set; }
        public string TotalPremium { get; set; }
        public string AdminCost { get; set; }
        public string JoiningFee { get; set; }
        public string QuotationValue { get; set; }
    }
}
