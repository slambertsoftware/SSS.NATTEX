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
        private string _groupNumber;
        private string _numOfMembers;
        private string _coverAmount;
        private string _groupPremiumAmount;
        private string _totalMembers;
        private string _totalPremium;
        private string _comment;
        private string _adminHeading;
        private string _adminFee;
        private string _joiningFeeHeading;
        private string _joiningFeeDescription;
        private string _joiningFee;
        private string _monthlyInstallmentDescription;
        private string _quotationValue;

        private bool _isHeadersItem;
        private bool _isSubTotalItem;
        private bool _isAdminHeadingItem;
        private bool _isAdminFeeItem;
        private bool _isJoiningFeeHeadingItem;
        private bool _isJoiningFeeItem;
        private bool _isMonthlyInstallmentItem;
        private bool _isTotalQuotationValueDescriptionItem;
        private bool _isTotalQuotationValueItem;
        private bool _isQuotationItem;

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
        public string GroupNumber
        {
            get
            {
                return _groupNumber;
            }
            set
            {
                _groupNumber = value;
                this.RaisePropertyChanged("GroupNumber");
            }
        }
        public string NumOfMembers
        {
            get
            {
                return _numOfMembers;
            }
            set
            {
                _numOfMembers = value;
                this.RaisePropertyChanged("GroupNumber");
            }
        }
        public string CoverAmount
        {
            get
            {
                return _coverAmount;
            }
            set
            {
                _coverAmount = value;
                this.RaisePropertyChanged("CoverAmount");
            }
        }
        public string GroupPremiumAmount
        {
            get
            {
                return _groupPremiumAmount;
            }
            set
            {
                _groupPremiumAmount = value;
                this.RaisePropertyChanged("GroupPremiumAmount");
            }
        }
        public string TotalMembers
        {
            get
            {
                return _totalMembers;
            }
            set
            {
                _totalMembers = value;
                this.RaisePropertyChanged("TotalMembers");
            }
        }

        public string TotalPremium
        {
            get
            {
                return _totalPremium;
            }
            set
            {
                _totalPremium = value;
                this.RaisePropertyChanged("TotalPremium");
            }
        }
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                this.RaisePropertyChanged("Comment");
            }
        }
        public string AdminHeading
        {
            get
            {
                return _adminHeading;
            }
            set
            {
                _adminHeading = value;
                this.RaisePropertyChanged("AdminHeading");
            }
        }
        public string AdminFee
        {
            get
            {
                return _adminFee;
            }
            set
            {
                _adminFee = value;
                this.RaisePropertyChanged("AdminFee");
            }
        }

        public string JoiningFeeHeading
        {
            get
            {
                return _joiningFeeHeading;
            }
            set
            {
                _joiningFeeHeading = value;
                this.RaisePropertyChanged("JoiningFeeHeading");
            }
        }
        public string JoiningFeeDescription
        {
            get
            {
                return _joiningFeeDescription;
            }
            set
            {
                _joiningFeeDescription = value;
                this.RaisePropertyChanged("JoiningFeeDescription");
            }
        }


        public string JoiningFee
        {
            get
            {
                return _joiningFee;
            }
            set
            {
                _joiningFee = value;
                this.RaisePropertyChanged("JoiningFee");
            }
        }
        public string MonthlyInstallmentDescription
        {
            get
            {
                return _monthlyInstallmentDescription;
            }
            set
            {
                _monthlyInstallmentDescription = value;
                this.RaisePropertyChanged("MonthlyInstallmentDescription");
            }
        }
        public string QuotationValueDescription
        {
            get
            {
                return _monthlyInstallmentDescription;
            }
            set
            {
                _monthlyInstallmentDescription = value;
                this.RaisePropertyChanged("QuotationValueDescription");
            }
        }
        public string QuotationValue
        {
            get
            {
                return _quotationValue;
            }
            set
            {
                _quotationValue = value;
                this.RaisePropertyChanged("QuotationValue");
            }
        }
        public bool   IsQuotationItem
        {
            get
            {
                return _isQuotationItem;
            }
            set
            {
                _isQuotationItem = value;
                this.RaisePropertyChanged("IsQuotationItem");
            }
        }
        public bool   IsHeadersItem
        {
            get
            {
                return _isHeadersItem;
            }
            set
            {
                _isHeadersItem = value;
                this.RaisePropertyChanged("IsHeadersItem");
            }
        }
        public bool   IsSubTotalItem
        {
            get
            {
                return _isSubTotalItem;
            }
            set
            {
                _isSubTotalItem = value;
                this.RaisePropertyChanged("IsSubTotalItem");
            }
        }
        public bool   IsAdminHeadingItem
        {
            get
            {
                return _isAdminHeadingItem;
            }
            set
            {
                _isAdminHeadingItem = value;
                this.RaisePropertyChanged("IsAdminHeadingItem");
            }
        }
        public bool   IsAdminFeeItem
        {
            get
            {
                return _isAdminFeeItem;
            }
            set
            {
                _isAdminFeeItem = value;
                this.RaisePropertyChanged("IsAdminFeeItem");
            }
        }
        public bool   IsJoiningFeeHeadingItem
        {
            get
            {
                return _isJoiningFeeHeadingItem;
            }
            set
            {
                _isJoiningFeeHeadingItem = value;
                this.RaisePropertyChanged("IsJoiningFeeHeadingItem");
            }
        }
        public bool   IsJoiningFeeItem
        {
            get
            {
                return _isJoiningFeeItem;
            }
            set
            {
                _isJoiningFeeItem = value;
                this.RaisePropertyChanged("IsJoiningFeeItem");
            }
        }
        public bool   IsMonthlyInstallmentItem
        {
            get
            {
                return _isMonthlyInstallmentItem;
            }
            set
            {
                _isMonthlyInstallmentItem = value;
                this.RaisePropertyChanged("IsMonthlyInstallmentItem");
            }
        }
        public bool   IsTotalQuotationValueDescriptionItem
        {
            get
            {
                return _isTotalQuotationValueDescriptionItem;
            }
            set
            {
                _isTotalQuotationValueDescriptionItem = value;
                this.RaisePropertyChanged("IsTotalQuotationValueDescriptionItem");
            }
        }
        public bool   IsTotalQuotationValueItem
        {
            get
            {
                return _isTotalQuotationValueItem;
            }
            set
            {
                _isTotalQuotationValueItem = value;
                this.RaisePropertyChanged("IsTotalQuotationValueItem");
            }
        }
    }
}
