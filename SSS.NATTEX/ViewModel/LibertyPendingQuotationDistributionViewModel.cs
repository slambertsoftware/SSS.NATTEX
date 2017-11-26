using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Xceed.Words.NET;
using Xceed.Wpf.AvalonDock.Layout;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System.Windows.Xps.Packaging;
using SSS.NATTEX.Views;
using SSS.NATTEX.DAL;
using System.ComponentModel;

namespace SSS.NATTEX.ViewModel
{
    public class LibertyPendingQuotationDistributionViewModel : MainViewModel
    {
        #region fields 
        private readonly BackgroundWorker BackgroundWorker = new BackgroundWorker();
        private string _templatesDirectory;
        private string _documentOutputDirectory;
        private string _validationMessage;
        private string _quotationHeading;
        private string _quotationNumber;
        private string _quotationCustomerNumber;
        private string _controlCaption;
        private string _selectedExportOption;
        private string _selectedDistributionOption;
        

        private string _quotationWordDocumentFilePath;
        private string _quotationXPSDocumentFilePath;
        private string _quotationPrintDateTime;
        private string _busyMessage;


        private bool _isProceedEnbaled;
        private bool _isValidInput;
        private bool _isBusyStatus;

        private Visibility _isBusyVisibility;
        private Visibility _validationMessageVisibility;
        private Visibility _proceedVisibility;

        private Dictionary<string, string> _replacementPatterns;
        private Dictionary<string, string> _documentCustomProperties;
        private Dictionary<string, string> _documentCoreProperties;
        private XpsDocument _quotationXPSDocument;
        private LibertyPendingQuotation _pendingQuotation;
        private ObservableCollection<string> _distributionOptions;
        private ObservableCollection<string> _exportOptions;
        private ObservableCollection<QuotationCalculationItem> _quotationDetails;

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

