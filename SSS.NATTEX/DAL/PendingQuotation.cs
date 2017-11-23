﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class PendingQuotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PendingQuotationID { get; set; }

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
        public decimal TotalMonthlyPremium { get; set; }
        public decimal AdminFee { get; set; }
        public decimal JoiningFeePerMember { get; set; }
        public decimal JoiningFee { get; set; }
        public string JoiningFeeDescription { get; set; }

        public decimal MonthlyJoiningFee { get; set; }
        public decimal QuotationValue { get; set; }
        public string QuotationCreateDate { get; set; }
        public string QuotationExpiryDate { get; set; }

       
        public string MonthlyPremiumDescription { get; set; }
        public string MonthlyAdminFeeDescription { get; set; }


        public bool IsActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public virtual ICollection<PendingQuotationDocument> PendingQuotationDocuments { get; set; }
        public virtual ICollection<PendingQuotationMember> PendingQuotationMembers { get; set; }
        public virtual ICollection<PendingQuotationMemberScheme> PendingQuotationMemberSchemes { get; set; }
    }
}
