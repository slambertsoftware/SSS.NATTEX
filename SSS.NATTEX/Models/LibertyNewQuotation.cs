using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;

namespace SSS.NATTEX.Models
{
    public class LibertyNewQuotation
    {
        public int    QuotationID { get; set; }
        public string QuotationHeader { get; set; }
        public string QuotationNumber { get; set; }
        public string QuotationType { get; set; }
        public bool   IsExistingCustomer { get; set; }
        public string SelectedCustomer { get; set; }
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
        public bool   IsCoverAmountAppliedToAll { get; set; }
        public decimal TotalMonthlyPremium { get; set; }
        public decimal AdminFee { get; set; }
        public decimal JoiningFeePerMember { get; set; }
        public decimal JoiningFee { get; set; }
        public string JoiningFeeDescription { get; set; }
        public int NumOfMonthlyInstallments { get; set; }
        public decimal InstallmentJoiningFee { get; set; }
        public decimal QuotationValue { get; set; }
        public string QuotationCreateDate { get; set; }
        public string QuotationExpiryDate { get; set; }

        public int    QuotatationValidDays { get; set; }
        public string MonthlyPremiumDescription { get; set; }
        public string MonthlyAdminFeeDescription { get; set; }
        public XpsDocument QuotationXPSDocument { get; set; }
        public List<QuotationUploadDocument> QuotationDocuments { get; set; }
        public List<ProspectiveMember> ProspectiveMembers { get; set; }
        public List<ProspectiveMemberScheme> ProspectiveMemberSchemes { get; set; }
    }
}
