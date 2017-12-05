using GalaSoft.MvvmLight.Command;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;

namespace SSS.NATTEX.ViewModel
{
    public class QuotationDetailViewModel : MainViewModel
    {
        #region fields
        private AvbobPendingQuotation _avbobPendingQuotation { get; set; }
        private LibertyPendingQuotation _pendingQuotation { get; set; }
        private string _windowCaption;
        private string _quotationTabHeader;
        private string _quotationHeader;
        private string _libertyPendingQuotationID;
        private string _avbobPendingQuotationID;
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
        private string _documentOutputDirectory;
        private FixedDocumentSequence _quotationXPSDocument;

        private ObservableCollection<LibertyPendingQuotationMember> _pendingQuotationMembers;
        private ObservableCollection<AvbobPendingQuotationPolicyMember> _avbobPendingQuotationPolicyMembers;
        private ObservableCollection<AvbobPolicyScheduleItem> _avbobPolicyScheduleItems;
        public RelayCommand<Window> ExportScheduleCommand { get; set; }
        #endregion

        #region properties
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

        public string AvbobPendingQuotationID
        {
            get
            {
                return _avbobPendingQuotationID;
            }
            set
            {
                _avbobPendingQuotationID = value;
                this.RaisePropertyChanged("AvbobPendingQuotationID");
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

        public ObservableCollection<AvbobPendingQuotationPolicyMember> PendingQuotationPolicyMembers
        {
            get
            {
                return _avbobPendingQuotationPolicyMembers;
            }
            set
            {
                _avbobPendingQuotationPolicyMembers = value;
                this.RaisePropertyChanged("PendingQuotationPolicyMembers");
            }
        }

        public ObservableCollection<AvbobPolicyScheduleItem> AvbobPolicyScheduleItems
        {
            get
            {
                return _avbobPolicyScheduleItems;
            }
            set
            {
                _avbobPolicyScheduleItems = value;
                this.RaisePropertyChanged("AvbobPolicyScheduleItems");
            }
        }

        public bool IsValidExcelTemplate { get; set; }
        public string CurrentImportFilePath { get; set; }
        public string CurrentScheduleOutputFilePath { get; set; }

        #endregion

        #region constructors
        public QuotationDetailViewModel(System.Windows.Window window, LibertyPendingQuotation pendingQuotation)
        {
            this.WindowCaption = "Pending Quotation: " + pendingQuotation.QuotationNumber;
            this.CurrentWindow = (window as QuotationDetailWindow);
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
            if (Convert.ToBoolean(PendingQuotation.IsConfirmed))
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
                var documents = context.LibertyPendingQuotationDocuments.Where(x => x.LibertyPendingQuotationID == pendingQuotation.LibertyPendingQuotationID && x.IsActive == true).ToList<LibertyPendingQuotationDocument>();
                if ((documents != null) && (documents.Count > 0))
                {
                    this.AdditionDocumentsUploaded = "Yes";
                    (this.CurrentWindow as QuotationDetailWindow).LoadDocuments(documents);
                }
                else
                {
                    this.AdditionDocumentsUploaded = "No";
                }
            }
        }

        public QuotationDetailViewModel(System.Windows.Window window, AvbobPendingQuotation pendingQuotation)
        {
            if (window != null)
            {
                (window as QuotationDetailWindow).ChangeToAvbobImageSource();
            }
            this.WindowCaption = "Pending Quotation: " + pendingQuotation.QuotationNumber;
            this.QuotationDocumentTabHeader = pendingQuotation.QuotationNumber;
            this.CurrentWindow = (window as QuotationDetailWindow);
            this.AvbobPendingQuotation = pendingQuotation;

            this.QuotationTabHeader = pendingQuotation.QuotationNumber;
            this.QuotationHeader = pendingQuotation.QuotationHeader;
            this.AvbobPendingQuotationID = Convert.ToString(pendingQuotation.AvbobPendingQuotationID);
            this.QuotationNumber = pendingQuotation.QuotationNumber;
            this.IsExistingCustomer = pendingQuotation.IsExistingCustomer ? "Yes" : "No";
            this.CustomerAddress = pendingQuotation.CustomerAddress;
            this.CustomerEmailAddress = pendingQuotation.CustomerEmailAddress;
            this.CustomerContactNumber = pendingQuotation.CustomerContactNumber;
            this.CustomerOtherInfo = pendingQuotation.CustomerOtherInfo;
            this.PricingModel = pendingQuotation.PricingModel;
            this.QuotationPreparedBy = pendingQuotation.QuotationPreparedBy;
            this.NumberOfProspectiveMembers = pendingQuotation.NumberOfProspectiveMembers;
            this.CoverAmount = pendingQuotation.CoverAmount;
            this.IsCoverAmountAppliedToAll = pendingQuotation.IsCoverAmountAppliedToAll ? "Yes" : "No";
            if (Convert.ToBoolean(pendingQuotation.IsConfirmed))
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

            this.QuotationValue = Convert.ToString(pendingQuotation.QuotationValue);
            this.QuotationCreateDate = pendingQuotation.QuotationCreateDate;
            this.QuotationExpiryDate = pendingQuotation.QuotationExpiryDate;

            if ((pendingQuotation.QuotationXPSDocumentPath 
                != null) && File.Exists(pendingQuotation.QuotationXPSDocumentPath))
            {
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
                List<AvbobPendingQuotationPolicyMember> members = context.AvbobPendingQuotationPolicyMembers.Where(x => x.AvbobPendingQuotationID == pendingQuotation.AvbobPendingQuotationID && x.IsActive == true).ToList<AvbobPendingQuotationPolicyMember>();
                if (members != null)
                {
                    this.PendingQuotationPolicyMembers = new ObservableCollection<AvbobPendingQuotationPolicyMember>(members);
                }
                var documents = context.AvbobPendingQuotationDocuments.Where(x => x.AvbobPendingQuotationID == pendingQuotation.AvbobPendingQuotationID && x.IsActive == true).ToList<AvbobPendingQuotationDocument>();
                if ((documents != null) && (documents.Count > 0))
                {
                    this.AdditionDocumentsUploaded = "Yes";
                    (this.CurrentWindow as QuotationDetailWindow).LoadDocuments(documents);
                }
                else
                {
                    this.AdditionDocumentsUploaded = "No";
                }
            }

            using (var context = new NattexApplicationContext())
            {
                var counter = 0;
                List<AvbobPolicyScheduleItem> scheduleItems = (from policy in context.AvbobPendingQuotationPolicies
                                     join member in context.AvbobPendingQuotationPolicyMembers on policy.AvbobPendingQuotationPolicyID equals member.AvbobPendingQuotationPolicyID
                                     where ((policy.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID)
                                            && (member.AvbobPendingQuotationID == this.AvbobPendingQuotation.AvbobPendingQuotationID)
                                            && (policy.IsActive == true)
                                            && (member.IsActive == true))
                                     select new AvbobPolicyScheduleItem()
                                     {
                                         LineNumber = counter + 1,
                                         PolicyNumber = policy.PolicyNumber,
                                         Initial = member.Initial,
                                         FirstName = member.FirstName,
                                         LastName = member.LastName,
                                         IDNumber = member.IDNumber,
                                         CoverAmount = member.CoverAmount
                                     }).ToList< AvbobPolicyScheduleItem>();
                this.AvbobPolicyScheduleItems = new ObservableCollection<AvbobPolicyScheduleItem>(scheduleItems);
            }
           this.WireUpEvents();
        }
        #endregion

        #region methods

        private void WireUpEvents()
        {
            ExportScheduleCommand = new RelayCommand<Window>(ExportScheduleAction);
        }


        public void ExportScheduleAction(Window window)
        {
            Stream imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SSS.NATTEX.Resources.Images.nattex_logo2.png");

            this.DocumentOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NATTEX\NAMS\Schedules\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\" + this.QuotationNumber + @"\";
            if ((this.AvbobPolicyScheduleItems != null) && (this.AvbobPolicyScheduleItems.Count > 0))
            {
                if (!Directory.Exists(this.DocumentOutputDirectory))
                {
                    Directory.CreateDirectory(this.DocumentOutputDirectory);
                }
                this.CurrentScheduleOutputFilePath = this.DocumentOutputDirectory + "Schedule_" + this.QuotationNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                var fileInfo = new FileInfo(this.CurrentScheduleOutputFilePath);
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(this.AvbobPendingQuotation.CustomerName);
                    worksheet.TabColor = System.Drawing.Color.FromArgb(120, 0, 255, 0);
                    worksheet.DefaultRowHeight = 11;
                    worksheet.HeaderFooter.FirstFooter.LeftAlignedText = string.Format("Generated: {0}", DateTime.Now.ToShortDateString());
                    worksheet.Row(1).Height = 85;
                    worksheet.Row(2).Height = 18;
                    worksheet.Row(3).Height = 18;
                    Image logo = System.Drawing.Image.FromStream(imgStream);


                    var picture = worksheet.Drawings.AddPicture("Nattex Logo", logo);
                    picture.From.Column = 0;
                    picture.From.Row = 0;
                    picture.To.Column = 5;
                    picture.To.Row = 0;
                    picture.SetSize(100);
                    worksheet.Cells["F1:G1"].Merge = true;
                    worksheet.Cells["F1:G1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells["F1:G1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.Cells["F1:G1"].Style.Font.Bold = true;
                    worksheet.Cells["F1:G1"].Style.Font.Size = 18;
                    worksheet.Cells["F1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["F1:G1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells["F1:G1"].Value = this.AvbobPendingQuotation.CustomerName;

                    worksheet.Cells["A3:F4"].Merge = true;

                    worksheet.Cells["A3:F4"].Style.Font.Bold = true;
                    worksheet.Cells["A3:F4"].Style.Font.Size = 12;
                    worksheet.Cells["A3:F4"].Value = "Payable to Nattex Funeral Schemes no later than the 5th day of ever month.";
                    worksheet.Cells["A3:F4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    worksheet.Cells["A3:F4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.Cells["A3:F4"].Style.WrapText = true;
                    worksheet.Cells["A3:F4"].AutoFitColumns();

                    worksheet.Cells["G2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells["G2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.Cells["G2"].Style.Font.Bold = true;
                    worksheet.Cells["G2"].Style.Font.Size = 12;
                    worksheet.Cells["G2"].Value = DateTime.Now.ToString("MMMM") + " " + Convert.ToString(DateTime.Now.Year);


                    worksheet.Cells["G3:G4"].Merge = true;
                    worksheet.Cells["G3:G4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells["G3:G4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.Cells["G3:G4"].Style.Font.Bold = true;
                    worksheet.Cells["G3:G4"].Style.Font.Size = 13;
                    worksheet.Cells["G3:G4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["G3:G4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells["G3:G4"].Value = "R " + Convert.ToString(this.AvbobPendingQuotation.MonthlyPremium);


                    // Set some document properties
                    package.Workbook.Properties.Title = "Schedule";
                    package.Workbook.Properties.Author = "NAMS";
                    package.Workbook.Properties.Company = "Nattex Funeral Schemes";
                    package.Workbook.Properties.LastPrinted = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.View.ShowGridLines = false;

                    //Headers
                    worksheet.Cells["A7"].Value = "LINE NR";
                    worksheet.Cells["B7"].Value = "DATE";
                    worksheet.Cells["C7"].Value = "POLICY NR";
                    worksheet.Cells["D7"].Value = "SURNAME";
                    worksheet.Cells["E7"].Value = "INITIALS";
                    worksheet.Cells["F7"].Value = "ID NUMBER";
                    worksheet.Cells["G7"].Value = "COVER AMOUNT";
                    worksheet.Cells["A7:G7"].Style.Font.Bold = true;
                    worksheet.Cells["A7:G7"].Style.Font.Size = 12;
                    worksheet.Cells["A7:G7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["A7:G7"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
 
                    using (ExcelRange Rng = worksheet.Cells["A1:G1"])
                    {
                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                        Rng.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rng = worksheet.Cells["A1:G1"])
                    {
                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                        Rng.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                        Rng.Style.Numberformat.Format = "0.00";
                    }


                    using (ExcelRange Rng = worksheet.Cells["A4:G4"])
                    {
                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    }

                    int rowNumber = 8;
                    int count = 0;

                    foreach (AvbobPolicyScheduleItem member in this.AvbobPolicyScheduleItems)
                    {
                        count = count + 1;
                        worksheet.Cells[rowNumber, 1].Value = count.ToString();
                        worksheet.Cells[rowNumber, 2].Value = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                        worksheet.Cells[rowNumber, 3].Value = member.PolicyNumber.ToString();
                        worksheet.Cells[rowNumber, 4].Value = member.LastName.ToString();
                        worksheet.Cells[rowNumber, 5].Value = member.FirstName.ToString();
                        worksheet.Cells[rowNumber, 6].Value = member.IDNumber.ToString();
                        worksheet.Cells[rowNumber, 7].Value = string.IsNullOrEmpty(member.CoverAmount) ? "" : member.CoverAmount.ToString();
                        rowNumber++;
                    }


                    using (ExcelRange Rng = worksheet.Cells["A1"])
                    {
                        Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    }

                    worksheet.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Column(3).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    package.Save();
                    string message = "Schedule export completed successfully. ";
                    string caption = "Schedule Export";
                    MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }


        #endregion

    }
}
