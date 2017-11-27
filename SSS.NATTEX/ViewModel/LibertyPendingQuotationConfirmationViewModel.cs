using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.DAL;
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
    public class LibertyPendingQuotationConfirmationViewModel : MainViewModel
    {
        #region fields
        private ObservableCollection<QuotationCalculationItem> _quotationDetailResults;
        private string _libertyQuotationNumberHeader;
        private string _libertyQuotationSummaryHeader;
        private string _libertyQuotationCustomerNameHeader;
        private string _libertyQuotationHeader;
        private string _libertyQuotationCreateDate;
        private string _libertyQuotationExpiryDate;
        private string _libertyMonthlyPremiumDescription;
        private string _libertyMonthlyPremium;
        private string _libertyValidQuotationDays;
        private string _libertyMonthlyAdminFeeDescription;
        private string _libertyMonthlyAdminFee;
        private string _libertyOnceOffJoiningFeeDescription;
        private string _libertyOnceOffJoiningFee;
        private string _libertyQuotationValue;
        private string _libertyJoiningFeeMessage;
        private string _controlCaption;
        private LibertyPendingQuotation _libertyPendingQuotation { get; set; }
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

        public string LibertyQuotationNumberHeader
        {
            get
            {
                return _libertyQuotationNumberHeader;
            }
            set
            {
                _libertyQuotationNumberHeader = value;
                this.RaisePropertyChanged("LibertyQuotationNumberHeader");
            }
        }

        public string LibertyQuotationCustomerNameHeader
        {
            get
            {
                return _libertyQuotationCustomerNameHeader;
            }
            set
            {
                _libertyQuotationCustomerNameHeader = value;
                this.RaisePropertyChanged("LibertyQuotationCustomerNameHeader");
            }
        }

        public string LibertyQuotationHeader
        {
            get
            {
                return _libertyQuotationHeader;
            }
            set
            {
                _libertyQuotationHeader = value;
                this.RaisePropertyChanged("LibertyQuotationHeader");
            }
        }

        public string LibertyQuotationSummaryHeader
        {
            get
            {
                return _libertyQuotationSummaryHeader;
            }
            set
            {
                _libertyQuotationSummaryHeader = value;
                this.RaisePropertyChanged("LibertyQuotationSummaryHeader");
            }
        }

        public string LibertyQuotationCreateDate
        {
            get
            {
                return _libertyQuotationCreateDate;
            }
            set
            {
                _libertyQuotationCreateDate = value;
                this.RaisePropertyChanged("LibertyQuotationCreateDate");
            }
        }

        public string LibertyQuotationExpiryDate
        {
            get
            {
                return _libertyQuotationExpiryDate;
            }
            set
            {
                _libertyQuotationExpiryDate = value;
                this.RaisePropertyChanged("LibertyQuotationExpiryDate");
            }
        }

        public string LibertyMonthlyPremiumDescription
        {
            get
            {
                return _libertyMonthlyPremiumDescription;
            }
            set
            {
                _libertyMonthlyPremiumDescription = value;
                this.RaisePropertyChanged("LibertyMonthlyPremiumDescription");
            }
        }

        public string LibertyMonthlyPremium
        {
            get
            {
                return _libertyMonthlyPremium;
            }
            set
            {
                _libertyMonthlyPremium = value;
                this.RaisePropertyChanged("LibertyMonthlyPremium");
            }
        }

        public string LibertyValidQuotationDays
        {
            get
            {
                return _libertyValidQuotationDays;
            }
            set
            {
                _libertyValidQuotationDays = value;
                this.RaisePropertyChanged("LibertyValidQuotationDays");
            }
        }

        public string LibertyMonthlyAdminFeeDescription
        {
            get
            {
                return _libertyMonthlyAdminFeeDescription;
            }
            set
            {
                _libertyMonthlyAdminFeeDescription = value;
                this.RaisePropertyChanged("LibertyMonthlyAdminFeeDescription");
            }
        }

        public string LibertyMonthlyAdminFee
        {
            get
            {
                return _libertyMonthlyAdminFee;
            }
            set
            {
                _libertyMonthlyAdminFee = value;
                this.RaisePropertyChanged("LibertyMonthlyAdminFee");
            }
        }

        public string LibertyOnceOffJoiningFeeDescription
        {
            get
            {
                return _libertyOnceOffJoiningFeeDescription;
            }
            set
            {
                _libertyOnceOffJoiningFeeDescription = value;
                this.RaisePropertyChanged("LibertyOnceOffJoiningFeeDescription");
            }
        }

        public string LibertyOnceOffJoiningFee
        {
            get
            {
                return _libertyOnceOffJoiningFee;
            }
            set
            {
                _libertyOnceOffJoiningFee = value;
                this.RaisePropertyChanged("LibertyOnceOffJoiningFee");
            }
        }

        public string LibertyQuotationValue
        {
            get
            {
                return _libertyQuotationValue;
            }
            set
            {
                _libertyQuotationValue = value;
                this.RaisePropertyChanged("LibertyQuotationValue");
            }
        }

        public string LibertyJoiningFeeMessage
        {
            get
            {
                return _libertyJoiningFeeMessage;
            }
            set
            {
                _libertyJoiningFeeMessage = value;
                this.RaisePropertyChanged("LibertyJoiningFeeMessage");
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

        public CurrentLogin CurrentLogin { get; set; }

        public DockingSetupModel LayoutModel { get; set; }

        public LibertyPendingQuotation LibertyPendingQuotation
        {
            get
            {
                return _libertyPendingQuotation;
            }
            set
            {
                _libertyPendingQuotation = value;
                this.RaisePropertyChanged("LibertyPendingQuotation");
            }
        }

        public LibertyNewQuotation LibertyNewQuotationModel { get; set; }

        public RelayCommand<Window> ReviewCommand { get; set; }

        public RelayCommand<Window> ConfirmCommand { get; set; }

        public RelayCommand<Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public LibertyPendingQuotationConfirmationViewModel(DockingSetupModel layoutModel, LibertyNewQuotation newQuotation, CurrentLogin currentLogin)
        {
            this.LayoutModel = layoutModel;
            this.LibertyNewQuotationModel = newQuotation;
            this.CurrentLogin = currentLogin;
            this.PopulateLibertyPendingQuotation(newQuotation.QuotationID);
            this.SetupLibertyQuotationHeaders();
            this.DoLibertyQuotationDetail();
            this.DoLibertyQuotationSummary();
            this.WireUpEvents();
        }
        #endregion

        #region methods
        private void PopulateLibertyPendingQuotation(int libertyPendingQuotationID)
        {
            using (var context = new NattexApplicationContext())
            {
                LibertyPendingQuotation quotation = context.LibertyPendingQuotations.Where(x => x.LibertyPendingQuotationID == libertyPendingQuotationID).FirstOrDefault<LibertyPendingQuotation>();
                if (quotation != null)
                {
                    this.LibertyPendingQuotation = quotation;
                }
            }
        }

        private void SetupLibertyQuotationHeaders()
        {
            this.ControlCaption = "Confirm or Review Quotation Details";
            this.LibertyQuotationSummaryHeader = "QUOTATION SUMMARY";
            this.LibertyQuotationNumberHeader= "Quotation No: " + this.LibertyPendingQuotation.QuotationNumber;
            this.LibertyQuotationCustomerNameHeader = this.LibertyPendingQuotation.CustomerName + " ( for " + this.LibertyPendingQuotation.CoverAmount + " cover )";
        }

        private void DoLibertyQuotationDetail()
        {
            int totalMembers = 0;
            decimal totalPremium = 0;
            if ((this.LibertyNewQuotationModel != null) && (this.LibertyNewQuotationModel.ProspectiveMemberSchemes != null) && (this.LibertyNewQuotationModel.ProspectiveMemberSchemes.Count > 0))
            {
                if (this.QuotationDetailResults == null)
                {
                    this.QuotationDetailResults = new ObservableCollection<QuotationCalculationItem>();
                }
                this.QuotationDetailResults.Add(new QuotationCalculationItem()
                {
                    IsHeadersItem = true
                });
                foreach (ProspectiveMemberScheme scheme in this.LibertyNewQuotationModel.ProspectiveMemberSchemes)
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
                                GroupNumber = group.GroupName.Substring(6, group.GroupName.Length - 6),
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
                this.LibertyNewQuotationModel.NumberOfProspectiveMembers = Convert.ToString(totalMembers);
                this.LibertyNewQuotationModel.NumOfMonthlyInstallments = GetJoiningFeeNumOfMonthlyInstallments();
                this.LibertyNewQuotationModel.TotalMonthlyPremium = Math.Round(totalPremium, 2);
                this.LibertyNewQuotationModel.AdminFee = Math.Round(GetAdminFee(), 2);
                this.LibertyNewQuotationModel.JoiningFee = Math.Round(GetTotalJoiningFee(totalMembers), 2);
                this.LibertyNewQuotationModel.JoiningFeePerMember = Math.Round(GetJoiningFeePerMember(), 2);

                this.LibertyPendingQuotation.NumberOfProspectiveMembers = Convert.ToString(totalMembers);
                this.LibertyPendingQuotation.NumOfMonthlyInstallments = GetJoiningFeeNumOfMonthlyInstallments();
                this.LibertyPendingQuotation.MonthlyPremium = Math.Round(totalPremium, 2);
                this.LibertyPendingQuotation.AdminFee = Math.Round(GetAdminFee(), 2);
                this.LibertyPendingQuotation.JoiningFee = Math.Round(GetTotalJoiningFee(totalMembers), 2);
                this.LibertyPendingQuotation.JoiningFeePerMember = Math.Round(GetJoiningFeePerMember(), 2);


                if (this.LibertyNewQuotationModel.NumOfMonthlyInstallments > 0)
                {
                    this.LibertyNewQuotationModel.InstallmentJoiningFee = Math.Round(GetTotalJoiningFee(totalMembers) / this.LibertyNewQuotationModel.NumOfMonthlyInstallments, 2);
                    this.LibertyPendingQuotation.InstallmentJoiningFee = this.LibertyNewQuotationModel.InstallmentJoiningFee;
                }
                this.LibertyNewQuotationModel.QuotationValue = Math.Round(totalPremium + GetAdminFee() + GetTotalJoiningFee(totalMembers), 2);
                this.LibertyPendingQuotation.QuotationValue = this.LibertyNewQuotationModel.QuotationValue;

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

                this.LibertyNewQuotationModel.NumOfMonthlyInstallments = GetJoiningFeeNumOfMonthlyInstallments();
                this.LibertyPendingQuotation.NumOfMonthlyInstallments  = this.LibertyNewQuotationModel.NumOfMonthlyInstallments;
                decimal monthly = 0;
                if (this.LibertyNewQuotationModel.NumOfMonthlyInstallments > 0)
                {
                    monthly = Math.Round(GetTotalJoiningFee(totalMembers) / this.LibertyNewQuotationModel.NumOfMonthlyInstallments, 2);
                }

                var installment = new QuotationCalculationItem()
                {
                    IsMonthlyInstallmentItem = true,
                    MonthlyInstallmentDescription = "(or " + Convert.ToString(this.LibertyNewQuotationModel.NumOfMonthlyInstallments) + " monthly installments of R " + Convert.ToString(monthly) + ")"
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
                    QuotationValue = "R " + Convert.ToString(this.LibertyNewQuotationModel.QuotationValue)
                };
                this.QuotationDetailResults.Add(quotation);
                this.SavePendingQuotation();
            }

        }

        public void DoLibertyQuotationSummary()
        {
            this.LibertyQuotationHeader = "Quotation No. " + this.LibertyPendingQuotation.QuotationNumber + " for " + this.LibertyPendingQuotation.CustomerName + " at @ (" + 
                this.LibertyPendingQuotation.CoverAmount + ") cover";
            this.LibertyQuotationCreateDate = DateTime.Now.ToString("D", CultureInfo.InvariantCulture);
            this.LibertyValidQuotationDays = Convert.ToString(GetQuotationValidDays());
            this.LibertyQuotationExpiryDate = DateTime.Now.AddDays(GetQuotationValidDays()).ToString("D", CultureInfo.InvariantCulture);
            this.LibertyMonthlyPremiumDescription = this.LibertyPendingQuotation.NumberOfProspectiveMembers + " Members @ " + this.LibertyNewQuotationModel.CoverAmount + " cover each";
            this.LibertyMonthlyPremium = "R " + Convert.ToString(Math.Round(this.LibertyPendingQuotation.MonthlyPremium, 2));
            this.LibertyMonthlyAdminFeeDescription = "Monthly";
            this.LibertyMonthlyAdminFee = "R " + Convert.ToString(Math.Round(this.LibertyPendingQuotation.AdminFee));
            this.LibertyOnceOffJoiningFeeDescription = "Once off";
            this.LibertyOnceOffJoiningFee = "R " + Convert.ToString(Math.Round(this.LibertyPendingQuotation.JoiningFee));
            this.LibertyQuotationValue = "R " + Convert.ToString(Math.Round(this.LibertyPendingQuotation.QuotationValue));
            this.LibertyJoiningFeeMessage = "(The joining fee can be paid in " + Convert.ToString(this.LibertyPendingQuotation.NumOfMonthlyInstallments) + " easy installments of "
                + "R " + Convert.ToString(Math.Round(this.LibertyPendingQuotation.InstallmentJoiningFee)) + " per month)";
            this.LibertyPendingQuotation.QuotationHeader = this.LibertyQuotationHeader;
            this.LibertyPendingQuotation.CreateDate = Convert.ToDateTime(this.LibertyQuotationCreateDate);
            this.LibertyPendingQuotation.QuotationValidDays = Convert.ToInt32(this.LibertyValidQuotationDays);
            this.LibertyPendingQuotation.QuotationExpiryDate = DateTime.Now.AddDays(Convert.ToDouble(this.LibertyValidQuotationDays)).ToString("D", CultureInfo.InvariantCulture);
            this.LibertyPendingQuotation.MonthlyPremiumDescription = this.LibertyMonthlyPremiumDescription;
            this.LibertyPendingQuotation.MonthlyAdminFeeDescription = this.LibertyMonthlyAdminFeeDescription;
            this.LibertyPendingQuotation.JoiningFeeDescription = this.LibertyOnceOffJoiningFeeDescription;
            this.LibertyPendingQuotation.JoiningFeeMessage = this.LibertyJoiningFeeMessage;
            this.SavePendingQuotation();
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
            using (var context = new NattexApplicationContext())
            {
                var expiration = context.LibertyPendingQuotationParameters.Where(x => x.IsActive == true).FirstOrDefault();
                if (expiration != null)
                {
                    result = expiration.NumMonthlyJoiningFeeInstallments;
                }
            }
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

        private decimal GetTotalJoiningFee(int totalMembers)
        {
            decimal result = Math.Round(GetJoiningFeePerMember() * totalMembers, 2); ;
            return result;
        }

        private string GetMaximumAllowableCoverAmount(string groupSchemeName)
        {
            string result = string.Empty;
            using (var context = new NattexApplicationContext())
            {
                var maxCover = (from pp in context.LibertyPolicyPremiums
                              join ps in context.LibertyPolicySchemes on pp.LibertPolicySchemeID equals ps.LibertyPolicySchemeID
                              where ps.Name == groupSchemeName
                              select pp.CoverAmount).Max();
                result = maxCover.ToString();
            }
            return result;
        }

        private decimal GetGroupSchemePremiumAmount(string groupSchemeName, string groupCoverAmount)
        {
            var maxCover   = Convert.ToDecimal(GetMaximumAllowableCoverAmount(groupSchemeName));
            var groupCover = Convert.ToDecimal(groupCoverAmount.Replace("R ", "").Replace(" ", ""));
            string coverAmount = (groupCover > maxCover) ? GetMaximumAllowableCoverAmount(groupSchemeName) : groupCoverAmount;

            decimal result = 0;
            using (var context = new NattexApplicationContext())
            {
                decimal premium = (from pp in context.LibertyPolicyPremiums
                               join ps in context.LibertyPolicySchemes on pp.LibertPolicySchemeID equals ps.LibertyPolicySchemeID
                               where ps.Name == groupSchemeName && pp.CoverAmount == groupCover select pp.PremiumAmount).FirstOrDefault<decimal>();
                result = premium;
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
                    this.LayoutModel.Document.Content = new LibertyPendingQuotationDistributionUserControl(this.LayoutModel, this.LibertyNewQuotationModel, this.CurrentLogin);
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

        private void ShowValidationMessage(string message)
        {
            MessageBox.Show(message, this.ControlCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void SavePendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                var entity = context.LibertyPendingQuotations.Find(this.LibertyPendingQuotation.LibertyPendingQuotationID);
                this.LibertyPendingQuotation.IsConfirmed = true;
                if (entity != null) {
                    context.Entry(entity).CurrentValues.SetValues(this.LibertyPendingQuotation);
                    context.SaveChanges();
                }
            };
        }

        private void SaveCancelledPendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                LibertyPendingQuotation quotation = context.LibertyPendingQuotations.Where(x => x.LibertyPendingQuotationID == this.LibertyPendingQuotation.LibertyPendingQuotationID).FirstOrDefault<LibertyPendingQuotation>();
                if (quotation != null)
                {
                    quotation.IsCancelled = true;
                    var entity = context.LibertyPendingQuotations.Find(this.LibertyPendingQuotation.LibertyPendingQuotationID);
                    context.Entry(entity).CurrentValues.SetValues(quotation);
                    context.SaveChanges();
                }
            };
        }

        #endregion
    }
}
