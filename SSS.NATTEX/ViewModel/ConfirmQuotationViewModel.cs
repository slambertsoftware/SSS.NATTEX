using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        private ObservableCollection<QuotationCalculationItem> _quotationDetailResults;
        private string _quotationNumberHeading;
        private string _quotationSummaryHeading;
        private string _quotationCustomerNameHeading;
        private string _quotationHeader;
        private string _quotationCreateDate;
        private string _quotationExpiryDate;
        private string _monthlyPremiumDescription;
        private string _monthlyPremium;
        private string _monthlyAdminFeeDescription;
        private string _monthlyAdminFee;
        private string _onceJoiningFeeDescription;
        private string _onceJoiningFee;
        private string _quotationValue;
        private string _joiningFeeInstallmentMessage;
        private string _controlCaption;
        #endregion

        #region Properties
        public ObservableCollection<QuotationCalculationItem> QuotationDetailResults
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

        public string QuotationCustomerNameHeading
        {
            get
            {
                return _quotationCustomerNameHeading;
            }
            set
            {
                _quotationCustomerNameHeading = value;
                this.RaisePropertyChanged("QuotationCustomerNameHeading");
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

        public string QuotationSummaryHeading
        {
            get
            {
                return _quotationSummaryHeading;
            }
            set
            {
                _quotationSummaryHeading = value;
                this.RaisePropertyChanged("QuotationSummaryHeading");
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

        public NewQuotation QuotationModel { get; set; }

        public RelayCommand<Window> ReviewCommand { get; set; }

        public RelayCommand<Window> ConfirmCommand { get; set; }

        public RelayCommand<Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public ConfirmQuotationViewModel(DockingSetupModel layoutModel, NewQuotation quotationModel)
        {
            this.LayoutModel = layoutModel;
            this.QuotationModel = quotationModel;

            this.ControlCaption = "Confirm or Review Quotation Details";
            this.QuotationSummaryHeading = "QUOTATION SUMMARY";
            this.QuotationNumberHeading = "Quotation No: " + this.QuotationModel.QuotationNumber;
            this.QuotationCustomerNameHeading = this.QuotationModel.CustomerName + " ( for " + this.QuotationModel.CoverAmount + " cover )";
            DoQuotationDetail();
            DoQuotationSummary();
            WireUpEvents();
        }
        #endregion

        #region methods
        public void DoQuotationSummary()
        {
            this.QuotationHeader = "Quotation No. " + this.QuotationModel.QuotationNumber + " for " + this.QuotationModel.CustomerName + " at @ " + this.QuotationModel.CoverAmount + " cover";
            this.QuotationModel.QuotationHeader = this.QuotationHeader;
            this.QuotationCreateDate = DateTime.Now.ToString("D", CultureInfo.InvariantCulture);
            this.QuotationModel.QuotationCreateDate = Convert.ToString(this.QuotationCreateDate);
            this.QuotationModel.QuotatationValidDays = GetQuotationValidDays();
            this.QuotationExpiryDate = DateTime.Now.AddDays(this.QuotationModel.QuotatationValidDays).ToString("D", CultureInfo.InvariantCulture);
            this.QuotationModel.QuotationExpiryDate = Convert.ToString(this.QuotationExpiryDate);

            this.MonthlyPremiumDescription = this.QuotationModel.NumberOfProspectiveMembers + " Members @ " + this.QuotationModel.CoverAmount + " cover each";
            this.QuotationModel.MonthlyPremiumDescription = this.MonthlyPremiumDescription;
            this.MonthlyPremium = "R " +  Convert.ToString(Math.Round(this.QuotationModel.TotalMonthlyPremium, 2));
            this.QuotationModel.TotalMonthlyPremium = Math.Round(this.QuotationModel.TotalMonthlyPremium, 2);
            this.MonthlyAdminFeeDescription = "Monthly";
            this.QuotationModel.MonthlyAdminFeeDescription = this.MonthlyAdminFeeDescription;
            this.MonthlyAdminFee  = "R " + Convert.ToString(Math.Round(this.QuotationModel.AdminFee));
            this.QuotationModel.AdminFee = Math.Round(this.QuotationModel.AdminFee);
            this.OnceJoiningFeeDescription = "Once off";
            this.QuotationModel.JoiningFeeDescription = this.OnceJoiningFeeDescription;
            this.OnceJoiningFee = "R " + Convert.ToString(Math.Round(this.QuotationModel.JoiningFee));
            this.QuotationModel.JoiningFee = Math.Round(this.QuotationModel.JoiningFee);
            this.QuotationValue = "R " + Convert.ToString(Math.Round(this.QuotationModel.QuotationValue));
            this.QuotationModel.QuotationValue = Math.Round(this.QuotationModel.QuotationValue);
            this.JoiningFeeInstallmentMessage = "(The joining fee can be paid in " + Convert.ToString(this.QuotationModel.NumOfMonthlyInstallments) +  " easy installments of " 
                + "R " +  Convert.ToString(Math.Round(this.QuotationModel.MonthlyJoiningFee)) + " per month)";
        }

        private void DoQuotationDetail()
        {
            int totalMembers = 0;
            decimal totalPremium = 0;
            if ((this.QuotationModel != null) && (this.QuotationModel.ProspectiveMemberSchemes != null) && (this.QuotationModel.ProspectiveMemberSchemes.Count > 0))
            {
                if (this.QuotationDetailResults == null)
                {
                    this.QuotationDetailResults = new ObservableCollection<QuotationCalculationItem>();
                }
                this.QuotationDetailResults.Add(new QuotationCalculationItem()
                {
                    IsHeadersItem = true
                });
                foreach (ProspectiveMemberScheme scheme in this.QuotationModel.ProspectiveMemberSchemes)
                {
                    if ((scheme.ProspectiveMemberGroups != null) && (scheme.ProspectiveMemberGroups.Count > 0))
                    {
                        foreach (ProspectiveMemberGroup group in scheme.ProspectiveMemberGroups)
                        {
                            var maxCoveramount = Convert.ToDecimal((GetMaximumAllowableCoverAmount(group.GroupSchemeName).Replace("R ", "").Replace(" ", "")));
                            var groupCoverAmount = Convert.ToDecimal(group.GroupCoverAmount.Replace("R ", "").Replace(" ", ""));
                            var calculationItem = new QuotationCalculationItem()
                            {
                                IsQuotationItem = true,
                                SchemeGroup = group.GroupSchemeName,
                                GroupName = group.GroupName,
                                GroupNumber = group.GroupName.Substring(6, group.GroupName.Length-6),
                                NumOfMembers = Convert.ToString(group.ProspectiveMembers.Count),
                                CoverAmount = (groupCoverAmount > maxCoveramount) ? GetMaximumAllowableCoverAmount(group.GroupSchemeName) : group.GroupCoverAmount,
                                GroupPremiumAmount = "R " + Convert.ToString(Math.Round(GetGroupSchemePremiumAmount(scheme.SchemeName, group.GroupCoverAmount)))
                            };
                            totalMembers = totalMembers + group.ProspectiveMembers.Count;
                            totalPremium = Math.Round(totalPremium + GetGroupSchemePremiumAmount(scheme.SchemeName, group.GroupCoverAmount), 2);

                            this.QuotationDetailResults.Add(calculationItem);
                        }
                    }
                }
                this.QuotationModel.NumberOfProspectiveMembers = Convert.ToString(totalMembers);
                this.QuotationModel.NumOfMonthlyInstallments = GetJoiningFeeNumOfMonthInstallments();
                this.QuotationModel.TotalMonthlyPremium = Math.Round(totalPremium, 2);
                this.QuotationModel.AdminFee = Math.Round(GetAdminFee(), 2);
                this.QuotationModel.JoiningFee = Math.Round(GetTotalJoiningFee(totalMembers), 2);
                this.QuotationModel.JoiningFeePerMember = Math.Round(GetJoiningFeePerMember(), 2);
                if (this.QuotationModel.NumOfMonthlyInstallments > 0)
                {
                    this.QuotationModel.MonthlyJoiningFee = Math.Round(GetTotalJoiningFee(totalMembers) / this.QuotationModel.NumOfMonthlyInstallments, 2);
                }
                this.QuotationModel.QuotationValue = Math.Round(totalPremium + GetAdminFee() + GetTotalJoiningFee(totalMembers), 2);

                var totals = new QuotationCalculationItem()
                {
                    IsSubTotalItem = true,
                    TotalMembers = Convert.ToString(totalMembers),
                    TotalPremium = "R " + Convert.ToString(totalPremium)
                };
                this.QuotationDetailResults.Add(totals);

                var adminHeading = new QuotationCalculationItem()
                {
                    IsAdminHeadingItem = true,
                    AdminHeading = "Administrative Costs"
                };
                this.QuotationDetailResults.Add(adminHeading);

                var adminFee = new QuotationCalculationItem()
                {
                    IsAdminFeeItem = true,
                    AdminFee = "R " + Convert.ToString(GetAdminFee())
                };
                this.QuotationDetailResults.Add(adminFee);

                var joiningFeeHeading = new QuotationCalculationItem()
                {
                    IsJoiningFeeHeadingItem = true,
                    JoiningFeeHeading = "Joining Fee"
                };
                this.QuotationDetailResults.Add(joiningFeeHeading);

                var joiningFee = new QuotationCalculationItem()
                {
                    IsJoiningFeeItem = true,
                    JoiningFee = "R " + Convert.ToString(GetTotalJoiningFee(totalMembers))
                };

                this.QuotationDetailResults.Add(joiningFee);

                this.QuotationModel.NumOfMonthlyInstallments = GetJoiningFeeNumOfMonthInstallments();
                decimal monthly = 0;
                if (this.QuotationModel.NumOfMonthlyInstallments > 0)
                {
                    monthly = Math.Round(GetTotalJoiningFee(totalMembers) / this.QuotationModel.NumOfMonthlyInstallments, 2);
                }
                
                var installment = new QuotationCalculationItem()
                {
                    IsMonthlyInstallmentItem = true,
                    MonthlyInstallmentDescription = "(or " + Convert.ToString(this.QuotationModel.NumOfMonthlyInstallments) + " monthly installments of R " + Convert.ToString(monthly) + ")"
                };
                this.QuotationDetailResults.Add(installment);


                var quotationValueDescription = new QuotationCalculationItem()
                {
                    IsTotalQuotationValueDescriptionItem = true,
                    QuotationValue = "Total Quotation"
                };
                this.QuotationDetailResults.Add(quotationValueDescription);

                
                var quotation = new QuotationCalculationItem()
                {
                    IsTotalQuotationValueItem = true,
                    QuotationValue = "R " + Convert.ToString(this.QuotationModel.QuotationValue)
                };
                this.QuotationDetailResults.Add(quotation);
              
            }
        }

        private int GetQuotationValidDays()
        {
            int result = 30;
            return result;
        }

        private int GetJoiningFeeNumOfMonthInstallments()
        {
            int result = 3 ;
            return result;
        }

        private decimal GetAdminFee()
        {
            decimal result = Math.Round(150m, 2); ;
            return result;
        }

        private decimal GetJoiningFeePerMember()
        {
            decimal result = 50;
            return result;
        }

        private decimal GetTotalJoiningFee(int totalMembers)
        {
            decimal result = Math.Round(GetJoiningFeePerMember() * totalMembers, 2); ;
            return result;
        }

        private string GetMaximumAllowableCoverAmount(string groupSchemeName)
        {
            string result = string.Empty;

            if (groupSchemeName == @"1 + 13 Member < 65 Years")
            {
                result = "R 20 000";
            }

            else if (groupSchemeName == @"1 + 9  Member < 65 Years")
            {
                result = "R 20 000";
            }

            else if (groupSchemeName == @"1 + 5  Member < 65 Years")
            {
                result = "R 30 000";
            }

            else if (groupSchemeName == @"1 + 13 Member 65 - 70 Years")
            {
                result = "R 20 000";
            }

            else if (groupSchemeName == @"1 + 9  Member 65 - 70 Years")
            {
                result = "R 20 000";
            }

            else if (groupSchemeName == @"1 + 5  Member 65 - 70 Years")
            {
                result = "R 30 000";
            }

            else if (groupSchemeName == @"1 + 13 Member 71 - 74 Years")
            {
                result = "R 20 000";
            }

            else if (groupSchemeName == @"1 + 9  Member 71 - 74 Years")
            {
                result = "R 20 000";
            }

            else if (groupSchemeName == @"1 + 5  Member 71 - 74 Years")
            {
                result = "R 30 000";
            }

            else if (groupSchemeName == @"75 to 84 years")
            {
                result = "R 10 000";
            }

            else if (groupSchemeName == @"85 to 99 years")
            {
                result = "R 10 000";
            }

            else if (groupSchemeName == @"Older than 99 years")
            {
                result = "R 10 000";
            }

            return result;
        }

        private decimal GetGroupSchemePremiumAmount(string groupSchemeName, string groupCoverAmount)
        {
            var maxCover = Convert.ToDecimal((GetMaximumAllowableCoverAmount(groupSchemeName).Replace("R ", "").Replace(" ", "")));
            var groupCover = Convert.ToDecimal(groupCoverAmount.Replace("R ", "").Replace(" ", ""));
            string coverAmount = (groupCover > maxCover) ? GetMaximumAllowableCoverAmount(groupSchemeName) : groupCoverAmount;

            decimal result = 0;
            if (groupSchemeName == @"1 + 13 Member < 65 Years")
            {
                switch (coverAmount)
                {
                    case "R 3 000":
                        result = 70.0M;
                        break;
                    case "R 5 000":
                        result = 100.0M;
                        break;
                    case "R 7 500":
                        result = 140.0M;
                        break;
                    case "R 10 000":
                        result = 200.0M;
                        break;
                    case "R 15 000":
                        result = 260.0M;
                        break;
                    case "R 20 000":
                        result = 340.0M;
                        break;
                    default:
                        result = 340.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"1 + 9  Member < 65 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 60.0M;
                        break;
                    case "R 5 000":
                        result = 80.0M;
                        break;
                    case "R 7 500":
                        result = 110.0M;
                        break;
                    case "R 10 000":
                        result = 150.0M;
                        break;
                    case "R 15 000":
                        result = 200.0M;
                        break;
                    case "R 20 000":
                        result = 260.0M;
                        break;
                    default:
                        result = 260.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"1 + 5  Member < 65 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 50.0M;
                        break;
                    case "R 5 000":
                        result = 80.0M;
                        break;
                    case "R 7 500":
                        result = 100.0M;
                        break;
                    case "R 10 000":
                        result = 120.0M;
                        break;
                    case "R 15 000":
                        result = 160.0M;
                        break;
                    case "R 20 000":
                        result = 200.0M;
                        break;
                    case "R 25 000":
                        result = 250.0M;
                        break;
                    case "R 30 000":
                        result = 290.0M;
                        break;
                    default:
                        result = 290.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"1 + 13 Member 65 - 70 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 100.0M;
                        break;
                    case "R 5 000":
                        result = 150.0M;
                        break;
                    case "R 7 500":
                        result = 220.0M;
                        break;
                    case "R 10 000":
                        result = 320.0M;
                        break;
                    case "R 15 000":
                        result = 450.0M;
                        break;
                    case "R 20 000":
                        result = 590.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"1 + 9  Member 65 - 70 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 80.0M;
                        break;
                    case "R 5 000":
                        result = 120.0M;
                        break;
                    case "R 7 500":
                        result = 160.0M;
                        break;
                    case "R 10 000":
                        result = 320.0M;
                        break;
                    case "R 15 000":
                        result = 290.0M;
                        break;
                    case "R 20 000":
                        result = 370.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"1 + 5  Member 65 - 70 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 80.0M;
                        break;
                    case "R 5 000":
                        result = 120.0M;
                        break;
                    case "R 7 500":
                        result = 140.0M;
                        break;
                    case "R 10 000":
                        result = 190.0M;
                        break;
                    case "R 15 000":
                        result = 260.0M;
                        break;
                    case "R 20 000":
                        result = 340.0M;
                        break;
                    case "R 25 000":
                        result = 420.0M;
                        break;
                    case "R 30 000":
                        result = 500.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"1 + 13 Member 71 - 74 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 150.0M;
                        break;
                    case "R 5 000":
                        result = 230.0M;
                        break;
                    case "R 7 500":
                        result = 350.0M;
                        break;
                    case "R 10 000":
                        result = 450.0M;
                        break;
                    case "R 15 000":
                        result = 660.0M;
                        break;
                    case "R 20 000":
                        result = 870.0M;
                        break;
                    default:
                        result = 870.0M;
                        break;
                }

            }

            else if (groupSchemeName == @"1 + 9  Member 71 - 74 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 100.0M;
                        break;
                    case "R 5 000":
                        result = 150.0M;
                        break;
                    case "R 7 500":
                        result = 170.0M;
                        break;
                    case "R 10 000":
                        result = 250.0M;
                        break;
                    case "R 15 000":
                        result = 340.0M;
                        break;
                    case "R 20 000":
                        result = 450.0M;
                        break;
                    default:
                        result = 450.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"1 + 5  Member 71 - 74 Years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 150.0M;
                        break;
                    case "R 5 000":
                        result = 230.0M;
                        break;
                    case "R 7 500":
                        result = 350.0M;
                        break;
                    case "R 10 000":
                        result = 450.0M;
                        break;
                    case "R 15 000":
                        result = 660.0M;
                        break;
                    case "R 20 000":
                        result = 870.0M;
                        break;
                    default:
                        result = 870.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"75 to 84 years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 100.0M;
                        break;
                    case "R 5 000":
                        result = 170.0M;
                        break;
                    case "R 6 000":
                        result = 180.0M;
                        break;
                    case "R 8 000":
                        result = 200.0M;
                        break;
                    case "R 10 000":
                        result = 250.0M;
                        break;
                    default:
                        result = 250.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"85 to 99 years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 150.0M;
                        break;
                    case "R 5 000":
                        result = 230.0M;
                        break;
                    case "R 6 000":
                        result = 280.0M;
                        break;
                    case "R 8 000":
                        result = 320.0M;
                        break;
                    case "R 10 000":
                        result = 380.0M;
                        break;
                    default:
                        result = 380.0M;
                        break;
                }
            }

            else if (groupSchemeName == @"Older than 99 years")
            {
                switch (groupCoverAmount)
                {
                    case "R 3 000":
                        result = 150.0M;
                        break;
                    case "R 5 000":
                        result = 230.0M;
                        break;
                    case "R 6 000":
                        result = 280.0M;
                        break;
                    case "R 8 000":
                        result = 320.0M;
                        break;
                    case "R 10 000":
                        result = 380.0M;
                        break;
                    default:
                        result = 380.0M;
                        break;
                }
            }

            return result;
        }

        private void WireUpEvents()
        {
            ConfirmCommand = new RelayCommand<Window>(ConfirmAction);
            ReviewCommand = new RelayCommand<Window>(ReviewAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
        }

        private void ConfirmAction(Window window)
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
                    this.LayoutModel.Document.Content = new ExportDistributeQuotationUserControl(this.LayoutModel, this.QuotationModel);
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