        public string QuotationNumber
        {
            get
            {
                return _quotationNumber;
            }
            set
            {
                _quotationNumber = value;
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

        public string QuotationCustomerNumber
        {
            get
            {
                return _quotationCustomerNumber;
            }
            set
            {
                _quotationCustomerNumber = value;
                this.RaisePropertyChanged("QuotationCustomerNumber");
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

        public string TemplatesDirectory
        {
            get
            {
                return _templatesDirectory;
            }
            private set
            {
                _templatesDirectory = value;
                this.RaisePropertyChanged("TemplatesDirectory");
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

        public XpsDocument QuotationXPSDocument
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

        public string QuotationXPSDocumentFilePath
        {
            get
            {
                return _quotationXPSDocumentFilePath;
            }
            set
            {
                _quotationXPSDocumentFilePath = value;
                this.RaisePropertyChanged("QuotationXPSDocumentFilePath");
            }
        }

        public string QuotationWordDocumentFilePath
        {
            get
            {
                return _quotationWordDocumentFilePath;
            }
            set
            {
                _quotationWordDocumentFilePath = value;
                this.RaisePropertyChanged("QuotationWordDocumentFilePath");
            }
        }

        public string QuotationPrintDateTime
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            set
            {
                _quotationPrintDateTime = value;
                this.RaisePropertyChanged("QuotationPrintDateTime");
            }
        }

        public Dictionary<string, string> ReplacementPatterns
        {
            get
            {
                return _replacementPatterns;
            }
            set
            {
                _replacementPatterns = value;
                this.RaisePropertyChanged("ReplacementPatterns");
            }
        }

        public Dictionary<string, string> DocumentCustomProperties
        {
            get
            {
                return _documentCustomProperties;
            }
            set
            {
                _documentCustomProperties = value;
                this.RaisePropertyChanged("DocumentCustomProperties");
            }

        }

        public Dictionary<string, string> DocumentCoreProperties
        {
            get
            {
                return _documentCoreProperties;
            }
            set
            {
                _documentCoreProperties = value;
                this.RaisePropertyChanged("DocumentCoreProperties");
            }

        }

        public ObservableCollection<QuotationCalculationItem> QuotationDetails
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

        public bool IsBusyStatus
        {
            get
            {
                return _isBusyStatus;
            }
            set
            {
                _isBusyStatus = value;
                this.RaisePropertyChanged("IsBusyStatus");
            }
        }

        public string BusyMessage
        {
            get
            {
                return _busyMessage;
            }
            set
            {
                _busyMessage = value;
                this.RaisePropertyChanged("BusyMessage");
            }
        }

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

        public Visibility IsBusyVisibility
        {
            get
            {
                return _isBusyVisibility;
            }
            set
            {
                _isBusyVisibility = value;
                this.RaisePropertyChanged("IsBusyVisibility");
            }
        }

        public DockingSetupModel LayoutModel { get; set; }

        public LibertyNewQuotation QuotationModel { get; set; }

        public CurrentLogin CurrentLogin { get; set; }

        public System.Windows.Window CurrentWindow { get; set; }

        public RelayCommand<System.Windows.Window> FinaliseCommand { get; set; }

        public RelayCommand<System.Windows.Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public LibertyPendingQuotationDistributionViewModel(DockingSetupModel layoutModel, LibertyNewQuotation quotationModel, CurrentLogin currentLogin)
        {
            this.LayoutModel = layoutModel;
            this.QuotationModel = quotationModel;
            this.CurrentLogin = currentLogin;
            this.PopulatePendingQuotation();
            this.ControlCaption = "Export and Distribute Quotation";
            this.TemplatesDirectory = @"Templates\";
            this.DocumentOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NATTEX\NAMS\Quotations\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\" 
                + quotationModel.CustomerNumber + @"\";
            if (!Directory.Exists(this.DocumentOutputDirectory))
            {
                Directory.CreateDirectory(this.DocumentOutputDirectory);
            }
            this.QuotationHeading = GenerateQuotationHeading();
            this.ValidationMessageVisibility = Visibility.Collapsed;
            this.ValidationMessage = "";
            this.IsBusyStatus = false;
            this.IsBusyVisibility = Visibility.Collapsed;

            BackgroundWorker.DoWork += BackgroundWorker_DoWork; ;
            BackgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.WorkerSupportsCancellation = true; //Allow for the process to be cancelled

            WireUpEvents();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            QuotationDocumentViewerWindow viewer = new QuotationDocumentViewerWindow(this.QuotationModel, this.CurrentLogin);
            viewer.Owner = System.Windows.Application.Current.MainWindow;
            viewer.ShowActivated = true;
            viewer.ShowInTaskbar = true;
            viewer.BringIntoView();
        
            this.IsBusyStatus = false;
            this.IsBusyVisibility = Visibility.Collapsed;
            this.CurrentWindow.Close();
            viewer.ShowDialog();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            this.BusyMessage = (e.UserState as string);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.IsBusyStatus = true;
            this.IsBusyVisibility = Visibility.Visible;
            GenerateExportQuotationDocument();
        }
        #endregion

        #region methods
        private void PopulatePendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                LibertyPendingQuotation quotation = context.LibertyPendingQuotations.Where(x => x.LibertyPendingQuotationID == this.QuotationModel.QuotationID).FirstOrDefault<LibertyPendingQuotation>();
                if (quotation != null)
                {
                    this.PendingQuotation = quotation;
                }
            }
        }

        private void WireUpEvents()
        {
            FinaliseCommand = new RelayCommand<System.Windows.Window>(FinaliseAction);
            CancelCommand = new RelayCommand<System.Windows.Window>(CancelAction);
        }

        private void FinaliseAction(System.Windows.Window window)
        {
            System.Windows.Window win = (System.Windows.Window)window;
            this.CurrentWindow = win;
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
                        this.BackgroundWorker.RunWorkerAsync();
                        this.BackgroundWorker.ReportProgress(5, "Generating quotation document...");
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

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="window">The window.</param>
        private void CancelAction(System.Windows.Window window)
        {
            System.Windows.Window win = (System.Windows.Window)window;
            if (win != null)
            {
                win.Close();
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
            string result = this.QuotationModel.QuotationNumber;
            return result;
        }

        private void Validate()
        {
            this.IsValidInput = true;
            var filePath = this.DocumentOutputDirectory + GenerateOutputWordDocumentName();

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
            else if (File.Exists(filePath) && (this.IsFileInUse(filePath)))
            {
                this.ValidationMessage = "Please contact the system administrator if the problem persists. Note the following error message : " + 
                    "Quotation document is in use. Please save and close document and retry again. ";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.IsValidInput = true;
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

        public void LoadExportOptions()
        {
            if (this.ExportOptions == null)
            {
                this.ExportOptions = new ObservableCollection<string>();
            }
            this.ExportOptions.Add("MS Word");
        }

        public void LoadDistributionOptions()
        {
            if (this.DistributionOptions == null)
            {
                this.DistributionOptions = new ObservableCollection<string>();
            }
            this.DistributionOptions.Add("None");
        }

        private void GenerateExportQuotationDocument()
        {
            if (this.SelectedExportOption == "MS Excel")
            {
                GenerateMSExcelDocument();
            }
            else if (this.SelectedExportOption == "MS Word")
            {
                GenerateMSWordDocument();
            }
            else if (this.SelectedExportOption == "PDF")
            {
                GeneratePDFDocument();
            }
        }

        private void GenerateMSExcelDocument()
        {

        }

        private void GenerateMSWordDocument()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            string resourceName = GetQuotationDocumentResourceName();
            Stream docStream = _assembly.GetManifestResourceStream(resourceName);
            Validate();
            this.BackgroundWorker.ReportProgress(10, "Generating word document");
            if (this.QuotationModel != null)
            {
                PopulateReplacementPatterns();
                if ((docStream != null) && (IsValidInput))
                {
                    using (DocX document = DocX.Load(docStream))
                    {
                        document.AddCustomProperty(new Xceed.Words.NET.CustomProperty("CompanyName", "Nattex Funeral Schemes"));
                        document.AddCustomProperty(new Xceed.Words.NET.CustomProperty("Product", "NATTEX Application Management System (NAMS)"));
                        document.AddCustomProperty(new Xceed.Words.NET.CustomProperty("Address", "Kimberley, Northern Cape, South Africa"));
                        document.AddCustomProperty(new Xceed.Words.NET.CustomProperty("Date", DateTime.Now));
                        document.AddCoreProperty("dc:title", "Quotation document - " + this.QuotationNumber + "docx");
                        document.AddCoreProperty("dc:subject", "Quotation document");
                        document.AddCoreProperty("dc:creator", "NAMS");
                      

                        var searchValueList = document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase);
                        if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count == this.ReplacementPatterns.Count)
                        {
                            for (int i = 0; i < searchValueList.Count; ++i)
                            {
                                document.ReplaceText(searchValueList[i], GetReplacementValue(searchValueList[i]), false, RegexOptions.IgnoreCase);
                            }
                            this.BackgroundWorker.ReportProgress(75, "Quotation data synchronised.");
                            try
                            {
                                this.QuotationWordDocumentFilePath = this.DocumentOutputDirectory + GenerateOutputWordDocumentName();
                                this.QuotationXPSDocumentFilePath = this.DocumentOutputDirectory + GenerateOutputXPSDocumentName();
                                this.QuotationPrintDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                document.SaveAs(this.QuotationWordDocumentFilePath);
                                this.BackgroundWorker.ReportProgress(85, "Quotation document (.docx) saved.");
                                this.QuotationXPSDocument = ConvertWordDocumentToXPSDocument(this.QuotationWordDocumentFilePath, this.QuotationXPSDocumentFilePath);
                                this.BackgroundWorker.ReportProgress(85, "Quotation document (.xps) saved.");
                                this.QuotationModel.QuotationXPSDocument = this.QuotationXPSDocument;
                                this.BackgroundWorker.ReportProgress(95, "Processing completed.");
                                this.BackgroundWorker.ReportProgress(100, "Done.");
                            }
                            catch (IOException exp)
                            {
                                this.ValidationMessage = "Please contact the system administrator if the problem persists. " + "Note the following: " + exp.Message;
                                this.ValidationMessageVisibility = Visibility.Visible;
                                this.IsValidInput = false;
                            }
                        }
                    }
                }
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GenerateMSWordDocument();
        }

        private void GeneratePDFDocument()
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

        private ObservableCollection<QuotationCalculationItem> GetQuotationDetails()
        {
            ObservableCollection<QuotationCalculationItem> result = new ObservableCollection<QuotationCalculationItem>();
            return result;
        }

        private void PopulateReplacementPatterns()
        {
            if (this.ReplacementPatterns == null)
            {
                this.ReplacementPatterns = new Dictionary<string, string>();
            }
                this.ReplacementPatterns.Add("<QuotationHeader>",this.PendingQuotation.QuotationHeader);
                this.ReplacementPatterns.Add("<CustomerNumber>", this.PendingQuotation.CustomerNumber);
                this.ReplacementPatterns.Add("<CustomerName>", this.PendingQuotation.CustomerName);
                this.ReplacementPatterns.Add("<CustomerAddress>", this.PendingQuotation.CustomerAddress);

                this.ReplacementPatterns.Add("<CustomerContactNumber>", this.PendingQuotation.CustomerContactNumber);
                this.ReplacementPatterns.Add("<CustomerEmailAddress>", this.PendingQuotation.CustomerEmailAddress);

                this.ReplacementPatterns.Add("<QuotationNo>", this.PendingQuotation.QuotationNumber);

                this.ReplacementPatterns.Add("<QuotationCreateDate>", this.PendingQuotation.QuotationCreateDate);
                this.ReplacementPatterns.Add("<QuotationExpiryDate>", this.PendingQuotation.QuotationExpiryDate);
                this.ReplacementPatterns.Add("<QuotationPreparedBy>", this.PendingQuotation.QuotationPreparedBy);
                this.ReplacementPatterns.Add("<QuotationValidDays>", Convert.ToString(this.PendingQuotation.QuotationValidDays));
                this.ReplacementPatterns.Add("<MonthlyPremiumDescription>", this.PendingQuotation.MonthlyPremiumDescription);

                this.ReplacementPatterns.Add("<MonthlyPremiumCost>", "R " + Convert.ToString(this.PendingQuotation.MonthlyPremium));
                this.ReplacementPatterns.Add("<MonthlyAdminFeeDescription>", Convert.ToString(this.PendingQuotation.MonthlyAdminFeeDescription));
                this.ReplacementPatterns.Add("<MonthlyAdminFeeCost>", "R " + Convert.ToString(this.PendingQuotation.AdminFee));

                this.ReplacementPatterns.Add("<OnceOffJoiningFeeDescription>", this.PendingQuotation.JoiningFeeDescription);
                this.ReplacementPatterns.Add("<OnceOffJoiningFeeCost>", "R " + Convert.ToString(this.PendingQuotation.JoiningFee));

                this.ReplacementPatterns.Add("<NumMonthlyInstallments>", Convert.ToString(this.PendingQuotation.NumOfMonthlyInstallments));
                this.ReplacementPatterns.Add("<MonthlyInstallment>", "R " + Convert.ToString(this.PendingQuotation.JoiningFeePerMember));
                this.ReplacementPatterns.Add("<TotalQuotationValue>", "R " + Convert.ToString(this.PendingQuotation.QuotationValue));
            
        }

        private string GetQuotationDocumentResourceName()
        {
            string result = string.Empty;
            if (this.QuotationModel.PricingModel == "Avbob")
            {
                result = "SSS.NATTEX.Resources.Templates.NATTEX_QuotationTemplate_AVBOB.docx";
            }
            else if (this.QuotationModel.PricingModel == "Liberty")
            {
                result = "SSS.NATTEX.Resources.Templates.NATTEX_QuotationTemplate_LIBERTY.docx";

            }
            return result;
        }

        private string GetTemplateFilePath()
        {
            string result = string.Empty;
            result = Convert.ToString(this.TemplatesDirectory) + @"NATTEX_QuotationTemplate_AVBOB.docx";
            return result;
        }

        private string GenerateOutputWordDocumentName()
        {
            string result = string.Empty;
            result = this.QuotationModel.QuotationNumber + "_" + this.QuotationPrintDateTime + ".docx";
            return result;
        }
        private string GenerateOutputXPSDocumentName()
        {
            string result = string.Empty;
            result = this.QuotationModel.QuotationNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xps";
            return result;
        }


        private string GetReplacementValue(string searchValue)
        {
            if (this.ReplacementPatterns.ContainsKey(searchValue))
            {
                return this.ReplacementPatterns[searchValue];
            }
            return searchValue;
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

        private List<Xceed.Words.NET.CustomProperty> GetDocumentCustomProperties()
        {
            List<Xceed.Words.NET.CustomProperty> result = new List<Xceed.Words.NET.CustomProperty>();
            return result;
        }

        private XpsDocument ConvertWordDocumentToXPSDocument(string wordDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);


            Document doc = wordApplication.ActiveDocument;
            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApplication.Quit();

                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
            }
             finally
            {
                if (wordApplication != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApplication);
                    GC.Collect(); 
                }
            }
            return null;
        }
        #endregion
    }
}
