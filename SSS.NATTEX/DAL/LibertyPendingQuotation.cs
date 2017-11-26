using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class LibertyPendingQuotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibertyPendingQuotationID { get; set; }

        public string QuotationHeader { get; set; }

        public string QuotationNumber { get; set; }
  
        public string QuotationType { get; set; }
 
        public bool IsExistingCustomer { get; set; }
  
        public string SelectedCustomer { get; set; }
  
        public int CustomerID { get; set; }
        public int NumOfMonthlyInstallments { get; set; }
        public int QuotationValidDays { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerOtherInfo { get; set; }
        public string PricingModel { get; set; }
        public string QuotationPreparedBy { get; set; }
        public string NumberOfProspectiveMembers { get; set; }
        public string CoverAmount { get; set; }
        public bool IsCoverAmountAppliedToAll { get; set; }
        public string  MonthlyPremiumDescription { get; set; }
        public decimal MonthlyPremium { get; set; }
        public string MonthlyAdminFeeDescription { get; set; }
        public decimal AdminFee { get; set; }
        public decimal JoiningFeePerMember { get; set; }
        public decimal JoiningFee { get; set; }
        public string  JoiningFeeDescription { get; set; }
        public string  JoiningFeeMessage { get; set; }
        public decimal InstallmentJoiningFee { get; set; }
        public decimal QuotationValue { get; set; }
        public string QuotationCreateDate { get; set; }
        public string QuotationExpiryDate { get; set; }
        public string QuotationStatus { get; set; }

        public bool IsActive { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsAccepted { get; set; }

        public DateTime? AcceptedDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public virtual ICollection<LibertyPendingQuotationDocument> PendingQuotationDocuments { get; set; }
        public virtual ICollection<LibertyPendingQuotationMember> PendingQuotationMembers { get; set; }
        public virtual ICollection<LibertyPendingQuotationMemberScheme> PendingQuotationMemberSchemes { get; set; }
    }
}
