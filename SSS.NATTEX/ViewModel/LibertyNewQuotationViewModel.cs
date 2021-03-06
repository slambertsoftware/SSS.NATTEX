﻿using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.ViewModel
{
    public class LibertyNewQuotationViewModel : MainViewModel
    {
        private string _controlCaption;
        private string _selectedQuotationType;
        private string _selectedCustomerName;
        private string _selectedPricingModel;
        private string _customerName;
        private string _customerNumber;
        private string _customerAddress;
        private string _customerContactNo;
        private string _customerEmail;
        private string _customerOtherInfo;
        private string _validationMessage;
        private string _uploadFileName;
        private string _uploadFileDescription;
        private string _quotationNumber;
        private string _documentOutputDirectory;
        private bool   _isValidInput;
        private bool   _isExistingCustomerChecked;
        private bool   _isFileBrowseButtonEnabled;
        private int    _customerID;
        private int    _pendingQuotationID;

        private bool _isCustomerNameEnabled;
        private bool _isCustomerAddressEnabled;
        private bool _isCustomerEmailEnabled;
        private bool _isCustomerContactNumberEnabled;
        private bool _isCustomerOtherInfoEnabled;

        private Visibility _validationMessageVisibility;
        private Visibility _customerSelectionVisibility;
        private Visibility _fileCheckListVisibility;
        private Visibility _uploadFileDescriptionVisibility;
        private Visibility _existingCustomerCheckedVisibility;

        private CurrentLogin _currentLogin;
        private ObservableCollection<string> _quotationTypes;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<string> _pricingModels;
        private ObservableCollection<QuotationUploadDocument> _quotationDocuments;

        #region properties
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

        public string SelectedQuotationType
        {
            get
            {
                return _selectedQuotationType;
            }
            set
            {
                _selectedQuotationType = value;
                this.RaisePropertyChanged("SelectedQuotationType");
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
                UpdateCustomerNumber();
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
                _customerAddress  = value;
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

        public string SelectedPricingModel
        {
            get
            {
                return _selectedPricingModel;
            }
            set
            {
                _selectedPricingModel = value;
                this.RaisePropertyChanged("SelectedPricingModel");
                this.SelectedQuotationType = _selectedPricingModel;
                UpdatePricingModelValidation();
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

 

        public ObservableCollection<string> QuotationTypes
        {
            get
            {
                return _quotationTypes;
            }
            set
            {
                _quotationTypes = value;
                this.RaisePropertyChanged("QuotationTypes");
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

        public ObservableCollection<string> PricingModels
        {
            get
            {
                return _pricingModels;
            }
            set
            {
                _pricingModels = value;
                this.RaisePropertyChanged("PricingModels");
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

        public DockingSetupModel LayoutModel { get; set; }

        public RelayCommand<Window> ProceedCommand { get; set; }

        public RelayCommand<Window> CancelCommand { get; set; }

        public RelayCommand<Window> FileBrowseCommand { get; set; }

        public RelayCommand<QuotationUploadDocument> FileCheckListCommand { get; set; }

        public RelayCommand CustomerSelectionChangedCommand { get; set; }

        #endregion

        #region constructors
        public LibertyNewQuotationViewModel(DockingSetupModel layoutModel, CurrentLogin currentLogin)
        { 
            this.LayoutModel = layoutModel;
            this.CurrentLogin = currentLogin;

            this.ControlCaption = "CREATE A NEW QUOTATION";
            PopulateQuotationTypes();
            PopulateExistingCustomers();
            if (this.Customers.Count > 0)
            {
                this.ExistingCustomerCheckedVisibility = Visibility.Visible;
            }
            else
            {
                this.ExistingCustomerCheckedVisibility = Visibility.Collapsed;
            }
            PopulatePricingModels();

            this.ValidationMessage = "";
            this.ValidationMessageVisibility = Visibility.Collapsed;
            this.CustomerSelectionVisibility = Visibility.Collapsed;
            this.FileCheckListVisibility = Visibility.Collapsed;
            this.IsCustomerAddressEnabled = true;
            this.IsCustomerContactNumberEnabled = true;
            this.IsCustomerEmailEnabled = true;
            this.IsCustomerNameEnabled = true;
            this.IsCustomerOtherInfoEnabled = true;

            this.ResetUploadFileControl();
            this.IsFileBrowseButtonEnabled = true;

            WireUpEvents();
        }
        #endregion


        #region methods

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
            else if ((this.IsExistingCustomerChecked) & (string.IsNullOrWhiteSpace(this.SelectedCustomerName)))
            {
                this.ValidationMessage = "Please select an existing customer.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }

            else if (string.IsNullOrWhiteSpace(this.SelectedPricingModel))
            {
                this.ValidationMessage = "Please select a pricing model.";
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

        private void ShowValidationMessage(string message)
        {
            MessageBox.Show(message, this.ControlCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        private void ShowValidationDialog(string message)
        {
            MessageBox.Show(message, this.ControlCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void PopulateQuotationTypes()
        {
            if (this.QuotationTypes == null)
            {
                this.QuotationTypes = new ObservableCollection<string>();
            }

            using (var context = new NattexApplicationContext())
            {
                foreach (QuotationType model in (context.QuotationTypes.ToList()).OrderBy(x => x.TypeName))
                {
                    this.QuotationTypes.Add(model.TypeName);
                }
            }
        }

        private void PopulatePricingModels()
        {
            if (this.PricingModels == null)
            {
                this.PricingModels = new ObservableCollection<string>();
            }
            using (var context = new NattexApplicationContext())
            {
                foreach (PricingModel model in (context.PricingModels.ToList()).OrderBy(x => x.PricingName)) {
                    this.PricingModels.Add(model.PricingName);
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

        private void WireUpEvents()
        {
            FileBrowseCommand = new RelayCommand<Window>(FileBrowseAction);
            FileCheckListCommand = new RelayCommand<QuotationUploadDocument>(FileCheckListAction);
            ProceedCommand = new RelayCommand<Window>(ProceedAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
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

        private void UpdatePricingModelValidation()
        {
           
            if (string.IsNullOrWhiteSpace(this.SelectedPricingModel))
            {
                this.ValidationMessage = "Please select a pricing model.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = ".";
                this.ValidationMessageVisibility = Visibility.Collapsed;
                this.IsValidInput = true;
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
                    foreach(Customer customer in customers)
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
                    var quotations = context.LibertyPendingQuotations.ToList();
                    if ((quotations != null) && (quotations.Count > 0))
                    {
                        foreach (LibertyPendingQuotation quotation in quotations)
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
                        result = true;
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
                    if (customer!= null)
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

        private void SaveNewCustomer()
        {
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
                    this.CustomerID = customer.CustomerID;
                }
            }
        }

        private void SaveNewQuotation()
        {
            LibertyPendingQuotation pendingQuotation = new LibertyPendingQuotation()
            {
                QuotationHeader = "",
                QuotationType = this.SelectedQuotationType,
                QuotationNumber = this.QuotationNumber,
                IsExistingCustomer = this.IsExistingCustomerChecked,
                SelectedCustomer = this.SelectedCustomerName,
                CustomerID = this.CustomerID,
                CustomerNumber = this.CustomerNumber,
                CustomerName = this.CustomerName,
                CustomerAddress = this.CustomerAddress,
                CustomerContactNumber = this.CustomerContactNumber,
                CustomerEmailAddress = this.CustomerEmail,
                CustomerOtherInfo = this.CustomerOtherInfo,
                PricingModel = this.SelectedPricingModel,
                QuotationPreparedBy = this.CurrentLogin.UserFirstName + " " + this.CurrentLogin.UserLastName,
                QuotationCreateDate = DateTime.Now.ToString("D", CultureInfo.InvariantCulture),
                CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                CreateUserID = this.CurrentLogin.UserID,
                IsActive = true
            };

            using (var context = new NattexApplicationContext())
            {
                context.LibertyPendingQuotations.Add(pendingQuotation);
                context.SaveChanges();
                this.PendingQuotationID = pendingQuotation.LibertyPendingQuotationID;
            }
        }

        private void SaveNewQuotationDocuments()
        {
            if ((this.QuotationDocuments != null) && (this.QuotationDocuments.Count > 0))
            {
                List<LibertyPendingQuotationDocument> pendingDocuments = new List<LibertyPendingQuotationDocument>();
                foreach(QuotationUploadDocument document in this.QuotationDocuments)
                {
                    LibertyPendingQuotationDocument pendingDocument = new LibertyPendingQuotationDocument()
                    {
                        LibertyPendingQuotationID = this.PendingQuotationID,
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
                    pendingDocuments.ForEach(pendingDocument => context.LibertyPendingQuotationDocuments.Add(pendingDocument));
                    context.SaveChanges();
                }
            }
        }

        private void ProceedAction(Window window)
        {
            Window win = (Window)window;

            if (win != null)
            {
                Validate();
                if (IsValidInput)
                {
                    if (!(this.IsExistingCustomerChecked))
                    {
                        GenerateNewCustomerNumber();
                        SaveNewCustomer();
                    }
                    this.GenerateNewQuoationNumber();

                    SaveNewQuotation();

                    this.DocumentOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NATTEX\NAMS\Quotations\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\" + this.QuotationNumber + @"\";

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

                    LibertyNewQuotation newQuotationModel = new LibertyNewQuotation()
                    {
                        QuotationID = this.PendingQuotationID,
                        QuotationNumber = this.QuotationNumber,
                        QuotationType = this.SelectedQuotationType,
                        IsExistingCustomer = this.IsExistingCustomerChecked,
                        SelectedCustomer = this.SelectedCustomerName,
                        CustomerNumber = this.CustomerNumber,
                        CustomerName = this.CustomerName,
                        CustomerAddress = this.CustomerAddress,
                        CustomerContactNumber = this.CustomerContactNumber,
                        CustomerEmailAddress = this.CustomerEmail,
                        CustomerOtherInfo = this.CustomerOtherInfo,
                        PricingModel = this.SelectedPricingModel,
                        QuotationPreparedBy = this.CurrentLogin.UserFirstName + " " + this.CurrentLogin.UserLastName,
                        QuotationCreateDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                        QuotationDocuments = this.QuotationDocuments == null ? (this.QuotationDocuments = new ObservableCollection<QuotationUploadDocument>()).ToList() : QuotationDocuments.ToList()
                    };

                    this.LayoutModel.DocumentPane.Children.Remove(this.LayoutModel.Document);
                    this.LayoutModel.Document = new LayoutDocument()
                    {
                        ContentId = "QM-002",
                        IsActive = true,
                        Title = "2. DATA CAPTURING",
                        CanClose = false,
                        CanFloat = true,
                        IsMaximized = false,
                        IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_4_24.png", UriKind.Relative))
                    };
                    this.LayoutModel.Document.Content = new CaptureNewProspectiveMembersUserControl(this.LayoutModel, newQuotationModel, this.CurrentLogin);
                    this.LayoutModel.DocumentPane.Children.Add(this.LayoutModel.Document);
                    this.LayoutModel.Document.PreviousContainerIndex = this.LayoutModel.DocumentPane.Children.IndexOf(this.LayoutModel.Document);
                    this.LayoutModel.Document.Parent = this.LayoutModel.DocumentPane;
                    this.LayoutModel.Document.DockAsDocument();
                }
            }
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="window">The window.</param>
        private void CancelAction(Window window)
        {
            Window win = (Window)window;
            if (win != null)
            {
                win.Close();
            }
        }

        private void FileBrowseAction(Window window)
        {
            if (this.QuotationDocuments == null)
            {
                this.QuotationDocuments = new ObservableCollection<QuotationUploadDocument>();
            }
            string filename = string.Empty;
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
                filename = dlg.FileName;
                this.UploadFileName = filename;
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

        private void FileCheckListAction(QuotationUploadDocument uploadDocument)
        {
            if ((uploadDocument != null) && (!uploadDocument.IsFileSelected))
            {
                if (this.QuotationDocuments.Contains(uploadDocument))
                {
                    int index = this.QuotationDocuments.IndexOf(uploadDocument);
                    this.QuotationDocuments.RemoveAt(index);
                }
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
    }
}
