using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class QuotationBodyItem
    {
        public string MonthlyPremiumDescription { get; set; }
        public string MonthlyPremiumCost { get; set; }

        public string MonthlyAdminFeeDescription { get; set; }
        public string MonthlyAdminFeeCost { get; set; }

        public string OnceOffJoiningFeeDescription { get; set; }
        public string OnceOffJoiningFeeCost { get; set; }

        private string TotalQuotationValue { get; set; }
        private string NumMonthlyInstallments { get; set; }
        private string MonthlyInstallments { get; set; }
    }
}
