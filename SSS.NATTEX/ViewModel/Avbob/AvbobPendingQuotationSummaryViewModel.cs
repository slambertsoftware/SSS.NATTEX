using GalaSoft.MvvmLight.Command;
using Microsoft.Office.Interop.Word;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views;
using SSS.NATTEX.Views.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;
using Xceed.Words.NET;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.ViewModel.Avbob
{
    public class AvbobPendingQuotationSummaryViewModel : MainViewModel
    {
        #region fields
        private readonly BackgroundWorker BackgroundWorker = new BackgroundWorker();
        private string _templatesDirectory;
        private string _documentOutputDirectory;
        private string _controlCaption;
        private string _quotationNumberHeader;
        private string _quotationSummaryHeader;
        private string _quotationCustomerNameHeader;
        private string _quotationHeader;
        private string _quotationCreateDate;
        private string _quotationExpiryDate;
        private string _monthlyPremiumDescription;
        private string _monthlyPremium;
        private string _validQuotationDays;
        private string _monthlyAdminFeeDescription;
        private string _monthlyAdminFee;
        private string _onceOffJoiningFeeDescription;
        private string _onceOffJoiningFee;
        private string _quotationValue;
        private string _joiningFeeMessage;
        private string _quotationWordDocumentFilePath;
        private string _quotationXPSDocumentFilePath;
        private string _quotationPrintDateTime;
        private string _validationMessage;
        private bool _isValidInput;
        private bool _isSpinningWheelSpinning;
        private bool _isSymmetricalArranged;
        private XpsDocument _quotationXPSDocument;
        private AvbobPendingQuotation _avbobPendingQuotation;
        private AvbobPendingQuotationPolicySummary _avbobQuotationPolicySummary;
        private Dictionary<string, string> _replacementPatterns;
        private Dictionary<string, string> _documentCustomProperties;
        private double _spinningWheelRadius;
        private double _spinningDotRadius;
        private double _spinningDotSpeed;
        private int _spinningDotCount;
        private SolidColorBrush _spinningDotColor;



        private Visibility _validationMessageVisibility;
        private Visibility _spinningWheelVisibility;

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

        public string QuotationNumberHeader
        {
            get
            {
                return _quotationNumberHeader;
            }
            set
            {
                _quotationNumberHeader = value;
                this.RaisePropertyChanged("QuotationNumberHeader");
            }
        }

        public string QuotationCustomerNameHeader
        {
            get
            {
                return _quotationCustomerNameHeader;
            }
            set
            {
                _quotationCustomerNameHeader = value;
                this.RaisePropertyChanged("QuotationCustomerNameHeader");
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

        public string QuotationSummaryHeader
        {
            get
            {
                return _quotationSummaryHeader;
            }
            set
            {
                _quotationSummaryHeader = value;
                this.RaisePropertyChanged("QuotationSummaryHeader");
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

        public string MonthlyPremiumDescription
        {
            get
            {
                return _monthlyPremiumDescription;
            }
            set
            {
                _monthlyPremiumDescription = value;
                this.RaisePropertyChanged("MonthlyPremiumDescription");
            }
        }

        public string MonthlyPremium
        {
            get
            {
                return _monthlyPremium;
            }
            set
            {
                _monthlyPremium = value;
                this.RaisePropertyChanged("MonthlyPremium");
            }
        }

        public string ValidQuotationDays
        {
            get
            {
                return _validQuotationDays;
            }
            set
            {
                _validQuotationDays = value;
                this.RaisePropertyChanged("ValidQuotationDays");
            }
        }

        public string MonthlyAdminFeeDescription
        {
            get
            {
                return _monthlyAdminFeeDescription;
            }
            set
            {
                _monthlyAdminFeeDescription = value;
                this.RaisePropertyChanged("MonthlyAdminFeeDescription");
            }
        }

        public string MonthlyAdminFee
        {
            get
            {
                return _monthlyAdminFee;
            }
            set
            {
                _monthlyAdminFee = value;
                this.RaisePropertyChanged("MonthlyAdminFee");
            }
        }

        public string OnceOffJoiningFeeDescription
        {
            get
            {
                return _onceOffJoiningFeeDescription;
            }
            set
            {
                _onceOffJoiningFeeDescription = value;
                this.RaisePropertyChanged("OnceOffJoiningFeeDescription");
            }
        }

        public string OnceOffJoiningFee
        {
            get
            {
                return _onceOffJoiningFee;
            }
            set
            {
                _onceOffJoiningFee = value;
                this.RaisePropertyChanged("OnceOffJoiningFee");
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

        public CurrentLogin CurrentLogin { get; set; }

        public DockingSetupModel LayoutModel { get; set; }

        public AvbobQuotationModel QuotationModel { get; set; }

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

        public AvbobPendingQuotationPolicySummary AvbobQuotationPolicySummary
        {
            get
            {
                return _avbobQuotationPolicySummary;
            }
            set
            {
                _avbobQuotationPolicySummary = value;
                this.RaisePropertyChanged("AvbobQuotationPolicySummary");
            }
        }

        public System.Windows.Window CurrentWindow { get; set; }

        public RelayCommand<System.Windows.Window> ConfirmCommand { get; set; }

        public RelayCommand<System.Windows.Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public AvbobPendingQuotationSummaryViewModel(System.Windows.Window window, DockingSetupModel layoutModel, AvbobQuotationModel quotationModel, CurrentLogin currentLogin)
        {
            this.CurrentWindow = window;
            this.LayoutModel = layoutModel;
            this.QuotationModel = quotationModel;
            this.CurrentLogin = currentLogin;
            if (this.QuotationModel != null)
            {
                PopulateAvbobPendingQuotation(this.QuotationModel.QuotationID);
            }
            PopulatePendingQuotationSummary();
            PopulateQuotationFees();
            DoQuotationSummary();

            this.SpinningWheelVisibility = Visibility.Collapsed;
            this.IsSpinningWheelSpinning = false;
            this.WireUpEvents();
        }
        #endregion

        #region methods
        private void WireUpEvents()
        {
            ConfirmCommand = new RelayCommand<System.Windows.Window>(ConfirmAction);
            CancelCommand = new RelayCommand<System.Windows.Window>(CancelAction);
        }

        public void DoQuotationSummary()
        {
            this.QuotationSummaryHeader = "QUOTATION SUMMARY";
            this.QuotationCustomerNameHeader = AvbobPendingQuotation.CustomerName;
            this.QuotationHeader = "Quotation No. " + this.AvbobPendingQuotation.QuotationNumber + " for " + this.AvbobPendingQuotation.CustomerName;
            this.QuotationCreateDate = DateTime.Now.ToString("D", CultureInfo.InvariantCulture);
            this.ValidQuotationDays = Convert.ToString(GetQuotationValidDays());
            this.QuotationExpiryDate = DateTime.Now.AddDays(GetQuotationValidDays()).ToString("D", CultureInfo.InvariantCulture);
            this.MonthlyPremiumDescription = Convert.ToString((GetNumberOfPolicies())) + " policies with "  + this.AvbobPendingQuotation.NumberOfProspectiveMembers + " members @";
            this.MonthlyPremium = "R " + Convert.ToString(Math.Round(this.AvbobPendingQuotation.MonthlyPremium, 2));
            this.MonthlyAdminFeeDescription = "Monthly";
            this.MonthlyAdminFee = "R " + Convert.ToString(Math.Round(this.AvbobPendingQuotation.AdminFee));
            this.OnceOffJoiningFeeDescription = "Once off";
            this.OnceOffJoiningFee = "R " + Convert.ToString(Math.Round(this.AvbobPendingQuotation.JoiningFee));
            this.QuotationValue = "R " + Convert.ToString(Math.Round(this.AvbobPendingQuotation.QuotationValue));
            this.JoiningFeeMessage = "(The joining fee can be paid in " + Convert.ToString(this.AvbobPendingQuotation.NumOfMonthlyInstallments) + " easy installments of "
                + "R " + Convert.ToString(Math.Round(this.AvbobPendingQuotation.InstallmentJoiningFee)) + " per month)";
            this.AvbobPendingQuotation.QuotationHeader = this.QuotationHeader;
            this.AvbobPendingQuotation.CreateDate = Convert.ToDateTime(this.QuotationCreateDate);
            this.AvbobPendingQuotation.CoverAmount = Convert.ToString(GetMaximumQuotationAmount());
            this.AvbobPendingQuotation.QuotationValidDays = Convert.ToInt32(this.ValidQuotationDays);
            this.AvbobPendingQuotation.QuotationCreateDate = DateTime.Now.ToString("D", CultureInfo.InvariantCulture);
            this.AvbobPendingQuotation.QuotationExpiryDate = DateTime.Now.AddDays(Convert.ToDouble(this.ValidQuotationDays)).ToString("D", CultureInfo.InvariantCulture);
            this.AvbobPendingQuotation.MonthlyPremiumDescription = this.MonthlyPremiumDescription;
            this.AvbobPendingQuotation.MonthlyAdminFeeDescription = this.MonthlyAdminFeeDescription;
            this.AvbobPendingQuotation.JoiningFeeDescription = this.OnceOffJoiningFeeDescription;
            this.AvbobPendingQuotation.JoiningFeeMessage = this.JoiningFeeMessage;
            this.TemplatesDirectory = @"Templates\";
            this.DocumentOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NATTEX\NAMS\Quotations\" +
                DateTime.Now.ToString("yyyy-MM-dd") + @"\" + this.AvbobPendingQuotation.QuotationNumber + @"\";
            if (!Directory.Exists(this.DocumentOutputDirectory))
            {
                Directory.CreateDirectory(this.DocumentOutputDirectory);
            }

            UpdateSpinningWheelProperties(false, false);

            this.SavePendingQuotation();
        }

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
            //this.SpinningWheelRadius = 50;
            //this.SpinningDotRadius = 3;
            //this.SpinningDotSpeed = 2;
            //this.SpinningDotCount = 20;
            //this.IsSymmetricalArranged = true;
            //this.SpinningDotColor = new SolidColorBrush(Color.FromRgb(255, 140, 0));
        }

        private void PopulateQuotationFees()
        {
            if (this.AvbobQuotationPolicySummary != null)
            {
                this.AvbobPendingQuotation.MonthlyPremium = this.AvbobQuotationPolicySummary.TotalCompanyMemberPremium;
            }
            this.AvbobPendingQuotation.NumberOfProspectiveMembers = Convert.ToString(GetNumberOfProspectiveMembers());
            this.AvbobPendingQuotation.NumOfMonthlyInstallments = GetJoiningFeeNumOfMonthlyInstallments();
            this.AvbobPendingQuotation.AdminFee = Math.Round(GetAdminFee(), 2);
            this.AvbobPendingQuotation.JoiningFee = Math.Round(GetTotalJoiningFee(GetNumberOfPolicies()), 2);
            this.AvbobPendingQuotation.JoiningFeePerMember = Math.Round(GetJoiningFeePerMember(), 2);
    
            if (this.AvbobPendingQuotation.NumOfMonthlyInstallments > 0)
            {
                this.AvbobPendingQuotation.InstallmentJoiningFee = Math.Round(GetTotalJoiningFee(GetNumberOfPolicies()) / this.AvbobPendingQuotation.NumOfMonthlyInstallments, 2);
            }
            this.AvbobPendingQuotation.QuotationValue = Math.Round(this.AvbobPendingQuotation.MonthlyPremium + GetAdminFee() + GetTotalJoiningFee(GetNumberOfPolicies()), 2);
            this.SavePendingQuotation();
        }



        private void PopulateReplacementPatterns()
        {
            if (this.ReplacementPatterns == null)
            {
                this.ReplacementPatterns = new Dictionary<string, string>();
            }
            this.ReplacementPatterns.Add("<QuotationHeader>", this.AvbobPendingQuotation.QuotationHeader);
            this.ReplacementPatterns.Add("<CustomerNumber>", this.AvbobPendingQuotation.CustomerNumber);
            this.ReplacementPatterns.Add("<CustomerName>", this.AvbobPendingQuotation.CustomerName);
            this.ReplacementPatterns.Add("<CustomerAddress>", this.AvbobPendingQuotation.CustomerAddress);

            this.ReplacementPatterns.Add("<CustomerContactNumber>", this.AvbobPendingQuotation.CustomerContactNumber);
            this.ReplacementPatterns.Add("<CustomerEmailAddress>", this.AvbobPendingQuotation.CustomerEmailAddress);

            this.ReplacementPatterns.Add("<QuotationNo>", this.AvbobPendingQuotation.QuotationNumber);

            this.ReplacementPatterns.Add("<QuotationCreateDate>", this.AvbobPendingQuotation.QuotationCreateDate);
            this.ReplacementPatterns.Add("<QuotationExpiryDate>", this.AvbobPendingQuotation.QuotationExpiryDate);
            this.ReplacementPatterns.Add("<QuotationPreparedBy>", this.AvbobPendingQuotation.QuotationPreparedBy);
            this.ReplacementPatterns.Add("<QuotationValidDays>", Convert.ToString(this.AvbobPendingQuotation.QuotationValidDays));
            this.ReplacementPatterns.Add("<MonthlyPremiumDescription>", this.AvbobPendingQuotation.MonthlyPremiumDescription);

            this.ReplacementPatterns.Add("<MonthlyPremiumCost>", "R " + Convert.ToString(this.AvbobPendingQuotation.MonthlyPremium));
            this.ReplacementPatterns.Add("<MonthlyAdminFeeDescription>", Convert.ToString(this.AvbobPendingQuotation.MonthlyAdminFeeDescription));
            this.ReplacementPatterns.Add("<MonthlyAdminFeeCost>", "R " + Convert.ToString(this.AvbobPendingQuotation.AdminFee));

            this.ReplacementPatterns.Add("<OnceOffJoiningFeeDescription>", this.AvbobPendingQuotation.JoiningFeeDescription);
            this.ReplacementPatterns.Add("<OnceOffJoiningFeeCost>", "R " + Convert.ToString(this.AvbobPendingQuotation.JoiningFee));

            this.ReplacementPatterns.Add("<NumMonthlyInstallments>", Convert.ToString(this.AvbobPendingQuotation.NumOfMonthlyInstallments));
            this.ReplacementPatterns.Add("<MonthlyInstallment>", "R " + Convert.ToString(this.AvbobPendingQuotation.InstallmentJoiningFee));
            this.ReplacementPatterns.Add("<TotalQuotationValue>", "R " + Convert.ToString(this.AvbobPendingQuotation.QuotationValue));
        }

        private string GetQuotationDocumentResourceName()
        {
            string result = string.Empty;
            result = "SSS.NATTEX.Resources.Templates.NATTEX_QuotationTemplate_AVBOB.docx";
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
            result = this.AvbobPendingQuotation.QuotationNumber + "_" + this.QuotationPrintDateTime + ".docx";
            return result;
        }

        private string GenerateOutputXPSDocumentName()
        {
            string result = string.Empty;
            result = this.AvbobPendingQuotation.QuotationNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xps";
            return result;
        }

        private void GenerateMSWordDocument()
        {
            Assembly _assembly  = Assembly.GetExecutingAssembly();
            string resourceName = GetQuotationDocumentResourceName();
            Stream docStream =  _assembly.GetManifestResourceStream(resourceName);
            this.IsValidInput = true;
            if (this.AvbobPendingQuotation != null)
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
                        document.AddCoreProperty("dc:title", "Quotation document - " + this.AvbobPendingQuotation.QuotationNumber + "docx");
                        document.AddCoreProperty("dc:subject", "Quotation document");
                        document.AddCoreProperty("dc:creator", "NAMS");


                        var searchValueList = document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase);
                        if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count == this.ReplacementPatterns.Count)
                        {
                            for (int i = 0; i < searchValueList.Count; ++i)
                            {
                                document.ReplaceText(searchValueList[i], GetReplacementValue(searchValueList[i]), false, RegexOptions.IgnoreCase);
                            }

                            try
                            {
                                this.QuotationWordDocumentFilePath = this.DocumentOutputDirectory + GenerateOutputWordDocumentName();
                                this.QuotationXPSDocumentFilePath = this.DocumentOutputDirectory + GenerateOutputXPSDocumentName();
                                this.QuotationPrintDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                document.SaveAs(this.QuotationWordDocumentFilePath);
                                this.QuotationXPSDocument = ConvertWordDocumentToXPSDocument(this.QuotationWordDocumentFilePath, this.QuotationXPSDocumentFilePath);
                                this.QuotationModel.QuotationXPSDocument = this.QuotationXPSDocument;
                                this.AvbobPendingQuotation.QuotationDocumentPath = this.QuotationWordDocumentFilePath;
                                this.AvbobPendingQuotation.QuotationXPSDocumentPath = this.QuotationXPSDocumentFilePath;
                                this.AvbobPendingQuotation.QuotationType = "Policy Book";
                                this.SavePendingQuotation();
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

        private XpsDocument ConvertWordDocumentToXPSDocument(string wordDocName, string xpsDocName)
        {
            Process[] oldWordProcesses = Process.GetProcessesByName("WINWORD");
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);
            Document doc = wordApplication.ActiveDocument;
            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApplication.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApplication);
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
                    while (Marshal.ReleaseComObject(wordApplication) > 0) ;
                    wordApplication = null;
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    Process[] newWordProcesses = Process.GetProcessesByName("WINWORD");
                    KillWordProcess(oldWordProcesses, newWordProcesses);
                }
            }
            return null;
        }

        private void KillWordProcess(Process[] oldWordProcesses, Process[] newWordProcesses)
        {
            foreach (Process newWordrocess in newWordProcesses)
            {
                int exist = 0;
                foreach (Process oldWordProcess in oldWordProcesses)
                {
                    if (newWordrocess.Id == oldWordProcess.Id)
                    {
                        exist++;
                    }
                }
                if (exist == 0)
                {
                    newWordrocess.Kill();
                }
            }
        }


        private string GetReplacementValue(string searchValue)
        {
            if (this.ReplacementPatterns.ContainsKey(searchValue))
            {
                return this.ReplacementPatterns[searchValue];
            }
            return searchValue;
        }

        private decimal GetTotalJoiningFee(int totalMembers)
        {
            decimal result = Math.Round(GetJoiningFeePerMember() * totalMembers, 2); ;
            return result;
        }

        private void ConfirmAction(System.Windows.Window window)
        {
            try
            {
                UpdateSpinningWheelProperties(true, true);
                SavePendingQuotation();
                GenerateMSWordDocument();
                QuotationDocumentViewerWindow viewer = new QuotationDocumentViewerWindow(this.QuotationModel, this.CurrentLogin);
                viewer.Owner = System.Windows.Application.Current.MainWindow;
                viewer.ShowActivated = true;
                viewer.ShowInTaskbar = true;
                viewer.Width = (0.90 * viewer.Owner.Width);
                viewer.WindowState = WindowState.Normal;
                viewer.BringIntoView();
                UpdateSpinningWheelProperties(false, false);
                this.CurrentWindow.Close();
                viewer.Show();
            }
            catch
            {
                UpdateSpinningWheelProperties(false, false);
            }
            finally
            {
                UpdateSpinningWheelProperties(false, false);
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
                string message = "Are you sure you want to cancel this quotation?";
                string caption = "Cancel Pending Quotation";
                MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    SaveCancelledPendingQuotation();
                    win.Close();
                }
            }
        }

        #region database operations
        private void PopulatePendingQuotationSummary()
        {
            using (var context = new NattexApplicationContext())
            {
                AvbobPendingQuotationPolicySummary summary = context.AvbobPendingQuotationPolicySummaries.Where(x => x.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID).FirstOrDefault<AvbobPendingQuotationPolicySummary>();
                if (summary != null)
                {
                    this.AvbobQuotationPolicySummary = summary;
                }
            }
        }

        private void PopulateAvbobPendingQuotation(int avbobPendingQuotationID)
        {
            using (var context = new NattexApplicationContext())
            {
                AvbobPendingQuotation quotation = context.AvbobPendingQuotations.Where(x => x.AvbobPendingQuotationID == avbobPendingQuotationID).FirstOrDefault<AvbobPendingQuotation>();
                if (quotation != null)
                {
                    this.AvbobPendingQuotation = quotation;
                }
            }
        }

        private void SavePendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                var entity = context.AvbobPendingQuotations.Find(this.AvbobPendingQuotation.AvbobPendingQuotationID);
                this.AvbobPendingQuotation.IsConfirmed = true;
                if (entity != null)
                {
                    context.Entry(entity).CurrentValues.SetValues(this.AvbobPendingQuotation);
                    context.SaveChanges();
                }
            };
        }

        private void SaveCancelledPendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                AvbobPendingQuotation quotation = context.AvbobPendingQuotations.Where(x => x.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID).FirstOrDefault<AvbobPendingQuotation>();
                if (quotation != null)
                {
                    quotation.IsCancelled = true;
                    var entity = context.AvbobPendingQuotations.Find(this.AvbobPendingQuotation.AvbobPendingQuotationID);
                    context.Entry(entity).CurrentValues.SetValues(quotation);
                    context.SaveChanges();
                }
            };
        }

        private int GetQuotationValidDays()
        {
            int result = 30;
            using (var context = new NattexApplicationContext())
            {
                var expiration = context.LibertyPendingQuotationParameters.Where(x => x.IsActive == true).FirstOrDefault();
                if (expiration != null)
                {
                    result = expiration.QuotationValidDays;
                }
            }
            return result;
        }

        private int GetJoiningFeeNumOfMonthlyInstallments()
        {
            int result = 3;
            return result;
        }

        private decimal GetAdminFee()
        {
            decimal result = Math.Round(150m, 2); ;
            using (var context = new NattexApplicationContext())
            {
                var expiration = context.AdminFees.Where(x => x.IsActive == true).FirstOrDefault();
                if (expiration != null)
                {
                    result = Math.Round(expiration.Fee);
                }
            }
            return result;
        }

        private decimal GetJoiningFeePerMember()
        {
            decimal result = Math.Round(50m, 2); ;
            using (var context = new NattexApplicationContext())
            {
                var expiration = context.JoiningFees.Where(x => x.IsActive == true).FirstOrDefault();
                if (expiration != null)
                {
                    result = Math.Round(expiration.Fee);
                }
            }
            return result;
        }

        private decimal GetMaximumQuotationAmount()
        {
            decimal result = Math.Round(0m, 2); ;
            using (var context = new NattexApplicationContext())
            {
                List<decimal> amounts = new List<decimal>();
                var covers = context.AvbobPendingQuotationPolicyMembers.Where(x => x.IsActive == true && x.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID).Select(x => x.CoverAmount).ToList();
                foreach(string c in covers)
                {
                    if (c != null)
                    {
                        amounts.Add(Convert.ToDecimal(c));
                    }
                }
                decimal cover = amounts.Max();
                result = Math.Round(cover, 2);
            }
            return result;
        }

        private int GetNumberOfProspectiveMembers()
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                int count = context.AvbobPendingQuotationPolicyMembers.Where(x => x.IsActive == true && x.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID).Count();
                result = count;
            }
            return result;
        }

        private int GetNumberOfPolicies()
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                int count = context.AvbobPendingQuotationPolicies.Where(x => x.IsActive == true && x.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID).Count();
                result = count;
            }
            return result;
        }



        #endregion

        #endregion
    }
}
