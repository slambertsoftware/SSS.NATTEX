using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class NewQuotationViewModel : MainViewModel
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
        private string _ValidationMessage;
        private string _uploadFileName;
        private string _uploadFileDescription;
        private string _quotationNumber;
        private string _documentOutputDirectory;
        private bool   _isValidInput;
        private bool   _isExistingCustomerChecked;
        private bool   _isFileBrowseButtonEnabled;

        private Visibility _validationMessageVisibility;
        private Visibility _customerSelectionVisibility;
        private Visibility _fileCheckListVisibility;
        private Visibility _uploadFileDescriptionVisibility;
        private Visibility _existingCustomerCheckedVisibility;

        private Customer _selectedCustomerItem;

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
                Validate();
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

        public Customer SelectedCustomerItem
        {
            get
            {
                return _selectedCustomerItem;
            }
            set
            {
                _selectedCustomerItem = value;
                this.RaisePropertyChanged("SelectedCustomerItem");
                Validate();
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
                return _ValidationMessage;
            }
            set
            {
                _ValidationMessage = value;
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

        public DockingSetupModel LayoutModel { get; set; }

        public RelayCommand<Window> ProceedCommand { get; set; }

        public RelayCommand<Window> CancelCommand { get; set; }

        public RelayCommand<Window> FileBrowseCommand { get; set; }

        public RelayCommand FileCheckListCommand { get; set; }

        #endregion

        #region constructors
        public NewQuotationViewModel(DockingSetupModel layoutModel)
        { 
            this.LayoutModel = layoutModel;
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
            this.ResetUploadFileControl();
            this.IsFileBrowseButtonEnabled = true;

            WireUpEvents();
        }
        #endregion


        #region methods
        public void UpdateValidationStatus()
        {
            this.Validate();
        }

        private void Validate()
        {
            this.IsValidInput = true;

            if (string.IsNullOrEmpty(this.SelectedQuotationType))
            {
                this.ValidationMessage = "Please select a quotation type.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (string.IsNullOrEmpty(this.CustomerName))
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

            this.QuotationTypes.Add(string.Empty);
            this.QuotationTypes.Add("Society Scheme Quotation");
            this.QuotationTypes.Add("Single Member Quotation");
        }

        private void PopulatePricingModels()
        {
            if (this.PricingModels == null)
            {
                this.PricingModels = new ObservableCollection<string>();
            }
            this.PricingModels.Add(string.Empty);
            this.PricingModels.Add("Avbob");
            this.PricingModels.Add("Liberty");
        }

        private void PopulateExistingCustomers()
        {
            if (this.Customers == null)
            {
                this.Customers = new ObservableCollection<Customer>();
            }
        }

        private void WireUpEvents()
        {
            FileBrowseCommand = new RelayCommand<Window>(FileBrowseAction);
            FileCheckListCommand = new RelayCommand(FileCheckListAction);
            ProceedCommand = new RelayCommand<Window>(ProceedAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
        }

        private void UpdateCustomerSelectionVisibility()
        {
            if (this.IsExistingCustomerChecked)
            {
                this.CustomerSelectionVisibility = Visibility.Visible;
            }
            else
            {
                this.CustomerSelectionVisibility = Visibility.Collapsed;
                this.SelectedCustomerItem = null;
                this.SelectedCustomerName = string.Empty;
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
            if ((!string.IsNullOrWhiteSpace(this.UploadFileName)) && (string.IsNullOrWhiteSpace(this.UploadFileDescription)))
            {
                Validate();
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

        private void SetExistingCustomerNumber()
        {
            string result = string.Empty;
            result = "NAT" + "-" + "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + GetNewCustomerSequenceNumber();
            this.CustomerNumber = result;
        }

        private string GenerateNewCustomerNumber()
        {
            string result = string.Empty;
            result = result = "NAT" + "-" + "C" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerName.Substring(0, 3).ToUpper() + GetNewCustomerSequenceNumber();
            this.CustomerNumber = result;
            return result;
        }

        private string GetNewCustomerSequenceNumber()
        {
            string result = string.Empty;
            result = "0001";
            return result;
        }

        private string GetNewQuotationSequenceNumber()
        {
            string result = string.Empty;
            result = "0001";
            return result;
        }

        private string GenerateNewQuoationNumber()
        {
            string result = string.Empty;
            result = "NAT" + "-" + "Q" + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + this.CustomerNumber.Substring(15, 7) + "-" + GetNewQuotationSequenceNumber();
            this.QuotationNumber = result;
            return result;
        }

        private bool IsDuplicateCustomerName()
        {
            bool result = false;

            return result;
        }

        private ObservableCollection<Customer> GetCustomers()
        {
            ObservableCollection<Customer> result = new ObservableCollection<Customer>();
            return result;
        }

        private void ProceedAction(Window window)
        {
            Window win = (Window)window;
            
            if (win != null)
            {
                Validate();
                if (IsValidInput)
                {
                    if (this.IsExistingCustomerChecked)
                    {
                        SetExistingCustomerNumber();
                    }
                    else
                    {
                        GenerateNewCustomerNumber();
                    }

                    this.GenerateNewQuoationNumber();
                    this.DocumentOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NATTEX\NAMS\Quotations\" + this.QuotationNumber + @"\";
                    if (!Directory.Exists(this.DocumentOutputDirectory))
                    {
                        Directory.CreateDirectory(this.DocumentOutputDirectory);
                    }

                    if ((this.QuotationDocuments != null) && (this.QuotationDocuments.Count > 0))
                    {
                        foreach(QuotationUploadDocument document in this.QuotationDocuments)
                        {
                            if ((document.IsFileSelected) && (File.Exists(document.FilePath)))
                            {
                                var destinationFilePath = this.DocumentOutputDirectory + document.FileName + document.FileExtension;
                                System.IO.File.Copy(document.FilePath, destinationFilePath, true);
                                document.CopyToFilePath = destinationFilePath;
                            }
                        }
                    }

                    NewQuotation newQuotationModel = new NewQuotation()
                    {
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
                         QuotationPreparedBy = "NAMS Administrator",
                         QuotationDocuments = this.QuotationDocuments.ToList()
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
                    this.LayoutModel.Document.Content = new CaptureMemberMinDetailsUserControl(this.LayoutModel, newQuotationModel);
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

        private void FileCheckListAction()
        {

        }
        #endregion
    }
}
