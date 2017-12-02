using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AvbobPendingQuotationPolicySummary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvbobPendingQuotationPolicySummaryID { get; set; }

        public int AvbobPendingQuotationID { get; set; }

        public decimal TotalMonthlyMemberPremium { get; set; }

        public decimal TotalMonthlyMemberCommission { get; set; }

        public decimal TotalMonthlyMemberPremiumTotal { get; set; }

        public decimal TotalCompanyMemberPremium { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? RemoveDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int CreateUserID { get; set; }

        public int? ModifyUserID { get; set; }

        public int? RemoveUserID { get; set; }

        public virtual AvbobPendingQuotation AvbobPendingQuotation { get; set; }

    }
}
