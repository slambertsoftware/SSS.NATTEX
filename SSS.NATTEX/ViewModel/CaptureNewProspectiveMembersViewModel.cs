﻿using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.ViewModel
{
    public class CaptureNewProspectiveMembersViewModel : MainViewModel
    {
        private string _controlCaption;
        private string _selectedQuotationType;
        private int _numOfMembers;
        private int _numOfMembersRemaining;
        private int _numberOfMembersCaptured;
        private string _selectedCoverAmount;
        private string _selectedMemberCoverAmount;
        private string _selectedCentury;
        private string _calculatedAge;
        private string _premium;
        private string _scheme;
        private string _quotationHeading;
        private string _quotationNumberHeading;

        private ObservableCollection<string> _quotationTypes;
        private ObservableCollection<string> _policyCovers;
        private ObservableCollection<string> _memberPolicyCovers;
        private ObservableCollection<string> _centuries;
        private ObservableCollection<ProspectiveMember> _capturedProspectiveMembers;
        private ObservableCollection<string> _schemeGroupedMembers;

        private bool _isApplyCoverAmountChecked;
        private bool _isBirthYearEnabled;
        private bool _isBirthMonthEnabled;
        private bool _isBirthDayEnabled;
        private bool _isValidIDNumber;
        private bool _idNumberLengthValidation;
        private bool _idMonthValidation;
        private bool _idDayValidation;
        private bool _isValidBirthYear;
        private bool _isValidBirthMonth;
        private bool _isValidBirthDay;
        private bool _isValidBirthDate;
        private bool _isValidInput;
        private bool _isDuplicateProspectiveMember;
        private bool _isProceedEnabled;

        private string _idNumber;
        private string _validationMessage;
        private string _birthYear;
        private string _birthMonth;
        private string _birthDay;
        private LibertyNewQuotation _quotationModel;
        private LibertyPendingQuotation _pendingQuotation;
        private CurrentLogin _currentLogin;

        private NewProspectiveMembersUserControl _membersUserControl;
        private NewProspectiveMemberSchemeUserControl _membersSchemeUserControl;

        

        private Visibility _validationMessageVisibility;
        private Visibility _centuriesVisibility;
        private Visibility _schemeVisibility;
        private Visibility _premiumVisibility;
        private Visibility _proceedVisibility;

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

        public int NumberOfMembers
        {
            get
            {
                return _numOfMembers;
            }
            set
            {
                _numOfMembers = value;
                this.RaisePropertyChanged("NumberOfMembers");
            }
        }

        public int RemainingNumberOfMembers
        {
            get
            {
                return _numOfMembersRemaining;
            }
            set
            {
                _numOfMembersRemaining = value;
                this.RaisePropertyChanged("RemainingNumberOfMembers");
            }
        }

        public int NumberOfMembersCaptured
        {
            get
            {
                return _numberOfMembersCaptured;
            }
            set
            {
                _numberOfMembersCaptured = value;
                this.RaisePropertyChanged("NumberOfMembersCaptured");
            }
        }

        public string SelectedCoverAmount
        {
            get
            {
                return _selectedCoverAmount;
            }
            set
            {
                _selectedCoverAmount = value;
                this.RaisePropertyChanged("SelectedCoverAmount");
                this.SelectedMemberCoverAmount = _selectedCoverAmount;
            }
        }

        public string SelectedMemberCoverAmount
        {
            get
            {
                return _selectedMemberCoverAmount;
            }
            set
            {
                _selectedMemberCoverAmount = value;
                this.RaisePropertyChanged("SelectedMemberCoverAmount");
            }
        }

        public bool IsApplyCoverAmountChecked
        {
            get
            {
                return _isApplyCoverAmountChecked;
            }
            set
            {
                _isApplyCoverAmountChecked = value;
                this.RaisePropertyChanged("IsApplyCoverAmountChecked");
            }
        }

        public bool IsValidIDNumber
        {
            get
            {
                return _isValidIDNumber;
            }
            set
            {
                _isValidIDNumber = value;
                this.RaisePropertyChanged("IsValidIDNumber");
            }
        }

        public string IDNumber
        {
            get
            {
                return _idNumber;
            }
            set
            {
                _idNumber = value;
                this.RaisePropertyChanged("IDNumber");
            }
        }

        public string SelectedCentury
        {
            get
            {
                return _selectedCentury;
            }
            set
            {
                _selectedCentury = value;
                this.RaisePropertyChanged("SelectedCentury");
                if (!string.IsNullOrWhiteSpace(this.BirthYear) && (this.BirthYear.Length == 4))
                {
                    this.BirthYear = _selectedCentury + this.BirthYear.Substring(2, 2);
                }
            }

        }

        public ObservableCollection<string> PolicyCovers
        {
            get
            {
                return _policyCovers;
            }
            set
            {
                _policyCovers = value;
                this.RaisePropertyChanged("PolicyCovers");
            }
        }

        public ObservableCollection<string> MemberPolicyCovers
        {
            get
            {
                return _memberPolicyCovers;
            }
            set
            {
                _memberPolicyCovers = value;
                this.RaisePropertyChanged("MemberPolicyCovers");
            }
        }

        public ObservableCollection<string> Centuries
        {
            get
            {
                return _centuries;
            }
            set
            {
                _centuries = value;
                this.RaisePropertyChanged("Centuries");
            }
        }

        public bool IsBirthYearEnabled
        {
            get
            {
                return _isBirthYearEnabled;
            }
            set
            {
                _isBirthYearEnabled = value;
                this.RaisePropertyChanged("IsBirthYearEnabled");
            }
        }

        public bool IsBirthMonthEnabled
        {
            get
            {
                return _isBirthMonthEnabled;
            }
            set
            {
                _isBirthMonthEnabled = value;
                this.RaisePropertyChanged("IsBirthMonthEnabled");
            }
        }

        public bool IsBirthDayEnabled
        {
            get
            {
                return _isBirthDayEnabled;
            }
            set
            {
                _isBirthDayEnabled = value;
                this.RaisePropertyChanged("IsBirthDayEnabled");
            }
        }

        public bool IsValidBirthYear
        {
            get
            {
                return _isValidBirthYear;
            }
            set
            {
                _isValidBirthYear = value;
                this.RaisePropertyChanged("IsValidBirthYear");
            }
        }

        public bool IsValidBirthMonth
        {
            get
            {
                return _isValidBirthMonth;
            }
            set
            {
                _isValidBirthMonth = value;
                this.RaisePropertyChanged("IsValidBirthMonth");
            }
        }

        public bool IsValidBirthDay
        {
            get
            {
                return _isValidBirthDay;
            }
            set
            {
                _isValidBirthDay = value;
                this.RaisePropertyChanged("IsValidBirthDay");
            }
        }

        public bool IsValidBirthDate
        {
            get
            {
                return _isValidBirthDate;
            }
            set
            {
                _isValidBirthDate = value;
                this.RaisePropertyChanged("IsValidBirthDate");
            }
        }

        public bool IsDuplicateProspectiveMember
        {
            get
            {
                return _isDuplicateProspectiveMember;
            }
            set
            {
                _isDuplicateProspectiveMember = value;
                this.RaisePropertyChanged("IsDuplicateProspectiveMember");
            }
        }

        public bool IDNumberLengthValidation
        {
            get
            {
                return _idNumberLengthValidation;
            }
            set
            {
                _idNumberLengthValidation = value;
                this.RaisePropertyChanged("IDNumberLengthValidation");
            }
        }

        public bool IDNumberMonthValidation
        {
            get
            {
                return _idMonthValidation;
            }
            set
            {
                _idMonthValidation = value;
                this.RaisePropertyChanged("IDNumberMonthValidation");
            }
        }

        public bool IDNumberDayValidation
        {
            get
            {
                return _idDayValidation;
            }
            set
            {
                _idDayValidation = value;
                this.RaisePropertyChanged("IDNumberDayValidation");
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

        public string BirthYear
        {
            get
            {
                return _birthYear;
            }
            set
            {
                _birthYear = value;
                this.RaisePropertyChanged("BirthYear");
            }
        }

        public string BirthMonth
        {
            get
            {
                return _birthMonth;
            }
            set
            {
                _birthMonth = value;
                this.RaisePropertyChanged("BirthMonth");
            }
        }

        public string BirthDay
        {
            get
            {
                return _birthDay;
            }
            set
            {
                _birthDay = value;
                this.RaisePropertyChanged("BirthDay");
            }
        }

        public string CalculatedAge
        {
            get
            {
                return _calculatedAge;
            }
            set
            {
                _calculatedAge = value;
                this.RaisePropertyChanged("CalculatedAge");
            }
        }

        public string Premium
        {
            get
            {
                return _premium;
            }
            set
            {
                _premium = value;
                this.RaisePropertyChanged("Premium");
            }
        }

        public string Schemes
        {
            get
            {
                return _scheme;
            }
            set
            {
                _scheme = value;
                this.RaisePropertyChanged("Schemes");
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

        public string QuotationNumberHeading
        {
            get
            {
                return _quotationNumberHeading;
            }
            set
            {
                _quotationNumberHeading = value;
                this.RaisePropertyChanged("QuotationNumberHeading");
            }
        }

        public ObservableCollection<ProspectiveMember> CapturedProspectiveMembers
        {
            get
            {
                return _capturedProspectiveMembers;
            }
            set
            {
                _capturedProspectiveMembers = value;
                this.RaisePropertyChanged("CapturedProspectiveMembers");
            }
        }

        public ObservableCollection<string> SchemeGroupedMembers
        {
            get
            {
                return _schemeGroupedMembers;
            }
            set
            {
                _schemeGroupedMembers = value;
                this.RaisePropertyChanged("SchemeGroupedMembers");
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

        public Visibility CenturiesVisibility
        {
            get
            {
                return _centuriesVisibility;
            }
            set
            {
                _centuriesVisibility = value;
                this.RaisePropertyChanged("CenturiesVisibility");
            }
        }

        public Visibility SchemeVisibility
        {
            get
            {
                return _schemeVisibility;
            }
            set
            {
                _schemeVisibility = value;
                this.RaisePropertyChanged("SchemeVisibility");
            }
        }

        public Visibility PremiumVisibility
        {
            get
            {
                return _premiumVisibility;
            }
            set
            {
                _premiumVisibility = value;
                this.RaisePropertyChanged("SchemeVisibility");
            }
        }

        public LibertyNewQuotation QuotationModel
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

        public NewProspectiveMembersUserControl MembersUserControl
        {
            get
            {
                return _membersUserControl;
            }
            set
            {
                _membersUserControl = value;
                this.RaisePropertyChanged("MembersUserControl");
            }
        }

        public NewProspectiveMemberSchemeUserControl MembersSchemeUserControl
        {
            get
            {
                return _membersSchemeUserControl;
            }
            set
            {
                _membersSchemeUserControl = value;
                this.RaisePropertyChanged("MembersSchemeUserControl");
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

        public bool IsProceedEnabled
        {
            get
            {
                return _isProceedEnabled;
            }
            set
            {
                _isProceedEnabled = value;
                this.RaisePropertyChanged("IsProceedEnabled");
            }
        }

        public DockingSetupModel LayoutModel { get; set; }
        public RelayCommand<Window> SaveCommand { get; set; }
        public RelayCommand<Window> ResetCommand { get; set; }
        public RelayCommand<Window> ProceedCommand { get; set; }
        public RelayCommand<Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public CaptureNewProspectiveMembersViewModel(DockingSetupModel layoutModel, LibertyNewQuotation quotationModel, CurrentLogin currentLogin)
        {
            this.LayoutModel = layoutModel;
            this.QuotationModel = quotationModel;
            this.CurrentLogin = currentLogin;
            this.PopulatePendingQuotation();
            this.QuotationHeading = "Quotation Type: " + this.QuotationModel.QuotationType;
            this.QuotationNumberHeading = "Quotation No: " + this.QuotationModel.QuotationNumber;
            this.PendingQuotation.QuotationHeader = this.QuotationHeading;

            this.ControlCaption = "Capture Prospective Member Minumum Required Details";
            this.SelectedQuotationType = this.PendingQuotation.QuotationType;
            PopulatePolicyCovers();
            PopulateMemberPolicyCovers();
            PopulateCenturies();

            this.SelectedCentury = "19";
            this.CenturiesVisibility = Visibility.Collapsed;
            this.CapturedProspectiveMembers = new ObservableCollection<ProspectiveMember>();
            this.SchemeGroupedMembers = new ObservableCollection<string>();

            this.NumberOfMembers = 1;
            this.NumberOfMembersCaptured = 0;
            this.RemainingNumberOfMembers = this.NumberOfMembers - this.NumberOfMembersCaptured;
            this.SelectedCoverAmount = "R 3000.00";
            this.SelectedMemberCoverAmount = "R 3000.00";
            this.IsApplyCoverAmountChecked = true;
            this.IsBirthYearEnabled = true;
            this.IsBirthMonthEnabled = true;
            this.IsBirthDayEnabled = true;

            this.ValidationMessage = "";
            this.ValidationMessageVisibility = Visibility.Collapsed;
            this.ValidationMessage = "";
            this.IsProceedEnabled = false;
            this.ProceedVisibility = Visibility.Collapsed;

            WireUpEvents();
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

        private void Validate()
        {
            this.IsValidInput = true;
            ValidateIDNumber();
            ValidateBirthDate();
 
            if ((!IsValidIDNumber) && (this.RemainingNumberOfMembers > 0))
            {
                this.ValidationMessage = "Invalid ID Number.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if ((!IsValidBirthDate) && (this.RemainingNumberOfMembers > 0))
            {
                this.ValidationMessage = "Invalid Birth Date.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if ((IsDuplicateProspectiveMember) && (this.RemainingNumberOfMembers > 0))
            {
                this.ValidationMessage = "Duplicate Prospective Member.";
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

        private void ShowValidationMessage(string message)
        {
            MessageBox.Show(message, this.ControlCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        private void ShowValidationDialog(string message)
        {
            MessageBox.Show(message, this.ControlCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void WireUpEvents()
        {
            SaveCommand = new RelayCommand<Window>(SaveAction);
            ResetCommand = new RelayCommand<Window>(ResetAction);
            ProceedCommand = new RelayCommand<Window>(ProceedAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
        }

        private void Reset()
        {
            this.IDNumber = "";
            this.BirthYear = "";
            this.BirthMonth = "";
            this.BirthDay = "";
            this.CalculatedAge = "";
            this.Premium = "";
            this.Schemes = "";
        }

        private void ResetAction(Window window)
        {
            Window win = (Window)window;

            if (win != null)
            {
                Reset();
            }
        }


        private void PopulatePolicyCovers()
        {
            if (this.PolicyCovers == null)
            {
                this.PolicyCovers = new ObservableCollection<string>();
            }

            using (var context = new NattexApplicationContext())
            {
                var covers = context.LibertyPolicyCovers.ToList();
                if ((covers != null) && (covers.Count > 0))
                {
                    foreach(LibertyPolicyCover cover in covers)
                    {
                        this.PolicyCovers.Add("R " + Convert.ToString(cover.Amount));
                    }
                }
            }
        }

        private void PopulateMemberPolicyCovers()
        {
            if (this.MemberPolicyCovers == null)
            {
                this.MemberPolicyCovers = new ObservableCollection<string>();
            }

            using (var context = new NattexApplicationContext())
            {
                var covers = context.LibertyPolicyCovers.ToList();
                if ((covers != null) && (covers.Count > 0))
                {
                    foreach (LibertyPolicyCover cover in covers)
                    {
                        this.MemberPolicyCovers.Add("R " + Convert.ToString(cover.Amount));
                    }
                }
            }
        }

        private void PopulateCenturies() {
            if (this.Centuries == null)
            {
                this.Centuries = new ObservableCollection<string>();
            }

            using (var context = new NattexApplicationContext())
            {
                var centuries = context.Centuries.ToList();
                if ((centuries != null) && (centuries.Count > 0))
                {
                    foreach (Century century in centuries)
                    {
                        this.Centuries.Add(century.Year);
                    }
                }
            }
        }


        public List<string> GetSchemes()
        {
            List<string> result = new List<string>();
            result.Add("19");
            result.Add("20");
            return result;
        }


        public void UpdateBirthDateDetails()
        {
            if (string.IsNullOrWhiteSpace(this.SelectedCentury)) {
                this.SelectedCentury = "19";
            }

            ValidateIDNumber();
            if (this.IsValidIDNumber) {
                this.BirthYear  = this.SelectedCentury + GetYearofBirthFromSAIDNumber(this.IDNumber);
                this.BirthMonth = GetMonthofBirthFromSAIDNumber(this.IDNumber);
                this.BirthDay   = GetDayofBirthFromSAIDNumber(this.IDNumber);
                this.IsBirthYearEnabled = true;
                this.IsBirthMonthEnabled = true;
                this.IsBirthDayEnabled = true;
                this.CalculatedAge = Convert.ToString(GetCalculatedAge(new DateTime(Convert.ToInt32(this.BirthYear), Convert.ToInt32(this.BirthMonth), Convert.ToInt32(this.BirthDay))));
            }
            else if ((!this.IsValidIDNumber) && (string.IsNullOrEmpty(this.IDNumber)))
            {
                this.IsBirthYearEnabled = true;
                this.IsBirthMonthEnabled = true;
                this.IsBirthDayEnabled = true;
            }
        }


        private int GetCalculatedAge(DateTime dateOfBirth)
        {
            int result = 0;

            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            result = age;

            return result;
        }

        public void UpdateCentury()
        {
            if ((this.BirthYear.Length == 4) &&  (this.BirthYear.StartsWith("19")))
            {
                this.SelectedCentury = "19";
            }
            if ((this.BirthYear.Length == 4) && (this.BirthYear.StartsWith("20")))
            {
                this.SelectedCentury = "20";
            }
        }

        public void UpdateRemainingMembers()
        {
            this.RemainingNumberOfMembers = this.NumberOfMembers - this.NumberOfMembersCaptured;
            //UpdateProcceedValidation();
        }


        public void UpdateProcceedValidation()
        {
            if ((this.RemainingNumberOfMembers > 0) || (this.IsValidInput == false))
            {
                this.IsProceedEnabled = false;
                this.ProceedVisibility = Visibility.Collapsed;
            }

            if ((this.RemainingNumberOfMembers == 0) && (this.IsValidInput == true))
            {
                this.IsProceedEnabled = true;
                this.ProceedVisibility = Visibility.Visible;
            }
        }

        public void ValidateIDNumber()
        {
            if (string.IsNullOrEmpty(this.IDNumber))
            {
                this.IsValidIDNumber = false;
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
                this.CenturiesVisibility = Visibility.Collapsed;
                this.IsBirthYearEnabled = true;
                this.IsBirthMonthEnabled = true;
                this.IsBirthDayEnabled = true;
            }
            else if (this.IsValidSAIDNumber(this.IDNumber))
            {
                this.IsValidIDNumber = true;
                this.CenturiesVisibility = Visibility.Visible;
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
            else
            {
                this.IsValidIDNumber = false;
                this.CenturiesVisibility = Visibility.Collapsed;
                if (!this.IDNumberLengthValidation)
                {
                    this.ValidationMessage = "Invalid SA ID Number. Length (13) validation failed.";
                }
                else if (!this.IDNumberMonthValidation)
                {
                    this.ValidationMessage = "Invalid SA ID Number. Month validation failed.";
                }
                else if (!this.IDNumberDayValidation)
                {
                    this.ValidationMessage = "Invalid SA ID Number. Day validation failed.";
                }
                else
                {
                    this.ValidationMessage = "Invalid SA ID Number.";
                }
                this.ValidationMessageVisibility = Visibility.Visible;
            }
        }

        public void ValidateBirthDay()
        {
            this.IsValidBirthDay = true;
            if (!string.IsNullOrEmpty(this.BirthDay))
            {
                while (this.BirthDay.StartsWith("0"))
                {
                    this.BirthDay = this.BirthDay.Remove(0, 1);
                }
            }

            if (string.IsNullOrWhiteSpace(this.BirthDay))
            {
                this.IsValidBirthDay = false;
                this.ValidationMessage = "Invalid day of birth. One to two digits (1-31) required.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthDay)) && (Convert.ToInt32(this.BirthDay) == 0))
            {
                this.IsValidBirthDay = false;
                this.ValidationMessage = "Invalid day of birth. Valid days (1-31) required.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }

            else if ((!string.IsNullOrWhiteSpace(this.BirthDay)) && (Convert.ToInt32(this.BirthDay) > 31))
            {
                this.IsValidBirthDay = false;
                this.ValidationMessage = "Invalid day of birth. Valid days (1-31) required.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthYear)) && (!string.IsNullOrWhiteSpace(this.BirthMonth)) && (!string.IsNullOrWhiteSpace(this.BirthDay)) && 
                (Convert.ToInt32(this.BirthYear) == DateTime.Today.Year) && (Convert.ToInt32(this.BirthMonth) == DateTime.Today.Month) && (Convert.ToInt32(this.BirthDay) > DateTime.Today.Day))
            {
                this.IsValidBirthDay = false;
                this.ValidationMessage = "Invalid day of birth. The day of birth cannot be in the future.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthDay)) && (!string.IsNullOrWhiteSpace(this.IDNumber)) && (this.IDNumber.Length >= 6) && (this.BirthDay.Length == 1) &&
                (this.IDNumber.Substring(4, 2) != "0" + Convert.ToString(this.BirthDay).Substring(0, 1)))
            {
                this.IsValidBirthYear = false;
                this.ValidationMessage = "The day of birth does not match the day value of the ID number.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }

            else if ((!string.IsNullOrWhiteSpace(this.BirthDay)) && (!string.IsNullOrWhiteSpace(this.IDNumber)) && (this.IDNumber.Length >= 6) && (this.BirthDay.Length == 2) &&
                (this.IDNumber.Substring(4, 2) != Convert.ToString(this.BirthDay).Substring(0, 2)))
            {
                this.IsValidBirthYear = false;
                this.ValidationMessage = "The day of birth does not match the day value of the ID number.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else
            {
                this.IsValidBirthDay = true;
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
        }

        public void ValidateBirthMonth()
        {
            this.IsValidBirthMonth = true;
            if (!string.IsNullOrEmpty(this.BirthMonth))
            {
                while (this.BirthMonth.StartsWith("0"))
                {
                    this.BirthMonth = this.BirthMonth.Remove(0, 1);
                }
            }

            if (string.IsNullOrWhiteSpace(this.BirthMonth))
            {
                this.IsValidBirthMonth = false;
                this.ValidationMessage = "Invalid month of birth. One to two digits (1-12) required (MM)";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthMonth)) && (Convert.ToInt32(this.BirthMonth) > 12))
            {
                this.IsValidBirthMonth = false;
                this.ValidationMessage = "Invalid month of birth. Valid months (1-12) required.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthYear)) && (!string.IsNullOrWhiteSpace(this.BirthMonth)) && (Convert.ToInt32(this.BirthYear) == DateTime.Today.Year) && (Convert.ToInt32(this.BirthMonth) > DateTime.Today.Month))
            {
                this.IsValidBirthMonth = false;
                this.ValidationMessage = "Invalid month of birth. The month of birth cannot be in the future.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthMonth)) && (!string.IsNullOrWhiteSpace(this.IDNumber)) && (this.IDNumber.Length >= 4) && (this.BirthMonth.Length == 1) &&    
                     (this.IDNumber.Substring(2, 2) != "0" + Convert.ToString(this.BirthMonth).Substring(0, 1)))
                {
                this.IsValidBirthMonth = false;
                this.ValidationMessage = "The month of birth does not match the month value of the ID number.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthMonth)) && (!string.IsNullOrWhiteSpace(this.IDNumber)) && (this.IDNumber.Length >= 4) && (this.BirthMonth.Length == 2) &&
            (this.IDNumber.Substring(2, 2) != Convert.ToString(this.BirthMonth).Substring(0, 2)))
            {
                this.IsValidBirthMonth = false;
                this.ValidationMessage = "The month of birth does not match the month value of the ID number.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else
            {
                this.IsValidBirthMonth = true;
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
        }

        public void ValidateBirthYear()
        {
            this.IsValidBirthYear = true;
            if (!string.IsNullOrEmpty(this.BirthYear))
            {
                while (this.BirthYear.StartsWith("0"))
                {
                    this.BirthYear = this.BirthYear.Remove(0, 1);
                }
            }

            if (string.IsNullOrWhiteSpace(this.BirthYear))
            {
                this.IsValidBirthYear = false;
                this.ValidationMessage = "Invalid year of birth. Four (4) digits required (YYYY).";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthYear)) && (this.BirthYear.Length < 4))
            {
                this.IsValidBirthYear = false;
                this.ValidationMessage = "Invalid year of birth. Four (4) digits required (YYYY).";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthYear)) && (Convert.ToInt32(this.BirthYear) > DateTime.Today.Year + 1))
            {
                this.IsValidBirthYear = false;
                this.ValidationMessage = "Invalid year of birth. The year of birth cannot be in the future.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else if ((!string.IsNullOrWhiteSpace(this.BirthYear)) && (!string.IsNullOrWhiteSpace(this.IDNumber)) && (this.IDNumber.Length >= 2) && (this.BirthYear.Length == 4) &&
                     (this.IDNumber.Substring(0, 2) != Convert.ToString(this.BirthYear).Substring(2, 2)))
            {
                this.IsValidBirthYear = false;
                this.ValidationMessage = "The year of birth does not match the year value of the ID number.";
                this.ValidationMessageVisibility = Visibility.Visible;
            }
            else
            {
                this.IsValidBirthYear = true;
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
        }

        private void ValidateBirthDate()
        {
            ValidateBirthYear();
            ValidateBirthMonth();
            ValidateBirthDay();
            if ((this.IsValidBirthYear) && (this.IsValidBirthMonth) && (this.IsValidBirthDay))
            {
                this.IsValidBirthDate = true;
                if (this.IsValidIDNumber)
                {
                    this.ValidationMessage = "";
                    this.ValidationMessageVisibility = Visibility.Collapsed;
                }
            }
            else
            {
                this.IsValidBirthDate = false;
                if (this.IsValidIDNumber)
                {
                    this.ValidationMessageVisibility = Visibility.Visible;
                }
            }
        }

        private bool IsValidSAIDNumber(string idNumber)
        {
            bool result = true;
            this.IDNumberLengthValidation = true;
            this.IDNumberMonthValidation = true;
            this.IDNumberDayValidation = true;
            bool yearValidation = true;

            if (string.IsNullOrWhiteSpace(idNumber) || (this.IDNumber.Length == 0) || idNumber.Length != 13)
            {
                this.IDNumberLengthValidation = false;
            }

            if ((this.IDNumber.Length >= 4) && (Convert.ToInt32(idNumber.Substring(2, 2)) > 12))
            {
                this.IDNumberMonthValidation = false;
            }

            if ((this.IDNumber.Length >= 6) && (Convert.ToInt32(idNumber.Substring(4, 2)) > 31))
            {
                this.IDNumberDayValidation = false;
            }

            if ((this.IDNumberLengthValidation) && (yearValidation) && (this.IDNumberMonthValidation) && (this.IDNumberDayValidation))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private string GetYearofBirthFromSAIDNumber(string idNumber)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(idNumber) && idNumber.Length > 6) {
                result = idNumber.Substring(0, 2);
            }
            return result;
        }

        private string GetMonthofBirthFromSAIDNumber(string idNumber)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(idNumber) && idNumber.Length > 6)
            {
                result = idNumber.Substring(2, 2);
            }
            return result;
        }

        private string GetDayofBirthFromSAIDNumber(string idNumber)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(idNumber) && idNumber.Length > 6)
            {
                result = idNumber.Substring(4, 2);
            }
            return result;
        }

        private List<string> GetvalidBirthYears()
        {
            List<string> result = new List<string>();
            for(int i=1900; i <= DateTime.Now.Year; i++)
            {
                result.Add(Convert.ToString(i));
            }
            return result;
        }

        private List<string> GetvalidBirthMonths()
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                result.Add(Convert.ToString(i));
            }
            return result;
        }

        private List<string> GetvalidBirthDays()
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= 31; i++)
            {
                result.Add(Convert.ToString(i));
            }
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
                    this.QuotationModel.ProspectiveMembers = this.MembersUserControl.GetCapturedProspectiveMembers();
                    this.QuotationModel.NumberOfProspectiveMembers = Convert.ToString((this.QuotationModel.ProspectiveMembers == null) ? this.QuotationModel.ProspectiveMembers.Count : 0);
                    this.QuotationModel.ProspectiveMemberSchemes = this.MembersSchemeUserControl.GetProspectiveMemberSchemes();
                    this.QuotationModel.IsCoverAmountAppliedToAll = this.IsApplyCoverAmountChecked;
                    this.QuotationModel.CoverAmount = this.SelectedCoverAmount;

                    SavePendingQuotation();
                    SaveProcessedProspectiveMemberSchemes();

                    this.LayoutModel.DocumentPane.Children.Remove(this.LayoutModel.Document);
                    if (this.LayoutModel.LeftAnchorablePane.Children.Count > 0 )
                    {
                        this.LayoutModel.LeftAnchorablePane.Children[0].Hide(true);
                    }
                    if (this.LayoutModel.RightAnchorablePane.Children.Count > 0)
                    {
                        this.LayoutModel.RightAnchorablePane.Children[0].Hide(true);
                    }
                    this.LayoutModel.Document = new LayoutDocument()
                    {
                        ContentId = "QM-003",
                        IsActive = true,
                        Title = "3. QUOTATION",
                        CanClose = false,
                        CanFloat = true,
                        IsMaximized = false,
                        IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_4_24.png", UriKind.Relative))
                    };
                    this.LayoutModel.Document.Content = new LibertyPendingQuotationConfirmationUserControl(this.LayoutModel, this.QuotationModel, this.CurrentLogin);
                    this.LayoutModel.DocumentPane.Children.Add(this.LayoutModel.Document);
                    this.LayoutModel.Document.PreviousContainerIndex = this.LayoutModel.DocumentPane.Children.IndexOf(this.LayoutModel.Document);
                    this.LayoutModel.Document.Parent = this.LayoutModel.DocumentPane;
                    this.LayoutModel.Document.DockAsDocument();
                }
            }
        }

        private void SavePendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                LibertyPendingQuotation quotation = context.LibertyPendingQuotations.Where(x => x.LibertyPendingQuotationID == this.QuotationModel.QuotationID).FirstOrDefault<LibertyPendingQuotation>();
                if (quotation != null)
                {
                    quotation.NumberOfProspectiveMembers = Convert.ToString(this.NumberOfMembers);
                    quotation.IsCoverAmountAppliedToAll = this.QuotationModel.IsCoverAmountAppliedToAll;
                    quotation.CoverAmount  = this.QuotationModel.CoverAmount;
                    var entity = context.LibertyPendingQuotations.Find(this.QuotationModel.QuotationID);
                    context.Entry(entity).CurrentValues.SetValues(quotation);
                    context.SaveChanges();
                }
            };
        }

        private void SaveProspectiveMember(ProspectiveMember member)
        {
            LibertyPendingQuotationMember quotationMember = new LibertyPendingQuotationMember()
            {
                LibertyPendingQuotationID = this.PendingQuotation.LibertyPendingQuotationID,
                Initial   = member.Initial,
                FirstName = member.FirstName,
                LastName  = member.LastName,
                IDNumber = member.IDNumber,
                Age = member.Age,
                Premium = member.Premium,
                Scheme = member.Scheme,
                CoverAmount = member.CoverAmount,
                IsMemberSelected = member.IsMemberSelected,
                CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                CreateUserID = this.CurrentLogin.UserID,
                IsActive = member.IsMemberSelected ? true : false,
            };

                using (var context = new NattexApplicationContext())
                {
                    context.LibertyPendingQuotationMembers.Add(quotationMember);
                    context.SaveChanges();
                }
        }

        public void SaveProcessedProspectiveMemberSchemes()
        {
            if ((this.QuotationModel.ProspectiveMemberSchemes != null) && (this.QuotationModel.ProspectiveMemberSchemes.Count > 0))
            {
                foreach (ProspectiveMemberScheme scheme in this.QuotationModel.ProspectiveMemberSchemes)
                {
                    int schemeID = SaveQuotationMemberScheme(scheme.SchemeName);
                    foreach (ProspectiveMemberGroup memberGroup in scheme.ProspectiveMemberGroups)
                    {
                        int memberGroupID = SaveQuotationMemberGroup(schemeID, memberGroup.GroupSchemeName, memberGroup.GroupName, memberGroup.GroupCoverAmount);
                        if ((memberGroup.ProspectiveMembers != null) && (memberGroup.ProspectiveMembers.Count > 0))
                        {
                            SaveQuotationMemberGroupMembers(memberGroupID, memberGroup.ProspectiveMembers);
                        }
                    }
                }
            }
        }

        private int SaveQuotationMemberScheme(string schemeName)
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                LibertyPendingQuotationMemberScheme scheme = new LibertyPendingQuotationMemberScheme() { LibertyPendingQuotationID = this.QuotationModel.QuotationID, SchemeName = schemeName, IsActive = true, CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = this.CurrentLogin.UserID };
                context.LibertyPendingQuotationMemberSchemes.Add(scheme);
                context.SaveChanges();
                result = scheme.LibertyPendingQuotationMemberSchemeID;
            }
            return result;
        }

        private int SaveQuotationMemberGroup(int schemeID, string schemeName, string groupName, string coverAmount)
        {
            int result = 0;
            using (var context = new NattexApplicationContext())
            {
                LibertyPendingQuotationMemberGroup memberGroup = new LibertyPendingQuotationMemberGroup()
                {
                    PendingQuotationID = this.QuotationModel.QuotationID,
                    PendingQuotationMemberSchemeID = schemeID,
                    GroupSchemeName = schemeName,
                    GroupName = groupName,
                    GroupCoverAmount = coverAmount,
                    IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreateUserID = this.CurrentLogin.UserID
                };
                context.LibertyPendingQuotationMemberGroups.Add(memberGroup);
                context.SaveChanges();
                result = memberGroup.PendingQuotationMemberGroupID;
            }
            return result;
        }

        private void SaveQuotationMemberGroupMembers(int membergroupID, ObservableCollection<ProspectiveMember> members)
        {
            List<LibertyPendingQuotationMemberGroupMember> groupMembers = new List<LibertyPendingQuotationMemberGroupMember>();
            foreach (ProspectiveMember member in members)
            {
                LibertyPendingQuotationMemberGroupMember groupMember = new LibertyPendingQuotationMemberGroupMember()
                {
                    LibertyPendingQuotationID = this.QuotationModel.QuotationID,
                    LibertyPendingQuotationMemberGroupID = membergroupID,
                    Initial = member.Initial,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    IDNumber = member.IDNumber,
                    Age = member.Age,
                    Premium = member.Premium,
                    Scheme = member.Scheme,
                    CoverAmount = member.CoverAmount,
                    IsMemberSelected = member.IsMemberSelected,
                    IsActive = member.IsMemberSelected ? true : false,
                    CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreateUserID = this.CurrentLogin.UserID
                };
                groupMembers.Add(groupMember);
            }
            using (var context = new NattexApplicationContext())
            {
                groupMembers.ForEach(groupMember => context.LibertyPendingQuotationMemberGroupMembers.Add(groupMember));
                context.SaveChanges();
            }
        }

        private void SaveAction(Window window)
        {
            Window win = (Window)window;

            if (win != null)
            {
                ProspectiveMember member = new ProspectiveMember()
                {
                    IDNumber = this.IDNumber,
                    IsMemberSelected = true,
                    Age = Convert.ToInt32(this.CalculatedAge),
                };
                if (this.CapturedProspectiveMembers.Contains(member))
                {
                    this.IsDuplicateProspectiveMember = true;
                }
                else
                {
                    this.IsDuplicateProspectiveMember = false;
                }
                Validate();
                if (IsValidInput)
                {
                    this.CapturedProspectiveMembers.Add(member);
                    this.SaveProspectiveMember(member);

                    if (this.MembersUserControl == null)
                    {
                        this.MembersUserControl = new NewProspectiveMembersUserControl();
                    }

                    if (this.MembersSchemeUserControl == null)
                    {
                        this.MembersSchemeUserControl = new NewProspectiveMemberSchemeUserControl(this.SelectedCoverAmount, this.CurrentLogin, this.PendingQuotation.LibertyPendingQuotationID);
                    }

                    if (this.LayoutModel.RightAnchorablePane.ChildrenCount == 0)
                    {
                        this.LayoutModel.RightAnchorable = new LayoutAnchorable()
                        {
                            Title = "Prospective Members",
                            Content = this.MembersUserControl,
                            ContentId = "C2",
                            IsActive = true,
                            IsSelected = true,
                            CanAutoHide = true,
                            CanClose = false,
                            CanFloat = false,
                            CanHide = false,
                            IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_16.png", UriKind.Relative))
                        };
                        this.LayoutModel.RightAnchorablePane.Children.Add(this.LayoutModel.RightAnchorable);
                        this.LayoutModel.RightAnchorable.PreviousContainerIndex = this.LayoutModel.RightAnchorablePane.Children.IndexOf(this.LayoutModel.RightAnchorable);
                        this.LayoutModel.RightAnchorable.Parent = this.LayoutModel.RightAnchorablePane;
                        this.LayoutModel.RightAnchorable.Show();
                    }

                    if (this.RemainingNumberOfMembers > 0)
                    {
                        this.NumberOfMembersCaptured = this.CapturedProspectiveMembers.Count;
                        this.RemainingNumberOfMembers = this.NumberOfMembers - this.NumberOfMembersCaptured;
                        this.LayoutModel.LeftAnchorablePane.Parent = this.LayoutModel.DockingManager.Layout.RootPanel;
                        this.MembersUserControl.AddProspectiveMember(member);
                    }

                    if (this.RemainingNumberOfMembers == 0)
                    {
                        UpdateProcceedValidation();
                        this.ProceedVisibility = Visibility.Visible;

                        if (this.LayoutModel.LeftAnchorablePane.ChildrenCount == 0)
                        {
                            this.LayoutModel.LeftAnchorable = new LayoutAnchorable()
                            {
                                Title = "Member Scheme Groups",
                                Content = this.MembersSchemeUserControl,
                                ContentId = "C1",
                                IsActive = true,
                                IsSelected = true,
                                CanAutoHide = true,
                                CanClose = false,
                                CanFloat = false,
                                CanHide = false,
                                IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_16.png", UriKind.Relative))
                            };

                            this.LayoutModel.LeftAnchorablePane.Children.Add(this.LayoutModel.LeftAnchorable);
                            this.LayoutModel.LeftAnchorable.PreviousContainerIndex = this.LayoutModel.LeftAnchorablePane.Children.IndexOf(this.LayoutModel.LeftAnchorable);
                            this.LayoutModel.LeftAnchorable.Parent = this.LayoutModel.LeftAnchorablePane;
                            this.LayoutModel.LeftAnchorable.Show();
                        }
                        this.MembersSchemeUserControl.AddProspectiveMembers(this.CapturedProspectiveMembers.ToList());
                    }
                }
            }
        }



        private void SaveCancelledPendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                LibertyPendingQuotation quotation = context.LibertyPendingQuotations.Where(x => x.LibertyPendingQuotationID == this.QuotationModel.QuotationID).FirstOrDefault<LibertyPendingQuotation>();
                if (quotation != null)
                {
                    quotation.IsConfirmed = null;
                    quotation.IsCancelled = true;
                    var entity = context.LibertyPendingQuotations.Find(this.QuotationModel.QuotationID);
                    context.Entry(entity).CurrentValues.SetValues(quotation);
                    context.SaveChanges();
                }
            };
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
        #endregion
    }
}
