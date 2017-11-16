using SSS.NATTEX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class QuotationCalculationItem : MainViewModel
    {
        #region fields
        private string _schemeGroup;
        private string _groupName;
        #endregion
        public int ID { get; set; }
        public string SchemeGroup
        {
            get
            {
                return _schemeGroup;
            }
            set
            {
                _schemeGroup = value;
                this.RaisePropertyChanged("SchemeGroup");
            }
        }
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
                this.RaisePropertyChanged("GroupName");
            }
        }
        public string GroupNumber { get; set; }
        public string NumOfMembers { get; set; }
        public string CoverAmount { get; set; }
        public string GroupPremiumAmount { get; set; }
        public string TotalMembers { get; set; }
        public string TotalPremium { get; set; }
        public string Comment { get; set; }
        public string AdminHeading { get; set; }
        public string AdminFee { get; set; }
        public string JoiningFeeHeading { get; set; }
        public string JoiningFeeDescription { get; set; }
        public string JoiningFee { get; set; }
        public string MonthlyInstallmentDescription { get; set; }
        public string QuotationValueDescription { get; set; }
        public string QuotationValue { get; set; }
        public bool   IsSubTotalItem { get; set; }
        public bool   IsAdminHeadingItem { get; set; }
        public bool   IsAdminFeeItem { get; set; }
        public bool   IsJoiningFeeHeadingItem { get; set; }
        public bool   IsJoiningFeeItem { get; set; }
        public bool   IsMonthlyInstallmentItem { get; set; }
        public bool   IsTotalQuotationValueDescriptionItem { get; set; }
        public bool   IsTotalQuotationValueItem { get; set; }
    }
}
