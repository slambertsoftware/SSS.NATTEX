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
    public class ConfirmQuotationViewModel : MainViewModel
    {
        #region fields
        private ObservableCollection<QuotationDetailItem> _quotationDetailResults;
        private string _quotationNumber;
        private string _quotationHeader;
        private string _quotationCreateDate;
        private string _quotationExpiryDate;
        private string _quotationCustomerName;
        private string _monthlyPremiumDescription;
        private string _monthlyPremium;
        private string _monthlyAdminFeeDescription;
        private string _monthlyAdminFee;
        private string _onceJoiningFeeDescription;
        private string _onceJoiningFee;
        private string _quotationValue;
        private string _joiningFeeInstallmentMessage;
        private string _totalAmount;
        private string _controlCaption;
        #endregion

        #region Properties
        public ObservableCollection<QuotationDetailItem> QuotationDetailResults
        {
            get
            {
                return _quotationDetailResults;
            }
            set
            {
                _quotationDetailResults = value;
                this.RaisePropertyChanged("QuotationDetailResults");
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

        public string QuotationCustomerName
        {
            get
            {
                return _quotationCustomerName;
            }
            set
            {
                _quotationCustomerName = value;
                this.RaisePropertyChanged("QuotationCustomerName");
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

        public string OnceJoiningFeeDescription
        {
            get
            {
                return _onceJoiningFeeDescription;
            }
            set
            {
                _onceJoiningFeeDescription = value;
                this.RaisePropertyChanged("OnceJoiningFeeDescription");
            }
        }

        public string OnceJoiningFee
        {
            get
            {
                return _onceJoiningFee;
            }
            set
            {
                _onceJoiningFee = value;
                this.RaisePropertyChanged("OnceJoiningFee");
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

        public string JoiningFeeInstallmentMessage
        {
            get
            {
                return _joiningFeeInstallmentMessage;
            }
            set
            {
                _joiningFeeInstallmentMessage = value;
                this.RaisePropertyChanged("JoiningFeeInstallmentMessage");
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

        public DockingSetupModel LayoutModel { get; set; }

        public RelayCommand<Window> ReviewCommand { get; set; }

        public RelayCommand<Window> AcceptCommand { get; set; }

        public RelayCommand<Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public ConfirmQuotationViewModel(DockingSetupModel layoutModel)
        {
            this.LayoutModel = layoutModel;
            this.ControlCaption = "Confirm or Review Quotation Details";
            this.QuotationNumber = "Quotation No: QUO-NAT-20171112-0001";
            this.QuotationCustomerName = "Drakensburg Funeral Society (R 10000 cover)";
            WireUpEvents();
        }
        #endregion

        #region methods
        public void LoadQuotationDetail()
        {
            if (this.QuotationDetailResults == null)
            {
                this.QuotationDetailResults = new ObservableCollection<QuotationDetailItem>();
            }
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 13 Member < 65 Years",
                NumOfGroups = Convert.ToString(22),
                NumOfMembers = Convert.ToString(306),
                CoverAmount = Convert.ToString(10000),
                TotalAmount = Convert.ToString(4400.00),
                TotalMembers = "",
                TotalPremium = ""
            });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 13 Member 65 - 70 Years", NumOfGroups = Convert.ToString(0), NumOfMembers = Convert.ToString(0) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 13 Member 71 - 74 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(0) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 9  Member < 65 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(0) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 9  Member 65 - 70 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(0) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 9  Member 71 - 74 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(0) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 5  Member < 65 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(0) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 5  Member < 65 - 70 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(306) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "1 + 5  Member < 71 - 74 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(306) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "Single Member < 75 - 84 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(306) });
            this.QuotationDetailResults.Add(new QuotationDetailItem
            { SchemeGroup = "Single Member < 85 - 99 Years", NumOfGroups = Convert.ToString(22), NumOfMembers = Convert.ToString(306) });
        }


        public void LoadGeneratedQuotation()
        {
            this.QuotationHeader = "Quotation QUOT-NAT-20172010-001 for Drakensberg Funeral Society at @R 10000 cover";
            this.QuotationCreateDate = "12 November 2017";
            this.QuotationExpiryDate = "12 December 2017";
            this.MonthlyPremiumDescription = "320 Members @ R10000.00 cover each";
            this.MonthlyPremium = "R 5700.00";
            this.MonthlyAdminFeeDescription = "Monthly";
            this.MonthlyAdminFee = "R 150.00";
            this.OnceJoiningFeeDescription = "Once off";
            this.OnceJoiningFee = "R 16000.00";
            this.QuotationValue = "R 21 850";
            this.JoiningFeeInstallmentMessage = "(The joining fee can be paid in 3 easy installments of R5333.34 per month)";
        }

        private void WireUpEvents()
        {
            AcceptCommand = new RelayCommand<Window>(AcceptAction);
            ReviewCommand = new RelayCommand<Window>(ReviewAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
        }

        private void AcceptAction(Window window)
        {
            Window win = (Window)window;

            if (win != null)
            {
                    this.LayoutModel.DocumentPane.Children.Remove(this.LayoutModel.Document);
                    this.LayoutModel.Document = new LayoutDocument()
                    {
                        ContentId = "QM-004",
                        IsActive = true,
                        Title = "4. EXPORT AND DISTRIBUTE",
                        CanClose = false,
                        CanFloat = true,
                        IsMaximized = false,
                        IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_4_24.png", UriKind.Relative))
                    };
                    this.LayoutModel.Document.Content = new ExportDistributeQuotationUserControl(this.LayoutModel);
                    this.LayoutModel.DocumentPane.Children.Add(this.LayoutModel.Document);
                    this.LayoutModel.Document.PreviousContainerIndex = this.LayoutModel.DocumentPane.Children.IndexOf(this.LayoutModel.Document);
                    this.LayoutModel.Document.Parent = this.LayoutModel.DocumentPane;
                    this.LayoutModel.Document.DockAsDocument();
            }
        }

        private void Validate()
        {

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

        private string GetGeneratedQuotationNumber()
        {
            string result = string.Empty;
            return result;
        }

        private string GetGeneratedQuotationHeaing()
        {
            string result = string.Empty;
            return result;
        }

        private string GetQuotationCustomerName()
        {
            string result = string.Empty;
            return result;
        }

        private string GetJoiningFee()
        {
            string result = string.Empty;
            return result;
        }
        #endregion
    }
}
