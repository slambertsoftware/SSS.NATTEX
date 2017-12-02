using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AvbobPendingQuotationPolicy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvbobPendingQuotationPolicyID { get; set; }

        public int AvbobPendingQuotationPolicyBookID { get; set; }

        public int AvbobPendingQuotationID { get; set; }

        public string  PolicyNumber { get; set; }

        public decimal MonthlyMemberPremium { get; set; }

        public decimal MonthlyMemberCommissionPecentage { get; set; }

        public decimal MonthlyMemberCommission { get; set; }

        public decimal TotalMonthlyMemberPremium { get; set; }

        public decimal CompanyMemberPremium { get; set; }

        public string Beneficiary { get; set; }

        public string BeneficiaryIDNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? RemoveDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int CreateUserID { get; set; }

        public int? ModifyUserID { get; set; }

        public int? RemoveUserID { get; set; }

        public virtual AvbobPendingQuotationPolicyBook AvbobPendingQuotationPolicyBook { get; set; }
        public virtual ICollection<AvbobPendingQuotation> AvbobPendingQuotations { get; set; }
        public virtual ICollection<AvbobPendingQuotationPolicyMember> AvbobPendingQuotationPolicyMembers { get; set; }
    }
}
