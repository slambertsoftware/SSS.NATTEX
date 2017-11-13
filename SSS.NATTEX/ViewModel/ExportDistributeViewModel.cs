using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.ViewModel
{
    public class ExportDistributeViewModel : MainViewModel
    {
        #region fields 
        private bool _isProceedEnbaled;
        private bool _isValidInput;
        private string _validationMessage;
        private string _quotationHeading;
        private string _controlCaption;
        private string _selectedExportOption;
        private string _selectedDistributionOption;
        private Visibility _validationMessageVisibility;
        private Visibility _proceedVisibility;
        public ObservableCollection<string> _distributionOptions;
        public ObservableCollection<string> _exportOptions;
        public ObservableCollection<QuotationDetailItem> _quotationDetails;

        #endregion

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

        public string SelectedExportOption
        {
            get
            {
                return _selectedExportOption;
            }
            set
            {
                _selectedExportOption = value;
                this.RaisePropertyChanged("SelectedExportOption");
                Validate();
            }
        }

        public string SelectedDistributionOption
        {
            get
            {
                return _selectedDistributionOption;
            }
            set
            {
                _selectedDistributionOption = value;
                this.RaisePropertyChanged("SelectedDistributionOption");
                Validate();
            }
        }

        public ObservableCollection<string> ExportOptions
        {
            get
            {
                return _exportOptions;
            }
            set
            {
                _exportOptions = value;
                this.RaisePropertyChanged("ExportOptions");
            }
        }

        public ObservableCollection<string> DistributionOptions
        {
            get
            {
                return _distributionOptions;
            }
            set
            {
                _distributionOptions = value;
                this.RaisePropertyChanged("DistributionOptions");
            }
        }

        public bool IsValidInput
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

        public bool IsProceedEnbaled
        {
            get
            {
                return _isProceedEnbaled;
            }
            set
            {
                _isProceedEnbaled = value;
                this.RaisePropertyChanged("IsProceedEnbaled");
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

        public string QuotationHeading
        {
            get
            {
                return _quotationHeading;
            }
            set
            {
                _quotationHeading = value;
                this.RaisePropertyChanged("QuotationHeading");
            }
        }

        public ObservableCollection<QuotationDetailItem> QuotationDetails
        {
            get
            {
                return _quotationDetails;
            }
            set
            {
                _quotationDetails = value;
                this.RaisePropertyChanged("QuotationDetails");
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

        public Visibility ProceedVisibility
        {
            get
            {
                return _proceedVisibility;
            }
            set
            {
                _proceedVisibility = value;
                this.RaisePropertyChanged("ProceedVisibility");
            }
        }

        public DockingSetupModel LayoutModel { get; set; }

        public RelayCommand<Window> FinaliseCommand { get; set; }

        public RelayCommand<Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public ExportDistributeViewModel(DockingSetupModel layoutModel)
        {
            this.LayoutModel = layoutModel;
            this.ControlCaption = "Export and or Distribute Quotation";
            this.QuotationHeading = GenerateQuotationHeading();
            WireUpEvents();
        }
        #endregion

        #region methods
        private void WireUpEvents()
        {
            FinaliseCommand = new RelayCommand<Window>(FinaliseAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
        }

        private void FinaliseAction(Window window)
        {
            Window win = (Window)window;

            if (win != null)
            {
                Validate();
                if (IsValidInput)
                {
                    try
                    {
                        this.ValidationMessage = "" ;
                        this.ValidationMessageVisibility = Visibility.Collapsed;
                        this.IsValidInput = false;
                        GenerateExportQuotationDocument();
                    }
                    catch(Exception e)
                    {
                        this.ValidationMessage = "Please contact the system administrator if the problem persists. Note the following error message : " + e.Message;
                        this.ValidationMessageVisibility = Visibility.Visible;
                        this.IsValidInput = false;
                    }
                }
            }

        }

        private string GenerateQuotationHeading()
        {
            string result = string.Empty;
            result = "Quotation No: " + GetQuotationNumber();
            return result;
        }

        private string GetQuotationNumber()
        {
            string result = "QUO-NAT-20171020-0001";
            return result;
        }

        private void Validate()
        {
            this.IsValidInput = true;
            if (string.IsNullOrEmpty(this.SelectedDistributionOption))
            {
                this.ValidationMessage = "Please select a distribution option.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (string.IsNullOrEmpty(this.SelectedExportOption))
            {
                this.ValidationMessage = "Please select an export option.";
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

        private void ShowFinalisationMessage(string message)
        {
            MessageBox.Show(message, this.ControlCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }




        private void ReviewAction(Window window)
        {

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


        public void LoadExportOptions()
        {
            if (this.ExportOptions == null)
            {
                this.ExportOptions = new ObservableCollection<string>();
            }
            this.ExportOptions.Add("None");
            this.ExportOptions.Add("MS Excel");
            this.ExportOptions.Add("MS Word");
            this.ExportOptions.Add("PDF");
        }

        public void LoadDistributionOptions()
        {
            if (this.DistributionOptions == null)
            {
                this.DistributionOptions = new ObservableCollection<string>();
            }
            this.DistributionOptions.Add("None");
            this.DistributionOptions.Add("E-mail Distribution List");
            this.DistributionOptions.Add("SMS Distribution List");
        }

        private void GenerateExportQuotationDocument()
        {
            if (this.SelectedExportOption == "MS Excel")
            {
                GeneratMSExcelDocument();
            }
            else if (this.SelectedExportOption == "MS Word")
            {
                GeneratMSWordDocument();
            }
            else if (this.SelectedExportOption == "PDF")
            {
                GeneratPDFDocument();
            }
        }

        private void GeneratMSExcelDocument()
        {

        }

        private void GeneratMSWordDocument()
        {

        }
        private void GeneratPDFDocument()
        {

        }

        /// <summary>
        /// Distribute the quotation document via e-mail or other distribution chan
        /// </summary>
        private void DistributeQuotationDocument()
        {
            if (this.SelectedDistributionOption == "E-mail Distribution List")
            {

            }
        }

        private ObservableCollection<QuotationDetailItem> GetQuotationDetails()
        {
            ObservableCollection<QuotationDetailItem> result = new ObservableCollection<QuotationDetailItem>();
            return result;
        }

        /// <summary>
        /// Populate Quotation details
        /// </summary>
        private void PopulateQuotationDetails()
        {

        }
        /// <summary>
        /// Populate Quotation Summary
        /// </summary>
        private void PopulateQuotationSummary()
        {

        }





        #endregion
    }
}
