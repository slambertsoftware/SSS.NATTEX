using GalaSoft.MvvmLight.Command;
using OfficeOpenXml;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views.Controls.Avbob;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.ViewModel.Avbob
{
    public class AvbobNewQuotationViewModel : MainViewModel
    {
        #region fields
        private CurrentLogin _currentLogin;
        private string _controlCaption;
        private string _selectedCustomerName;
        private string _customerName;
        private string _customerNumber;
        private string _customerAddress;
        private string _customerContactNo;
        private string _customerEmail;
        private string _customerOtherInfo;
        private string _validationMessage;
        private string _importFileName;
        private string _uploadFileName;
        private string _uploadFileDescription;
        private string _quotationNumber;
        private string _pendingQuotationPolicyBookName;
        private string _currentImportFilePath;
        private string _currentScheduleOutputFilePath;
        private string _documentOutputDirectory;
        private double _spinningWheelRadius;
        private double _spinningDotRadius;
        private double _spinningDotSpeed;
        private int _spinningDotCount;
        private SolidColorBrush _spinningDotColor;
        
        private int _customerID;
        private int _pendingQuotationID;
        private int _pendingQuotationPolicyBookID;


        private bool _isValidInput;
        private bool _isExistingCustomerChecked;
        private bool _isFileBrowseButtonEnabled;
        private bool _isCustomerNameEnabled;
        private bool _isCustomerAddressEnabled;
        private bool _isCustomerEmailEnabled;
        private bool _isCustomerContactNumberEnabled;
        private bool _isCustomerOtherInfoEnabled;
        private bool _isImportFileBrowseButtonEnabled;
        private bool _isValidExcelTemplate;
        private bool _isImportDataExpanded;
        private bool _isSymmetricalArranged;
        private bool _isSpinningWheelSpinning;

        private Visibility _validationMessageVisibility;
        private Visibility _customerSelectionVisibility;
        private Visibility _fileCheckListVisibility;
        private Visibility _uploadFileDescriptionVisibility;
        private Visibility _existingCustomerCheckedVisibility;
        private Visibility _importDataVisibility;
        private Visibility _importButtonVisibility;
        private Visibility _spinningWheelVisibility;

        private AvbobQuotationModel _quotationModel;
        private ObservableCollection<DataImportItem> _dataImportItems;
        private AvbobPendingQuotation _avbobPendingQuotation;
        private AvbobPendingQuotationPolicyBook _avbobPendingQuotationPolicyBook;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<QuotationUploadDocument> _quotationDocuments;
        private ObservableCollection<AvbobPendingQuotationPolicy> _avbobPendingQuotationPolicies;
        private AvbobPendingQuotationPolicySummary _avbobPendingQuotationPolicySummary;

        #endregion

        #region properties
        public CurrentLogin CurrentLogin
        {
            get
            {
                return _currentLogin;
            }
            set
            {
                _currentLogin = value;
                this.RaisePropertyChanged("CurrentLogin");
            }
        }

        public string ControlCaption
        {
            get
            {
                return _controlCaption;
            }
            set
            {
                _controlCaption = value;
                this.RaisePropertyChanged("ControlCaption");
            }
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
                this.RaisePropertyChanged("CustomerName");
            }
        }

        public string CustomerNumber
        {
            get
            {
                return _customerNumber;
            }
            set
            {
                _customerNumber = value;
                this.RaisePropertyChanged("CustomerNumber");
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
                return _customerContactNo;
            }
            set
            {
                _customerContactNo = value;
                this.RaisePropertyChanged("CustomerContactNumber");
            }
        }

        public string CustomerEmail
        {
            get
            {
                return _customerEmail;
            }
            set
            {
                _customerEmail = value;
                this.RaisePropertyChanged("CustomerEmail");
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

        public string ImportFileName
        {
            get
            {
                return _importFileName;
            }
            set
            {
                _importFileName = value;
                this.RaisePropertyChanged("ImportFileName");
            }
        }

        public string UploadFileName
        {
            get
            {
                return _uploadFileName;
            }
            set
            {
                _uploadFileName = value;
                this.RaisePropertyChanged("UploadFileName");
            }
        }

        public string UploadFileDescription
        {
            get
            {
                return _uploadFileDescription;
            }
            set
            {
                _uploadFileDescription = value;
                this.RaisePropertyChanged("UploadFileDescription");
            }
        }

        public string SelectedCustomerName
        {
            get
            {
                return _selectedCustomerName;
            }
            set
            {
                _selectedCustomerName = value;
                this.RaisePropertyChanged("SelectedCustomerName");
            }
        }

        public string ValidationMessage
        {
            get
            {
                return _validationMessage;
            }
            set
            {
                _validationMessage = value;
                this.RaisePropertyChanged("ValidationMessage");
            }
        }

        public string PendingQuotationPolicyBookName
        {
            get
            {
                return _pendingQuotationPolicyBookName;
            }
            set
            {
                _pendingQuotationPolicyBookName = value;
                this.RaisePropertyChanged("PendingQuotationPolicyBookName");
            }
        }

        public bool IsCustomerNameEnabled
        {
            get
            {
                return _isCustomerNameEnabled;
            }
            set
            {
                _isCustomerNameEnabled = value;
                this.RaisePropertyChanged("IsCustomerNameEnabled");
            }
        }

        public bool IsCustomerAddressEnabled
        {
            get
            {
                return _isCustomerAddressEnabled;
            }
            set
            {
                _isCustomerAddressEnabled = value;
                this.RaisePropertyChanged("IsCustomerAddressEnabled");
            }
        }

        public bool IsCustomerEmailEnabled
        {
            get
            {
                return _isCustomerEmailEnabled;
            }
            set
            {
                _isCustomerEmailEnabled = value;
                this.RaisePropertyChanged("IsCustomerEmailEnabled");
            }
        }

        public bool IsCustomerContactNumberEnabled
        {
            get
            {
                return _isCustomerContactNumberEnabled;
            }
            set
            {
                _isCustomerContactNumberEnabled = value;
                this.RaisePropertyChanged("IsCustomerContactNumberEnabled");
            }
        }

        public bool IsCustomerOtherInfoEnabled
        {
            get
            {
                return _isCustomerOtherInfoEnabled;
            }
            set
            {
                _isCustomerOtherInfoEnabled = value;
                this.RaisePropertyChanged("IsCustomerOtherInfoEnabled");
            }
        }

        public bool IsImportFileBrowseButtonEnabled
        {
            get
            {
                return _isImportFileBrowseButtonEnabled;
            }
            set
            {
                _isImportFileBrowseButtonEnabled = value;
                this.RaisePropertyChanged("IsImportFileBrowseButtonEnabled");
            }

        }

        public bool IsImportDataExpanded
        {
            get
            {
                return _isImportDataExpanded;
            }
            set
            {
                _isImportDataExpanded = value;
                this.RaisePropertyChanged("IsImportDataExpanded");
            }
        }

        public double SpinningWheelRadius
        {
            get
            {
                return _spinningWheelRadius;
            }
            set
            {
                _spinningWheelRadius = value;
                this.RaisePropertyChanged("SpinningWheelRadius");
            }
        }

        public bool IsSpinningWheelSpinning
        {
            get
            {
                return _isSpinningWheelSpinning;
            }
            set
            {
                _isSpinningWheelSpinning = value;
                this.RaisePropertyChanged("IsSpinningWheelSpinning");
            }
        }

        public double SpinningDotRadius
        {
            get
            {
                return _spinningDotRadius;
            }
            set
            {
                _spinningDotRadius = value;
                this.RaisePropertyChanged("SpinningDotRadius");
            }
        }

        public double SpinningDotSpeed
        {
            get
            {
                return _spinningDotSpeed;
            }
            set
            {
                _spinningDotSpeed = value;
                this.RaisePropertyChanged("SpinningDotSpeed");
            }
        }

        public int SpinningDotCount
        {
            get
            {
                return _spinningDotCount;
            }
            set
            {
                _spinningDotCount = value;
                this.RaisePropertyChanged("SpinningDotCount");
            }
        }

        public SolidColorBrush SpinningDotColor
        {
            get
            {
                return _spinningDotColor;
            }
            set
            {
                _spinningDotColor = value;
                this.RaisePropertyChanged("SpinningDotColor");
            }
        }

        public bool IsSymmetricalArranged
        {
            get
            {
                return _isSymmetricalArranged;
            }
            set
            {
                _isSymmetricalArranged = value;
                this.RaisePropertyChanged("IsSymmetricalArranged");
            }
        }

        public Visibility ValidationMessageVisibility
        {
            get
            {
                return _validationMessageVisibility;
            }
            set
            {
                _validationMessageVisibility = value;
                this.RaisePropertyChanged("ValidationMessageVisibility");
            }
        }

        public Visibility CustomerSelectionVisibility
        {
            get
            {
                return _customerSelectionVisibility;
            }
            set
            {
                _customerSelectionVisibility = value;
                this.RaisePropertyChanged("CustomerSelectionVisibility");
            }
        }

        public Visibility FileCheckListVisibility
        {
            get
            {
                return _fileCheckListVisibility;
            }
            set
            {
                _fileCheckListVisibility = value;
                this.RaisePropertyChanged("FileCheckListVisibility");
            }
        }

        public Visibility UploadFileDescriptionVisibility
        {
            get
            {
                return _uploadFileDescriptionVisibility;
            }
            set
            {
                _uploadFileDescriptionVisibility = value;
                this.RaisePropertyChanged("UploadFileDescriptionVisibility");
            }
        }

        public Visibility ExistingCustomerCheckedVisibility
        {
            get
            {
                return _existingCustomerCheckedVisibility;
            }
            set
            {
                _existingCustomerCheckedVisibility = value;
                this.RaisePropertyChanged("ExistingCustomerCheckedVisibility");
            }
        }

        public Visibility ImportDataVisibility
        {
            get
            {
                return _importDataVisibility;
            }
            set
            {
                _importDataVisibility = value;
                this.RaisePropertyChanged("ImportDataVisibility");
            }
        }

        public Visibility ImportButtonVisibility
        {
            get
            {
                return _importButtonVisibility;
            }
            set
            {
                _importButtonVisibility = value;
                this.RaisePropertyChanged("ImportButtonVisibility");
            }
        }

        public Visibility SpinningWheelVisibility
        {
            get
            {
                return _spinningWheelVisibility;
            }
            set
            {
                _spinningWheelVisibility = value;
                this.RaisePropertyChanged("SpinningWheelVisibility");
            }
        }

        private bool IsValidInput
        {
            get
            {
                return _isValidInput;
            }
            set
            {
                _isValidInput = value;
            }
        }

        public bool IsExistingCustomerChecked
        {
            get
            {
                return _isExistingCustomerChecked;
            }
            set
            {
                _isExistingCustomerChecked = value;
                this.RaisePropertyChanged("IsExistingCustomerChecked");
                UpdateCustomerSelectionVisibility();
            }
        }

        public bool IsFileBrowseButtonEnabled
        {
            get
            {
                return _isFileBrowseButtonEnabled;
            }
            set
            {
                _isFileBrowseButtonEnabled = value;
                this.RaisePropertyChanged("IsFileBrowseButtonEnabled");
            }
        }

        public bool IsValidExcelTemplate
        {
            get
            {
                return _isValidExcelTemplate;
            }
            set
            {
                _isValidExcelTemplate = value;
                this.RaisePropertyChanged("IsValidExcelTemplate");
            }
        }

        public string CurrentImportFilePath
        {
            get
            {
                return _currentImportFilePath;
            }
            set
            {
                _currentImportFilePath = value;
                this.RaisePropertyChanged("CurrentImportFilePath");
            }
        }

        public string CurrentScheduleOutputFilePath
        {
            get
            {
                return _currentScheduleOutputFilePath;
            }
            set
            {
                _currentScheduleOutputFilePath = value;
                this.RaisePropertyChanged("CurrentScheduleOutputFilePath");
            }
        }

        public string DocumentOutputDirectory
        {
            get
            {
                return _documentOutputDirectory;
            }
            private set
            {
                _documentOutputDirectory = value;
                this.RaisePropertyChanged("DocumentOutputDirectory");
            }
        }

        public int CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
                this.RaisePropertyChanged("CustomerID");
            }
        }

        public int PendingQuotationID
        {
            get
            {
                return _pendingQuotationID;
            }
            set
            {
                _pendingQuotationID = value;
                this.RaisePropertyChanged("PendingQuotationID");
            }
        }

        public int PendingQuotationPolicyBookID
        {
            get
            {
                return _pendingQuotationPolicyBookID;
            }
            set
            {
                _pendingQuotationPolicyBookID = value;
                this.RaisePropertyChanged("PendingQuotationPolicyBookID");
            }
        }

        public AvbobQuotationModel QuotationModel
        {
            get
            {
                return _quotationModel;
            }
            set
            {
                _quotationModel = value;
                this.RaisePropertyChanged("QuotationModel");
            }
        }

        public ObservableCollection<DataImportItem> DataImportItems
        {
            get
            {
                return _dataImportItems;
            }
            set
            {
                _dataImportItems = value;
                this.RaisePropertyChanged("DataImportItems");
            }
        }

        public AvbobPendingQuotationPolicyBook AvbobPendingQuotationPolicyBook
        {
            get
            {
                return _avbobPendingQuotationPolicyBook;
            }
            set
            {
                _avbobPendingQuotationPolicyBook = value;
                this.RaisePropertyChanged("AvbobPendingQuotationPolicyBook");
            }
        }

        public AvbobPendingQuotation AvbobPendingQuotation
        {
            get
            {
                return _avbobPendingQuotation;
            }
            set
            {
                _avbobPendingQuotation = value;
                this.RaisePropertyChanged("AvbobPendingQuotation");
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                this.RaisePropertyChanged("Customers");
            }
        }

        public ObservableCollection<QuotationUploadDocument> QuotationDocuments
        {
            get
            {
                return _quotationDocuments;
            }
            set
            {
                _quotationDocuments = value;
                this.RaisePropertyChanged("QuotationDocuments");
            }
        }

        public ObservableCollection<AvbobPendingQuotationPolicy> AvbobPendingQuotationPolicies
        {
            get
            {
                return _avbobPendingQuotationPolicies;
            }
            set
            {
                _avbobPendingQuotationPolicies = value;
                this.RaisePropertyChanged("AvbobPendingQuotationPolicies");
            }
        }

        public AvbobPendingQuotationPolicySummary AvbobPendingQuotationPolicySummary
        {
            get
            {
                return _avbobPendingQuotationPolicySummary;
            }
            set
            {
                _avbobPendingQuotationPolicySummary = value;
                this.RaisePropertyChanged("AvbobPendingQuotationPolicySummary");
            }
        }

        public System.Windows.Window CurrentWindow { get; set; }

        public DockingSetupModel LayoutModel { get; set; }

        public RelayCommand<Window> ProceedCommand { get; set; }

        public RelayCommand<Window> CancelCommand { get; set; }

        public RelayCommand<Window> ImportFileBrowseCommand { get; set; }

        public RelayCommand<Window> DocumentFileBrowseCommand { get; set; }

        public RelayCommand<Window> ImportCommand { get; set; }

        public RelayCommand<Window> ClearCommand { get; set; }

        public RelayCommand CustomerSelectionChangedCommand { get; set; }

        #endregion

        #region constructors
        public AvbobNewQuotationViewModel(System.Windows.Window window, DockingSetupModel layoutModel, CurrentLogin currentLogin)
        {
            this.CurrentWindow = window;
            this.LayoutModel = layoutModel;
            this.CurrentLogin = currentLogin;
            this.ControlCaption = "CREATE A NEW AVBOB QUOTATION";
            this.PopulateExistingCustomers();
            if (this.Customers.Count > 0)
            {
                this.ExistingCustomerCheckedVisibility = Visibility.Visible;
            }
            else
            {
                this.ExistingCustomerCheckedVisibility = Visibility.Collapsed;
            }
            this.ValidationMessage = "";
            this.ValidationMessageVisibility = Visibility.Collapsed;
            this.CustomerSelectionVisibility = Visibility.Collapsed;
            this.FileCheckListVisibility = Visibility.Collapsed;
            this.ImportButtonVisibility = Visibility.Collapsed;
            this.ImportDataVisibility = Visibility.Collapsed;
            this.IsCustomerAddressEnabled = true;
            this.IsCustomerContactNumberEnabled = true;
            this.IsCustomerEmailEnabled = true;
            this.IsCustomerNameEnabled = true;
            this.IsCustomerOtherInfoEnabled = true;
            this.IsImportDataExpanded = false;

            this.ResetUploadFileControl();
            this.IsFileBrowseButtonEnabled = true;
            this.IsImportFileBrowseButtonEnabled = true;
            SpinningWheelVisibility = Visibility.Collapsed;
            IsSpinningWheelSpinning = false;
            this.WireUpEvents();
        }
        #endregion

        #region methods

        private void UpdateSpinningWheelProperties(bool visible, bool spin)
        {
            if (visible)
            {
                this.SpinningWheelVisibility = Visibility.Visible;
            }
            else
            {
                this.SpinningWheelVisibility = Visibility.Collapsed;
            }
            if (spin)
            {
                this.IsSpinningWheelSpinning = true;
            }
            else
            {
                this.IsSpinningWheelSpinning = false;
            }
        }

        private void SetSpinningWheelDefaultProperties()
        {
            this.SpinningWheelRadius = 50;
            this.SpinningDotRadius = 3;
            this.SpinningDotSpeed = 2;
            this.SpinningDotCount = 20;
            this.IsSymmetricalArranged = true;
            this.SpinningDotColor = new SolidColorBrush(Color.FromRgb(255, 140, 0));
        }

        private void WireUpEvents()
        {
            ProceedCommand = new RelayCommand<Window>(ProceedAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
            DocumentFileBrowseCommand = new RelayCommand<Window>(DocumentFileBrowseAction);
            ImportFileBrowseCommand = new RelayCommand<Window>(ImportFileBrowseAction);
            ImportCommand = new RelayCommand<Window>(ImportAction);
            ClearCommand = new RelayCommand<Window>(ClearAction);
            CustomerSelectionChangedCommand = new RelayCommand(CustomerSelectionChangedAction);
        }

        private void UpdateCustomerSelectionVisibility()
        {
            if (this.IsExistingCustomerChecked)
            {
                this.CustomerSelectionVisibility = Visibility.Visible;
                this.IsCustomerNameEnabled = false;
                this.IsCustomerAddressEnabled = false;
                this.IsCustomerContactNumberEnabled = false;
                this.IsCustomerEmailEnabled = false;
                this.IsCustomerOtherInfoEnabled = false;
            }
            else
            {
                this.CustomerSelectionVisibility = Visibility.Collapsed;
                this.SelectedCustomerName = string.Empty;
                this.IsCustomerNameEnabled = true;
                this.IsCustomerAddressEnabled = true;
                this.IsCustomerContactNumberEnabled = true;
                this.IsCustomerEmailEnabled = true;
                this.IsCustomerOtherInfoEnabled = true;
            }
        }

        public void ValidateCustomerName()
        {
            if (string.IsNullOrEmpty(this.CustomerName))
            {
                this.ValidationMessage = "Please enter a customer name.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
                this.IsValidInput = true;
            }
        }

        public void ValidateCustomerAddress()
        {
            if (string.IsNullOrEmpty(this.CustomerName))
            {
                this.ValidationMessage = "Please enter a customer address.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
                this.IsValidInput = true;
            }
        }

        public void ValidateCustomerEmail()
        {
            if (string.IsNullOrEmpty(this.CustomerName))
            {
                this.ValidationMessage = "Please enter a customer e-mail address.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
                this.IsValidInput = true;
            }
        }

        public void ValidateCustomerContactNumber()
        {
            if (string.IsNullOrEmpty(this.CustomerName))
            {
                this.ValidationMessage = "Please enter a customer contact number.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
                this.IsValidInput = true;
            }
        }

        public void ValidateFileDescription()
        {
            if ((!string.IsNullOrWhiteSpace(this.UploadFileName)) && (string.IsNullOrWhiteSpace(this.UploadFileDescription)))
            {
                this.ValidationMessage = "Please enter a description for the uploaded file.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
        }

        public void ValidateImportFileName()
        {
            if (!string.IsNullOrEmpty(this.ImportFileName))
            {
                this.ImportButtonVisibility = Visibility.Visible;
            }
            else
            {
                this.ImportButtonVisibility = Visibility.Collapsed;
            }
        }

        private void Validate()
        {
            this.IsValidInput = true;

            if (string.IsNullOrEmpty(this.CustomerName))
            {
                this.ValidationMessage = "Please enter a customer name.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (string.IsNullOrEmpty(this.CustomerAddress))
            {
                this.ValidationMessage = "Please enter a customer address.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (string.IsNullOrEmpty(this.CustomerContactNumber))
            {
                this.ValidationMessage = "Please enter a customer contact number.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (string.IsNullOrEmpty(this.CustomerEmail))
            {
                this.ValidationMessage = "Please enter a customer e-mail address.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if ((this.IsExistingCustomerChecked) && (string.IsNullOrWhiteSpace(this.SelectedCustomerName)))
            {
                this.ValidationMessage = "Please select an existing customer.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (IsDuplicateCustomerName())
            {
                this.ValidationMessage = "Duplicate customer name. The customer name already exists in the database. Select from existing customers.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (((this.DataImportItems != null) && (this.DataImportItems.Count == 0)) || (this.DataImportItems == null))
            {
                this.ValidationMessage = "There are no data records available for processing. Please import a valid data set.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if ((!string.IsNullOrWhiteSpace(this.UploadFileName)) && (string.IsNullOrWhiteSpace(this.UploadFileDescription)))
            {
                this.ValidationMessage = "Please enter a description for the uploaded file.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
        }

        private void UpdateFileBrowseButtonEnabledState()
        {
            if ((string.IsNullOrWhiteSpace(this.UploadFileDescription)) && (!string.IsNullOrWhiteSpace(this.UploadFileName)))
            {
                this.IsFileBrowseButtonEnabled = false;
            }
            else
            {
                this.IsFileBrowseButtonEnabled = true;
            }
        }

        public void UpdateUploadFileDescription()
        {
            bool filePreviouslyUploaded = false;
            if ((!string.IsNullOrEmpty(this.UploadFileName)) && (string.IsNullOrEmpty(this.UploadFileDescription)))
            {
                ValidateFileDescription();
            }
            else if ((!string.IsNullOrWhiteSpace(this.UploadFileName)) && (!string.IsNullOrWhiteSpace(this.UploadFileDescription)))
            {
                foreach (QuotationUploadDocument document in this.QuotationDocuments)
                {
                    if (document.FilePath == this.UploadFileName)
                    {
                        filePreviouslyUploaded = true;
                        break;
                    }
                }
                if (!filePreviouslyUploaded)
                {
                    this.QuotationDocuments.Add(new QuotationUploadDocument()
                    {
                        FileName = Path.GetFileNameWithoutExtension(this.UploadFileName),
                        FilePath = this.UploadFileName,
                        FileDescription = this.UploadFileDescription,
                        FileExtension = Path.GetExtension(this.UploadFileName),
                        IsFileSelected = true
                    });
                    ResetUploadFileControl();
                }
                if (this.QuotationDocuments.Count > 0)
                {
                    this.FileCheckListVisibility = Visibility.Visible;
                }
                else
                {
                    this.FileCheckListVisibility = Visibility.Collapsed;
                }
            }
        }

        private void ResetUploadFileControl()
        {
            this.UploadFileName = "";
            this.UploadFileDescription = "";
        }

        private void UpdateCustomerNumber()
        {
            if (this.IsExistingCustomerChecked)
            {
                this.CustomerSelectionVisibility = Visibility.Visible;
            }
        }

        private string GenerateNewCustomerNumber()
        {
            string result = string.Empty;
            string customerPreFix = this.CustomerName.Substring(0, 3).ToUpper();
            int customerPreFixCount = 0;
            using (var context = new NattexApplicationContext())
            {
                var customers = context.Customers.ToList();
                if ((customers != null) && (customers.Count > 0))
                {
                    foreach (Customer customer in customers)
                    {
                        if (customer.CustomerNumber.Length >= 14)
                        {
                            if (customerPreFix == customer.CustomerNumber.Substring(11, 3).ToUpper())
                            {
                                customerPreFixCount = customerPreFixCount + 1;
                            }
                        }
                    }
                }
            }
            if (customerPreFixCount == 0)
            {
                result = "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + "000" + Convert.ToString(customerPreFixCount + 1);
            }
            else
            {
                if (Convert.ToString(customerPreFixCount).Length == 1)
                {
                    result = "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + "000" + Convert.ToString(customerPreFixCount + 1);
                }
                else if (Convert.ToString(customerPreFixCount).Length == 2)
                {
                    result = "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + "00" + Convert.ToString(customerPreFixCount + 1);
                }
                else if (Convert.ToString(customerPreFixCount).Length == 3)
                {
                    result = "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + "0" + Convert.ToString(customerPreFixCount + 1);
                }
                else if (Convert.ToString(customerPreFixCount).Length == 4)
                {
                    result = "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + Convert.ToString(customerPreFixCount + 1);
                }
                else
                {
                    result = "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + "E" + Convert.ToString(customerPreFixCount + 1);
                }
            }

            this.CustomerNumber = result;
            return result;
        }

        private string GenerateNewQuoationNumber()
        {
            string result = string.Empty;
            int quotationCount = 0;
            if ((!string.IsNullOrEmpty(this.CustomerNumber)) && (this.CustomerNumber.Length == 18))
            {
                using (var context = new NattexApplicationContext())
                {
                    var quotations = context.AvbobPendingQuotations.ToList();
                    if ((quotations != null) && (quotations.Count > 0))
                    {
                        foreach (AvbobPendingQuotation quotation in quotations)
                        {
                            if ((quotation.QuotationNumber.StartsWith("Q" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerNumber.Substring(11, 7))) && (quotation.IsActive == true))
                            {
                                quotationCount = quotationCount + 1;
                            }
                        }
                    }
                }
                if (quotationCount == 0)
                {
                    result = "Q" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerNumber.Substring(11, 7) + "-" + "01";
                }
                else
                {
                    if (Convert.ToString(quotationCount).Length == 1)
                    {
                        result = "Q" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerNumber.Substring(11, 7) + "-" + "0" + Convert.ToString(quotationCount + 1);
                    }
                    else if (Convert.ToString(quotationCount).Length == 2)
                    {
                        result = "Q" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerNumber.Substring(11, 7) + "-" + Convert.ToString(quotationCount + 1);
                    }
                    else
                    {
                        result = "Q" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerNumber.Substring(11, 7) + "-" + "E" + Convert.ToString(quotationCount + 1);
                    }
                }
            }

            this.QuotationNumber = result;
            return result;
        }

        private bool IsDuplicateCustomerName()
        {
            bool result = false;
            using (var context = new NattexApplicationContext())
            {
                var customers = context.Customers.ToList();
                if ((customers != null) && (customers.Count > 0))
                {
                    var customer = context.Customers.ToList().Where(x => x.CompanyName == this.CustomerName && x.IsActive == true).FirstOrDefault();
                    if (customer != null)
                    {
                        if (!this.IsExistingCustomerChecked)
                        {
                            result = true;
                        } 
                    }
                }

            }
            return result;
        }

        private ObservableCollection<Customer> GetCustomers()
        {
            ObservableCollection<Customer> result = null;
            using (var context = new NattexApplicationContext())
            {
                var customers = context.Customers.ToList();
                result = new ObservableCollection<Customer>(customers);
            }
            return result;
        }

        private void PopulateExistingCustomerDetails()
        {
            if (!string.IsNullOrEmpty(this.SelectedCustomerName) && this.IsExistingCustomerChecked)
            {
                using (var context = new NattexApplicationContext())
                {
                    var customer = context.Customers.Where(x => x.CompanyName == this.SelectedCustomerName).FirstOrDefault<Customer>();
                    if (customer != null)
                    {
                        this.CustomerID = customer.CustomerID;
                        this.CustomerName = customer.CompanyName;
                        this.CustomerAddress = customer.Address;
                        this.CustomerContactNumber = customer.ContactNumber;
                        this.CustomerEmail = customer.EmailAddress;
                        this.CustomerOtherInfo = customer.OtherInfo;
                        this.IsCustomerNameEnabled = false;
                        this.IsCustomerAddressEnabled = false;
                        this.IsCustomerContactNumberEnabled = false;
                        this.IsCustomerEmailEnabled = false;
                        this.IsCustomerOtherInfoEnabled = false;
                    }
                }
            }
        }

        private void PopulateExistingCustomers()
        {
            if (this.Customers == null)
            {
                this.Customers = new ObservableCollection<Customer>();
            }
            using (var context = new NattexApplicationContext())
            {
                this.Customers = new ObservableCollection<Customer>(context.Customers.ToList());
            }
        }

        private void KillExcelProcess(Process[] oldExcelProcesses, Process[] newExcelProcesses)
        {
            foreach (Process newExcelProcess in newExcelProcesses)
            {
                int exist = 0;
                foreach (Process oldExcelProcess in oldExcelProcesses)
                {
                    if (newExcelProcess.Id == oldExcelProcess.Id)
                    {
                        exist++;
                    }
                }
                if (exist == 0)
                {
                    newExcelProcess.Kill();
                }
            }
        }

        private void ProcessImportedData()
        {
            if ((this.DataImportItems != null) && (this.DataImportItems.Count > 0))
            {
                List<string> policyNumbers = this.DataImportItems.Select(x => x.PolicyNumber).Distinct().ToList();

                foreach (string policyNumber in policyNumbers)
                {
                    AvbobPendingQuotationPolicy policy = new AvbobPendingQuotationPolicy()
                    {
                        AvbobPendingQuotationPolicyBookID = this.AvbobPendingQuotationPolicyBook.AvbobPendingQuotationPolicyBookID,
                        AvbobPendingQuotationID = this.AvbobPendingQuotation.AvbobPendingQuotationID,
                        PolicyNumber = policyNumber,
                        IsActive = true,
                        CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                        CreateUserID = 1
                    };

                    int policyID = SaveAvbobPendingQuotationPolicy(policy);
                    var policyMembers = this.DataImportItems.Where(x => x.PolicyNumber == policy.PolicyNumber).ToList();
                    if (policyMembers != null)
                    {
                        foreach (DataImportItem member in policyMembers)
                        {
                            AvbobPendingQuotationPolicyMember policyMember = new AvbobPendingQuotationPolicyMember()
                            {
                                AvbobPendingQuotationID = this.AvbobPendingQuotation.AvbobPendingQuotationID,
                                AvbobPendingQuotationPolicyID = policyID,
                                Initial = member.Initial,
                                FirstName = member.FirstName,
                                LastName = member.LastName,
                                IDNumber = member.IDNumber,
                                DateOfBirth = member.DateOfBirth,
                                Gender = member.Gender,
                                Relation = member.Relation,
                                Age = member.Age,
                                CoverAmount = member.CoverAmount,
                                AddressLine1 = member.AddressLine1,
                                AddressLine2 = member.AddressLine2,
                                AddressCode = member.AddressCode,
                                EnrollmentDate = member.EnrollmentDate,
                                Beneficiary = member.Beneficiary,
                                BeneficiaryIDNumber = member.BeneficiaryIDNumber,
                                IsActive = true,
                                CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                                CreateUserID = 1
                            };
                            SaveAvbobPendingQuotationPolicyMember(policyMember);
                        }
                    }
                }

                CalculatePendingQuotationPolicyPremiums();
                SummarisePendingQuotationPolicyPremiums();
            }
        }

        private void CalculatePendingQuotationPolicyPremiums()
        {
            using (var context = new NattexApplicationContext())
            {
                var policies = context.AvbobPendingQuotationPolicies.Where(x => x.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID && x.IsActive == true);
                this.AvbobPendingQuotationPolicies = new ObservableCollection<AvbobPendingQuotationPolicy>(policies);
                if (this.AvbobPendingQuotationPolicies != null)
                {
                    foreach (AvbobPendingQuotationPolicy policy in this.AvbobPendingQuotationPolicies)
                    {
                        List<AvbobPendingQuotationPolicyMember> members = context.AvbobPendingQuotationPolicyMembers.Where(x => x.AvbobPendingQuotationPolicyID == policy.AvbobPendingQuotationPolicyID).ToList();
                        foreach (AvbobPendingQuotationPolicyMember member in members)
                        {
                            if ((member.Relation != "17") && (member.CoverAmount != null))
                            {
                                if (member.Age > 64)
                                {
                                    member.Relation = "1";
                                }
                                AvbobPendingQuotationPolicyPremium premium = GetAvobMemberPolicyPremiumDetails(member.Age, Convert.ToDecimal(member.CoverAmount), member.Relation);
                                if (premium != null)
                                {
                                    policy.MonthlyMemberCommission = policy.MonthlyMemberCommission + premium.MonthlyMemberCommission;
                                    policy.MonthlyMemberPremium = policy.MonthlyMemberPremium + premium.MonthlyMemberPremium;
                                    policy.TotalMonthlyMemberPremium = policy.TotalMonthlyMemberPremium + premium.TotalMonthlyMemberPremium;
                                    policy.CompanyMemberPremium = policy.CompanyMemberPremium + premium.CompanyMemberPremium;
                                }
                            }
                        }
                        if (policy != null)
                        {
                            SaveCalculatedPendingQuotationPolicy(policy);
                        }
                    }
                }
            };
        }

        private void SummarisePendingQuotationPolicyPremiums()
        {
            if (this.AvbobPendingQuotationPolicySummary == null)
            {
                this.AvbobPendingQuotationPolicySummary = new AvbobPendingQuotationPolicySummary();
                this.AvbobPendingQuotationPolicySummary.AvbobPendingQuotationID = this.AvbobPendingQuotation.AvbobPendingQuotationID;
            }
            foreach (AvbobPendingQuotationPolicy policy in this.AvbobPendingQuotationPolicies)
            {
                this.AvbobPendingQuotationPolicySummary.TotalMonthlyMemberPremium = this.AvbobPendingQuotationPolicySummary.TotalMonthlyMemberPremium + policy.MonthlyMemberPremium;
                this.AvbobPendingQuotationPolicySummary.TotalMonthlyMemberCommission = this.AvbobPendingQuotationPolicySummary.TotalMonthlyMemberCommission + policy.MonthlyMemberCommission;
                this.AvbobPendingQuotationPolicySummary.TotalMonthlyMemberPremiumTotal = this.AvbobPendingQuotationPolicySummary.TotalMonthlyMemberPremiumTotal + policy.TotalMonthlyMemberPremium;
                this.AvbobPendingQuotationPolicySummary.TotalCompanyMemberPremium = this.AvbobPendingQuotationPolicySummary.TotalCompanyMemberPremium + policy.CompanyMemberPremium;
            }
            this.AvbobPendingQuotation.MonthlyPremium = this.AvbobPendingQuotationPolicySummary.TotalCompanyMemberPremium;
            this.AvbobPendingQuotation.NumberOfProspectiveMembers = Convert.ToString(this.DataImportItems.Count);

            UpdatePendingQuotation();
            SaveSummarisedPendingQuotationPolicyPremiums();
        }

       private AvbobPendingQuotationPolicyPremium GetAvobMemberPolicyPremiumDetails(int age, decimal cover, string relation)
        {
            AvbobPendingQuotationPolicyPremium result = null;
            string unit = string.Empty;
            if (relation == "1")
            {
                unit = "Single";
            }
            else if ((relation == "2") || (relation == "17"))
            {
                unit = "Family";
            }
            else if (relation == "10")
            {
                if (age > 18)
                {
                    unit = "Single";
                }
                else if (age <= 18)
                {
                    unit = "Extended Child";
                    var maxCover = GetMaxExtendedCoverage();
                    if (cover > maxCover)
                    {
                        cover = maxCover;
                    }
                }
            }

            if ((unit == "Extended Child") && (age <= 18))
            {
                using (var context = new NattexApplicationContext())
                {
                    result = (from premium in context.AvbobPendingQuotationPolicyPremiums
                              join ageGroup in context.AvbobPendingQuotationAgeGroups on premium.AvbobPendingQuotationAgeGroupID equals ageGroup.AvbobPendingQuotationAgeGroupID
                              join plan in context.AvbobPendingQuotationPlans on premium.AvbobPendingQuotationPlanID equals plan.AvbobPendingQuotationPlanID
                              join memberUnit in context.AvbobPendingQuotationMemberUnitTypes on premium.AvbobPendingQuotationMemberUnitTypeID
                              equals memberUnit.AvbobPendingQuotationMemberUnitTypeID
                              where (age >= premium.StartAge && age <= premium.EndAge) && memberUnit.Name == unit && premium.ExtendedChildUpTo18YearsCover == cover
                              select premium).FirstOrDefault();
                }
            }
            else
            {
                using (var context = new NattexApplicationContext())
                {
                    result = (from premium in context.AvbobPendingQuotationPolicyPremiums
                              join ageGroup in context.AvbobPendingQuotationAgeGroups on premium.AvbobPendingQuotationAgeGroupID equals ageGroup.AvbobPendingQuotationAgeGroupID
                              join plan in context.AvbobPendingQuotationPlans on premium.AvbobPendingQuotationPlanID equals plan.AvbobPendingQuotationPlanID
                              join memberUnit in context.AvbobPendingQuotationMemberUnitTypes on premium.AvbobPendingQuotationMemberUnitTypeID
                              equals memberUnit.AvbobPendingQuotationMemberUnitTypeID
                              where (age >= premium.StartAge && age <= premium.EndAge) && memberUnit.Name == unit && premium.MemberCover == cover
                              select premium).FirstOrDefault();
                }
            }
            return result;
        }

       private AvbobPendingQuotationPolicyPremium GetChildCoverPremiumDetails(int age, decimal memberCover)
        {
            AvbobPendingQuotationPolicyPremium result = null;
            using (var context = new NattexApplicationContext())
            {
                var temp = (from premium in context.AvbobPendingQuotationPolicyPremiums
                            join memberUnit in context.AvbobPendingQuotationMemberUnitTypes on premium.AvbobPendingQuotationMemberUnitTypeID
                                   equals memberUnit.AvbobPendingQuotationMemberUnitTypeID
                            where (memberUnit.Name == "Family" && (age >= premium.StartAge && age <= premium.EndAge) && premium.MemberCover == memberCover)
                            select premium) as AvbobPendingQuotationPolicyPremium;
            }
            return result;
        }

       private decimal GetMaxExtendedCoverage()
        {
            decimal result = 0.0M;
            using (var context = new NattexApplicationContext())
            {
                result = (from premium in context.AvbobPendingQuotationPolicyPremiums
                          join memberUnit in context.AvbobPendingQuotationMemberUnitTypes on premium.AvbobPendingQuotationMemberUnitTypeID
                                 equals memberUnit.AvbobPendingQuotationMemberUnitTypeID
                          where memberUnit.Name == "Extended Child"
                          select premium.ExtendedChildUpTo18YearsCover).Max();
            }
            return result;
        }

       private bool IsFileInUse(string path)
        {
            bool result;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    result = false;
                };
                return result;
            }
            catch
            {
                result = true;
                return result;
            }
        }

       public string ConvertToXLSX(String file)
        {
            string result = file;
            Process[] oldExcelProcesses = Process.GetProcessesByName("EXCEL");
            Microsoft.Office.Interop.Excel.Application excelApplication = null;
            Microsoft.Office.Interop.Excel.Workbook workBook = null;

            try
            {
                if (System.IO.Path.GetExtension(file) == ".xls")
                {
                    excelApplication = new Microsoft.Office.Interop.Excel.Application();
                    workBook = excelApplication.Workbooks.Open(file);
                    if ((workBook != null))
                    {
                        result = file + "x";
                        workBook.SaveAs(Filename: file + "x", FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
                        workBook.Close();
                        Marshal.ReleaseComObject(workBook);

                        excelApplication.Quit();
                        Marshal.ReleaseComObject(excelApplication);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
            finally
            {
                if (excelApplication != null)
                {
                    while (Marshal.ReleaseComObject(workBook) > 0) ;
                    while (Marshal.ReleaseComObject(excelApplication) > 0) ;
                    workBook = null;
                    excelApplication = null;
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    Process[] newExcelProcesses = Process.GetProcessesByName("EXCEL");
                    KillExcelProcess(oldExcelProcesses, newExcelProcesses);
                }
            }
        }  

       private int GetMemberCalculatedAge(DateTime dateOfBirth)
        {
            int result = 0;

            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            result = age;

            return result;
        }

       #region actions
       private void ProceedAction(Window window)
       {
            Window win = (Window)window;
            if (win != null)
            {
                Validate();
                if (IsValidInput)
                {
                    try
                    {
                        SpinningWheelVisibility = Visibility.Visible;
                        Thread.Sleep(2000);
                        if (!(this.IsExistingCustomerChecked))
                        {
                            GenerateNewCustomerNumber();
                            this.CustomerID = SaveNewCustomer();
                        }
                        this.GenerateNewQuoationNumber();

                        if (string.IsNullOrEmpty(this.PendingQuotationPolicyBookName))
                        {
                            this.PendingQuotationPolicyBookName = this.CustomerName;
                        }
                        AvbobPendingQuotationPolicyBook book = new AvbobPendingQuotationPolicyBook()
                        {

                            BookName = this.PendingQuotationPolicyBookName.ToUpper(),
                            CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                            IsActive = true,
                            CreateUserID = 1
                        };
                        this.PendingQuotationPolicyBookID = SaveAvbobPendingQuotationPolicyBook(book);
                        book.AvbobPendingQuotationPolicyBookID = this.PendingQuotationPolicyBookID;
                        this.AvbobPendingQuotationPolicyBook = book;

                        AvbobPendingQuotation quotation = new AvbobPendingQuotation()
                        {
                            AvbobPendingQuotationPolicyBookID = this.PendingQuotationPolicyBookID,
                            QuotationNumber = this.QuotationNumber,
                            CustomerNumber = this.CustomerNumber,
                            CustomerName = this.CustomerName,
                            CustomerAddress = this.CustomerAddress,
                            CustomerContactNumber = this.CustomerContactNumber,
                            CustomerEmailAddress = this.CustomerEmail,
                            QuotationPreparedBy = this.CurrentLogin.UserFirstName + " " + this.CurrentLogin.UserLastName,
                            PricingModel = "Avbob",
                            IsActive = true,
                            CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                            CreateUserID = 1
                        };
                        this.PendingQuotationID = SaveAvbobPendingQuotation(quotation);
                        quotation.AvbobPendingQuotationID = this.PendingQuotationID;
                        this.AvbobPendingQuotation = quotation;
                        this.QuotationModel = new AvbobQuotationModel
                        {
                            QuotationID = this.PendingQuotationID
                        };

                        this.ProcessImportedData();

                        this.DocumentOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                        @"\NATTEX\NAMS\Quotations\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\" + this.QuotationNumber + @"\";

                        if (!Directory.Exists(this.DocumentOutputDirectory))
                        {
                            Directory.CreateDirectory(this.DocumentOutputDirectory);
                        }

                        if ((this.QuotationDocuments != null) && (this.QuotationDocuments.Count > 0))
                        {
                            foreach (QuotationUploadDocument document in this.QuotationDocuments)
                            {
                                if ((document.IsFileSelected) && (File.Exists(document.FilePath)))
                                {
                                    var destinationFilePath = this.DocumentOutputDirectory + document.FileName + document.FileExtension;
                                    System.IO.File.Copy(document.FilePath, destinationFilePath, true);
                                    document.CopyToFilePath = destinationFilePath;
                                }
                            }
                        }
                        SaveNewQuotationDocuments();

                        this.LayoutModel.DocumentPane.Children.Remove(this.LayoutModel.Document);
                        this.LayoutModel.Document = new LayoutDocument()
                        {
                            ContentId = "QM-002",
                            IsActive = true,
                            Title = "2. QUOTATION SUMMARY",
                            CanClose = false,
                            CanFloat = true,
                            IsMaximized = false,
                            IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_4_24.png", UriKind.Relative))
                        };
                        this.LayoutModel.Document.Content = new AvbobPendingQuotationSummaryUserControl(this.CurrentWindow, this.LayoutModel, this.QuotationModel, this.CurrentLogin);
                        this.LayoutModel.DocumentPane.Children.Add(this.LayoutModel.Document);
                        this.LayoutModel.Document.PreviousContainerIndex = this.LayoutModel.DocumentPane.Children.IndexOf(this.LayoutModel.Document);
                        this.LayoutModel.Document.Parent = this.LayoutModel.DocumentPane;
                        this.LayoutModel.Document.DockAsDocument();
                        SpinningWheelVisibility = Visibility.Collapsed;
                    }
                    catch(Exception ex)
                    {
                        UpdateSpinningWheelProperties(false, false);
                        this.ValidationMessage = "An error occured in the proceed action of the 'CREATE A NEW AVBOB QUOTATION' activity. " + System.Environment.NewLine +
                            "Please contact the system administrator if the problem persists." + System.Environment.NewLine;
                        this.ValidationMessageVisibility = Visibility.Visible;
                        this.IsValidInput = false;
                    }
                    finally
                    {
                        SpinningWheelVisibility = Visibility.Collapsed;
                    }

                }
            }
        }

        private void CancelAction(Window window)
        {
            Window win = (Window)window;
            if (win != null)
            {
                win.Close();
            }
        }

        private void DocumentFileBrowseAction(Window window)
        {
            if (this.QuotationDocuments == null)
            {
                this.QuotationDocuments = new ObservableCollection<QuotationUploadDocument>();
            }
            this.UploadFileName = string.Empty;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF Documents (.pdf)|*.pdf|Word Documents (.docx)|*.docx|XPS Documents (.xps)| *.xps;";
            dlg.Title = "Select a file to upload.";
            dlg.ValidateNames = true;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = false;

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                this.UploadFileName = dlg.FileName;
            }

            if (this.QuotationDocuments.Count > 0)
            {
                this.FileCheckListVisibility = Visibility.Visible;
            }
            else
            {
                this.FileCheckListVisibility = Visibility.Collapsed;
            }
        }

        private void ImportFileBrowseAction(Window window)
        {
            this.ImportFileName = string.Empty;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "MS Excel Documents (.xlsx)|*.xlsx|Excel Documents (.xls)|*.xls;";
            dlg.Title = "Select a file to to import.";
            dlg.ValidateNames = true;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = false;

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                this.ImportFileName = dlg.FileName;
            }
            if (!string.IsNullOrEmpty(this.ImportFileName))
            {
                this.ImportButtonVisibility = Visibility.Visible;
            }
            else
            {
                this.ImportButtonVisibility = Visibility.Collapsed;
            }
        }

        private void ImportAction(Window window)
        {
            Window win = (Window)window;
             bool[] validationArray = new bool[13];
            for (int i = 0; i < validationArray.Length; i++)
            {
                validationArray[i] = false;
            };

            if (win != null)
            {
                if (File.Exists(this.ImportFileName))
                {
                    this.CurrentImportFilePath = ConvertToXLSX(this.ImportFileName);

                    if (!IsFileInUse(this.CurrentImportFilePath))
                    {
                        using (var stream = File.Open(this.CurrentImportFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            using (ExcelPackage package = new ExcelPackage(stream))
                            {
                                this.IsValidExcelTemplate = true;
                                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                this.PendingQuotationPolicyBookName = workSheet.Name;
                                int count = 0;
                                for (int row = workSheet.Dimension.Start.Row; row <= workSheet.Dimension.End.Row; row++)
                                {
                                    if (row == 3)
                                    {
                                        for (int column = workSheet.Dimension.Start.Column; column <= workSheet.Dimension.End.Column; column++)
                                        {
                                            object cellValue = workSheet.Cells[row, column].Value;
                                            switch (column)
                                            {
                                                case 1:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "POLICY NR."))
                                                    {
                                                        validationArray[0] = true;
                                                    }
                                                    break;
                                                case 2:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "NAME"))
                                                    {
                                                        validationArray[1] = true;
                                                    }
                                                    break;
                                                case 3:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "SURNAME"))
                                                    {
                                                        validationArray[2] = true;
                                                    }
                                                    break;

                                                case 4:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "BIRTHDAY"))
                                                    {
                                                        validationArray[3] = true;
                                                    }
                                                    break;

                                                case 5:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "IDENTITY NR."))
                                                    {
                                                        validationArray[4] = true;
                                                    }
                                                    break;

                                                case 6:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "ENROLLED"))
                                                    {
                                                        validationArray[5] = true;
                                                    }
                                                    break;
                                                case 7:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "RELATION"))
                                                    {
                                                        validationArray[6] = true;
                                                    }
                                                    break;
                                                case 8:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "COVER"))
                                                    {
                                                        validationArray[7] = true;
                                                    }
                                                    break;
                                                case 9:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "ADDRESS LINE 1"))
                                                    {
                                                        validationArray[8] = true;
                                                    }
                                                    break;

                                                case 10:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "ADDRESS LINE 2"))
                                                    {
                                                        validationArray[9] = true;
                                                    }
                                                    break;

                                                case 11:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "CODE"))
                                                    {
                                                        validationArray[10] = true;
                                                    }
                                                    break;
                                                case 12:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "BENEFICIARY"))
                                                    {
                                                        validationArray[11] = true;
                                                    }
                                                    break;
                                                case 13:
                                                    if ((cellValue != null) && (Convert.ToString(cellValue) == "BENEFICIARY ID"))
                                                    {
                                                        validationArray[12] = true;
                                                    }
                                                    break;
                                            }
                                        }
                                        for (int i = 0; i < validationArray.Length; i++)
                                        {
                                            if (validationArray[i] == false)
                                            {
                                                this.IsValidExcelTemplate = false;
                                                break;
                                            }
                                        }
                                    }

                                    if (row > 3)
                                    {
                                        count = count + 1;
                                        if (this.IsValidExcelTemplate)
                                        {
                                            DataImportItem member = new DataImportItem();
                                            member.IsPolicyScheduleDataItem = true;
                                            
                                            member.LineNr = Convert.ToString(count);
                                            for (int column = workSheet.Dimension.Start.Column; column <= workSheet.Dimension.End.Column; column++)
                                            {
                                                object cellValue = workSheet.Cells[row, column].Value;

                                                switch (column)
                                                {
                                                    case 1:
                                                        if (cellValue != null)
                                                        {
                                                            member.PolicyNumber = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 2:
                                                        if (cellValue != null)
                                                        {

                                                            member.FirstName = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 3:
                                                        if (cellValue != null)
                                                        {

                                                            member.LastName = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 4:
                                                        if (cellValue != null)
                                                        {
                                                            bool isValidDateOfBirth = false;
                                                            var dateOfBirth = Convert.ToString(cellValue);
                                                            member.Birthdate = Convert.ToString(cellValue);
                                                            int year = 0;
                                                            int month = 0;
                                                            int day = 0;
                                                            if ((!string.IsNullOrWhiteSpace(dateOfBirth)) && (dateOfBirth.Length >= 8))
                                                            {
                                                                year = (!string.IsNullOrEmpty(dateOfBirth.Substring(0, 4))) ? Convert.ToInt32(dateOfBirth.Substring(0, 4)) : 0;
                                                                month = (!string.IsNullOrEmpty(dateOfBirth.Substring(4, 2))) ? Convert.ToInt32(dateOfBirth.Substring(4, 2)) : 0;
                                                                day = (!string.IsNullOrEmpty(dateOfBirth.Substring(6, 2))) ? Convert.ToInt32(dateOfBirth.Substring(6, 2)) : 0;
                                                            }
                                                            if ((Convert.ToString(year).Length == 4) && (Convert.ToString(month).Length >= 1 && Convert.ToString(month).Length <= 2)
                                                              && ((Convert.ToString(day).Length >= 1) && (Convert.ToString(day).Length <= 2)))
                                                            {
                                                                isValidDateOfBirth = true;
                                                            }
                                                            if (isValidDateOfBirth)
                                                            {
                                                                DateTime temp;
                                                                if (DateTime.TryParse(Convert.ToString(year) + "-" + Convert.ToString(month) + "-" + Convert.ToString(day), out temp))
                                                                {
                                                                    member.DateOfBirth = new DateTime(year, month, day);
                                                                    member.Age = GetMemberCalculatedAge(member.DateOfBirth);
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 5:
                                                        if (cellValue != null)
                                                        {
                                                            member.IDNumber = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 6:
                                                        if (cellValue != null)
                                                        {
                                                            member.EnrollmentDate = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 7:
                                                        if (cellValue != null)
                                                        {
                                                            member.Relation = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 8:
                                                        if (cellValue != null)
                                                        {
                                                            member.CoverAmount = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 9:
                                                        if (cellValue != null)
                                                        {
                                                            member.AddressLine1 = Convert.ToString(cellValue);
                                                        }
                                                        break;

                                                    case 10:
                                                        if (cellValue != null)
                                                        {
                                                            member.AddressLine2 = Convert.ToString(cellValue);
                                                        }
                                                        break;

                                                    case 11:
                                                        if (cellValue != null)
                                                        {
                                                            member.AddressCode = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 12:
                                                        if (cellValue != null)
                                                        {
                                                            member.Beneficiary = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                    case 13:
                                                        if (cellValue != null)
                                                        {
                                                            member.BeneficiaryIDNumber = Convert.ToString(cellValue);
                                                        }
                                                        break;
                                                }
                                                if (this.DataImportItems == null)
                                                {
                                                    this.DataImportItems = new ObservableCollection<DataImportItem>();
                                                }
                                            }
                                            this.DataImportItems.Add(member);

                                        }
                                    }
                                }
                                if (IsValidExcelTemplate)
                                {
                                    this.ImportDataVisibility = Visibility.Visible;
                                    this.ClearAction(win);
                                    this.IsImportDataExpanded = true;
                                }
                                else
                                {
                                    this.ImportDataVisibility = Visibility.Collapsed;
                                    this.IsImportDataExpanded = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.ValidationMessage = "File is in use. Please close file before continuing.";
                        this.ValidationMessageVisibility = Visibility.Visible;
                        this.IsValidInput = false;
                    }
                }
                else
                {
                    this.ValidationMessage = "Invalid import file. File does not exist.";
                    this.ValidationMessageVisibility = Visibility.Visible;
                    this.IsValidInput = false;
                }
            }
        }

        private void ClearAction(Window window)
        {
            Window win = (Window)window;
            if (win != null)
            {
                this.ImportFileName = string.Empty;
                ValidateImportFileName();
            }
        }

        private void CustomerSelectionChangedAction()
        {
            if (!string.IsNullOrEmpty(this.SelectedCustomerName) && this.IsExistingCustomerChecked)
            {
                using (var context = new NattexApplicationContext())
                {
                    var customer = context.Customers.Where(x => x.CompanyName == this.SelectedCustomerName).FirstOrDefault<Customer>();
                    if (customer != null)
                    {
                        this.CustomerID = customer.CustomerID;
                        this.CustomerNumber = customer.CustomerNumber;
                        this.CustomerName = customer.CompanyName;
                        this.CustomerAddress = customer.Address;
                        this.CustomerContactNumber = customer.ContactNumber;
                        this.CustomerEmail = customer.EmailAddress;
                        this.CustomerOtherInfo = customer.OtherInfo;
                        this.IsCustomerNameEnabled = false;
                        this.IsCustomerAddressEnabled = false;
                        this.IsCustomerContactNumberEnabled = false;
                        this.IsCustomerEmailEnabled = false;
                        this.IsCustomerOtherInfoEnabled = false;
                    }
                }
            }
        }
        #endregion

        #region database operations
        private int SaveNewCustomer()
        {
            int result = 0;
            if (!IsDuplicateCustomerName())
            {
                Customer customer = new Customer()
                {
                    FirstName = "",
                    LastName = "",
                    CompanyName = this.CustomerName,
                    Address = this.CustomerAddress,
                    ContactNumber = this.CustomerContactNumber,
                    EmailAddress = this.CustomerEmail,
                    OtherInfo = this.CustomerOtherInfo,
                    CustomerNumber = this.CustomerNumber,
                    CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreateUserID = this.CurrentLogin.UserID,
                    IsActive = true
                };

                using (var context = new NattexApplicationContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    result = customer.CustomerID;
                }
            }
            return result;
        }

        private int SaveAvbobPendingQuotationPolicyBook(AvbobPendingQuotationPolicyBook book)
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                context.AvbobPendingQuotationPolicyBooks.Add(book);
                context.SaveChanges();
                result = book.AvbobPendingQuotationPolicyBookID;
            }
            return result;
        }

        private void UpdatePendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                var entity = context.AvbobPendingQuotations.Find(this.AvbobPendingQuotation.AvbobPendingQuotationID);
                if (entity != null)
                {
                    context.Entry(entity).CurrentValues.SetValues(this.AvbobPendingQuotation);
                    context.SaveChanges();
                }
            };
        }

        private int SaveAvbobPendingQuotation(AvbobPendingQuotation quotation)
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                context.AvbobPendingQuotations.Add(quotation);
                context.SaveChanges();
                result = quotation.AvbobPendingQuotationID;
            }
            return result;
        }

        private int SaveAvbobPendingQuotationPolicy(AvbobPendingQuotationPolicy policy)
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                context.AvbobPendingQuotationPolicies.Add(policy);
                context.SaveChanges();
                result = policy.AvbobPendingQuotationPolicyID;
            }
            return result;
        }

        private int SaveAvbobPendingQuotationPolicyMember(AvbobPendingQuotationPolicyMember policyMember)
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                context.AvbobPendingQuotationPolicyMembers.Add(policyMember);
                context.SaveChanges();
                result = policyMember.AvbobPendingQuotationPolicyID;
            }
            return result;
        }

        private void SaveCalculatedPendingQuotationPolicy(AvbobPendingQuotationPolicy policy)
        {
            using (var context = new NattexApplicationContext())
            {
                if (policy != null)
                {
                    var entity = context.AvbobPendingQuotationPolicies.Find(policy.AvbobPendingQuotationPolicyID);
                    context.Entry(entity).CurrentValues.SetValues(policy);
                    context.SaveChanges();
                }
            };
        }

        private void SaveSummarisedPendingQuotationPolicyPremiums()
        {
            using (var context = new NattexApplicationContext())
            {
                if (this.AvbobPendingQuotationPolicySummary != null)
                {
                    context.AvbobPendingQuotationPolicySummaries.Add(this.AvbobPendingQuotationPolicySummary);
                    context.SaveChanges();
                }
            }
        }

        private void SaveNewQuotationDocuments()
        {
            if ((this.QuotationDocuments != null) && (this.QuotationDocuments.Count > 0))
            {
                List<AvbobPendingQuotationDocument> pendingDocuments = new List<AvbobPendingQuotationDocument>();
                foreach (QuotationUploadDocument document in this.QuotationDocuments)
                {
                    AvbobPendingQuotationDocument pendingDocument = new AvbobPendingQuotationDocument()
                    {
                        AvbobPendingQuotationID = this.PendingQuotationID,
                        FileName = document.FileName,
                        FilePath = document.FilePath,
                        CopyToFilePath = document.CopyToFilePath,
                        FileDescription = document.FileDescription,
                        FileExtension = document.FileExtension,
                        IsFileSelected = document.IsFileSelected,
                        IsActive = document.IsFileSelected ? true : false,
                        CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                        CreateUserID = this.CurrentLogin.UserID
                    };
                    pendingDocuments.Add(pendingDocument);
                }

                using (var context = new NattexApplicationContext())
                {
                    pendingDocuments.ForEach(pendingDocument => context.AvbobPendingQuotationDocuments.Add(pendingDocument));
                    context.SaveChanges();
                }
            }
        }

        #endregion

        #endregion

    }
}
