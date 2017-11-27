using SSS.NATTEX.DAL;
using SSS.NATTEX.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace SSS.NATTEX.ViewModel
{
    public class QuotationDetailViewModel : MainViewModel
    {
        #region fields
        private LibertyPendingQuotation _pendingQuotation { get; set; }
        private string _windowCaption;
        private string _quotationTabHeader;
        private string _quotationHeader;
        private string _libertyPendingQuotationID;
        private string _quotationNumber;
        private string _isExistingCustomer;
        private string _customerAddress;
        private string _customerContactNumber;
        private string _customerEmailAddress;
        private string _customerOtherInfo;
        private string _pricingModel;
        private string _quotationPreparedBy;
        private string _numberOfProspectiveMembers;
        private string _coverAmount;
        private string _isCoverAmountAppliedToAll;
        private string _quotationStatus;
        private string _quotationValue;
        private string _quotationCreateDate;
        private string _quotationExpiryDate;
        private string _adminFee;
        private string _totalJoiningFee;
        private string _joiningFeePerMember;
        private string _joiningFeeMessage;
        private string _numOfMonthlyInstallments;
        private string _installmentJoiningFee;
        private string _additionDocumentsUploaded;
        private string _quotationDocumentTabHeader;
        private FixedDocumentSequence _quotationXPSDocument;

        private ObservableCollection<LibertyPendingQuotationMember> _pendingQuotationMembers;
        #endregion

        #region properties
        public LibertyPendingQuotation PendingQuotation
        {
            get
            {
                return _pendingQuotation;
            }
            set
            {
                _pendingQuotation = value;
                this.RaisePropertyChanged("PendingQuotation");
            }

        }

        public string WindowCaption
        {
            get
            {
                return _windowCaption;
            }
            set
            {
                _windowCaption = value;
                this.RaisePropertyChanged("WindowCaption");
            }
        }

        public string QuotationTabHeader
        {
            get
            {
                return _quotationTabHeader;
            }
            set
            {
                _quotationTabHeader = value;
                this.RaisePropertyChanged("QuotationTabHeader");
            }
        }

        public string QuotationHeader
        {
            get
            {
                return _quotationHeader;
            }
            set
            {
                _quotationHeader = value;
                this.RaisePropertyChanged("QuotationHeader");
            }
        }

        public string LibertyPendingQuotationID
        {
            get
            {
                return _libertyPendingQuotationID;
            }
            set
            {
                _libertyPendingQuotationID = value;
                this.RaisePropertyChanged("LibertyPendingQuotationID");
            }
        }

        public string QuotationNumber
        {
            get
            {
                return _quotationNumber;
            }
            set
            {
                _quotationNumber = value;
                this.RaisePropertyChanged("QuotationNumber");
            }
        }

        public string IsExistingCustomer
        {
            get
            {
                return _isExistingCustomer;
            }
            set
            {
                _isExistingCustomer = value;
                this.RaisePropertyChanged("IsExistingCustomer");
            }
        }

        public string CustomerAddress
        {
            get
            {
                return _customerAddress;
            }
            set
            {
                _customerAddress = value;
                this.RaisePropertyChanged("CustomerAddress");
            }
        }

        public string CustomerContactNumber
        {
            get
            {
                return _customerContactNumber;
            }
            set
            {
                _customerContactNumber = value;
                this.RaisePropertyChanged("CustomerContactNumber");
            }
        }

        public string CustomerEmailAddress
        {
            get
            {
                return _customerEmailAddress;
            }
            set
            {
                _customerEmailAddress = value;
                this.RaisePropertyChanged("CustomerEmailAddress");
            }
        }

        public string CustomerOtherInfo
        {
            get
            {
                return _customerOtherInfo;
            }
            set
            {
                _customerOtherInfo = value;
                this.RaisePropertyChanged("CustomerOtherInfo");
            }
        }

        public string PricingModel
        {
            get
            {
                return _pricingModel;
            }
            set
            {
                _pricingModel = value;
                this.RaisePropertyChanged("PricingModel");
            }
        }

        public string QuotationPreparedBy
        {
            get
            {
                return _quotationPreparedBy;
            }
            set
            {
                _quotationPreparedBy = value;
                this.RaisePropertyChanged("QuotationPreparedBy");
            }
        }

        public string NumberOfProspectiveMembers
        {
            get
            {
                return _numberOfProspectiveMembers;
            }
            set
            {
                _numberOfProspectiveMembers = value;
                this.RaisePropertyChanged("NumberOfProspectiveMembers");
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

        public string IsCoverAmountAppliedToAll
        {
            get
            {
                return _isCoverAmountAppliedToAll;
            }
            set
            {
                _isCoverAmountAppliedToAll = value;
                this.RaisePropertyChanged("IsCoverAmountAppliedToAll");
            }
        }

        public string QuotationStatus
        {
            get
            {
                return _quotationStatus;
            }
            set
            {
                _quotationStatus = value;
                this.RaisePropertyChanged("QuotationStatus");
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

        public string QuotationCreateDate
        {
            get
            {
                return _quotationCreateDate;
            }
            set
            {
                _quotationCreateDate = value;
                this.RaisePropertyChanged("QuotationCreateDate");
            }
        }

        public string QuotationExpiryDate
        {
            get
            {
                return _quotationExpiryDate;
            }
            set
            {
                _quotationExpiryDate = value;
                this.RaisePropertyChanged("QuotationExpiryDate");
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

        public string TotalJoiningFee
        {
            get
            {
                return _totalJoiningFee;
            }
            set
            {
                _totalJoiningFee = value;
                this.RaisePropertyChanged("TotalJoiningFee");
            }
        }

        public string JoiningFeePerMember
        {
            get
            {
                return _joiningFeePerMember;
            }
            set
            {
                _joiningFeePerMember = value;
                this.RaisePropertyChanged("JoiningFeePerMember");
            }
        }

        public string NumOfMonthlyInstallments
        {
            get
            {
                return _numOfMonthlyInstallments;
            }
            set
            {
                _numOfMonthlyInstallments = value;
                this.RaisePropertyChanged("NumOfMonthlyInstallments");
            }
        }

        public string JoiningFeeMessage
        {
            get
            {
                return _joiningFeeMessage;
            }
            set
            {
                _joiningFeeMessage = value;
                this.RaisePropertyChanged("JoiningFeeMessage");
            }
        }

        public string InstallmentJoiningFee
        {
            get
            {
                return _installmentJoiningFee;
            }
            set
            {
                _installmentJoiningFee = value;
                this.RaisePropertyChanged("InstallmentJoiningFee");
            }
        }

        public string AdditionDocumentsUploaded
        {
            get
            {
                return _additionDocumentsUploaded;
            }
            set
            {
                _additionDocumentsUploaded = value;
                this.RaisePropertyChanged("AdditionDocumentsUploaded");
            }
        }

        public string QuotationDocumentTabHeader
        {
            get
            {
                return _quotationDocumentTabHeader;
            }
            set
            {
                _quotationDocumentTabHeader = value;
                this.RaisePropertyChanged("QuotationDocumentTabHeader");
            }
        }

        public FixedDocumentSequence QuotationXPSDocument
        {
            get
            {
                return _quotationXPSDocument;
            }
            set
            {
                _quotationXPSDocument = value;
                this.RaisePropertyChanged("QuotationXPSDocument");
            }
        }

        public System.Windows.Window CurrentWindow { get; set; }

        public ObservableCollection<LibertyPendingQuotationMember> PendingQuotationMembers
        {
            get
            {
                return _pendingQuotationMembers;
            }
            set
            {
                _pendingQuotationMembers = value;
                this.RaisePropertyChanged("PendingQuotationMembers");
            }
        }

        #endregion

        #region constructors
        public QuotationDetailViewModel(System.Windows.Window window, LibertyPendingQuotation pendingQuotation)
        {
            this.CurrentWindow = (window as QuotationDetailWindow);
            this.WindowCaption = "Confirmed Quoation No: " + pendingQuotation.QuotationNumber;
            this.PendingQuotation = pendingQuotation;
           
            this.QuotationTabHeader = pendingQuotation.QuotationNumber;
            this.QuotationHeader = pendingQuotation.QuotationHeader;
            this.LibertyPendingQuotationID = Convert.ToString(pendingQuotation.LibertyPendingQuotationID);
            this.QuotationNumber = pendingQuotation.QuotationNumber;
            this.IsExistingCustomer = pendingQuotation.IsExistingCustomer ? "Yes" : "No";
            this.CustomerAddress = pendingQuotation.CustomerAddress;
            this.CustomerEmailAddress = pendingQuotation.CustomerEmailAddress;
            this.CustomerContactNumber = pendingQuotation.CustomerContactNumber;
            this.CustomerOtherInfo = pendingQuotation.CustomerOtherInfo;
            this.PricingModel = pendingQuotation.PricingModel;
            this.QuotationPreparedBy = PendingQuotation.QuotationPreparedBy;
            this.NumberOfProspectiveMembers = PendingQuotation.NumberOfProspectiveMembers;
            this.CoverAmount = PendingQuotation.CoverAmount;
            this.IsCoverAmountAppliedToAll = PendingQuotation.IsCoverAmountAppliedToAll ? "Yes" : "No";
            if (PendingQuotation.IsConfirmed)
            {
                this.QuotationStatus = "Confirmed";
            }
            else
            {
                this.QuotationStatus = "Unknown. Please contact the system operator to correct.";
            }
            this.AdminFee = Convert.ToString(pendingQuotation.AdminFee);
            this.JoiningFeePerMember = Convert.ToString(pendingQuotation.JoiningFeePerMember);
            this.TotalJoiningFee = Convert.ToString(pendingQuotation.JoiningFee);
            this.NumOfMonthlyInstallments = Convert.ToString(pendingQuotation.NumOfMonthlyInstallments);
            this.InstallmentJoiningFee = Convert.ToString(pendingQuotation.InstallmentJoiningFee);
            this.JoiningFeeMessage = pendingQuotation.JoiningFeeMessage;

            this.QuotationValue = Convert.ToString(PendingQuotation.QuotationValue);
            this.QuotationCreateDate = pendingQuotation.QuotationCreateDate;
            this.QuotationExpiryDate = pendingQuotation.QuotationExpiryDate;
  
            if ((pendingQuotation.QuotationXPSDocumentPath != null) && File.Exists(pendingQuotation.QuotationXPSDocumentPath)) {
                XpsDocument document = new XpsDocument(pendingQuotation.QuotationXPSDocumentPath, System.IO.FileAccess.Read);
                if (document != null)
                {
                    this.QuotationTabHeader = pendingQuotation.QuotationNumber;
                    this.QuotationDocumentTabHeader = "Quotation Document";
                    this.QuotationXPSDocument = document.GetFixedDocumentSequence();
                }
            }

            using (var context = new NattexApplicationContext())
            {
                List<LibertyPendingQuotationMember> members = context.LibertyPendingQuotationMembers.Where(x => x.LibertyPendingQuotationID == pendingQuotation.LibertyPendingQuotationID && x.IsActive == true).ToList<LibertyPendingQuotationMember>();
                if (members != null)
                {
                    this.PendingQuotationMembers = new ObservableCollection<LibertyPendingQuotationMember>(members);
                }

                if (context.LibertyPendingQuotationDocuments.ToList().Count > 0)
                {
                    this.AdditionDocumentsUploaded = "Yes";
                    (this.CurrentWindow as QuotationDetailWindow).LoadDocuments(context.LibertyPendingQuotationDocuments.ToList());
                }
                else
                {
                    this.AdditionDocumentsUploaded = "No";
                }
            }
        }
        #endregion

        #region methods

        #endregion

    }
}
