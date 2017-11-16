using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class CoverPremium
    {
        public int ID { get; set; }
        public int PricingModelID { get; set; }
        public string  SchemeName { get; set; }
        public decimal CoverAmount { get; set; }
        public int  StartAge { get; set; }
        public int  EndAge { get; set; }
        public string AgeRestriction { get; set; }
        public decimal PremiumAmount { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int RemoveUserID { get; set; }
    }
}
