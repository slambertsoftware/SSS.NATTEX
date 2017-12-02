using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SSS.NATTEX.ViewModel
{
    public class NavigationPaneViewModel : MainViewModel
    {
        #region fields
        private ObservableCollection<LibertyPendingQuotation> _pendindingQuotations;
        private Visibility _navigationPaneVisibility;


        #endregion

        #region properties
        public ConfirmedQuotation ConfirmedQuotation { get; set; }
        public ObservableCollection<LibertyPendingQuotation> PendingQuotations
        {
            get
            {
                return _pendindingQuotations;
            }
            set
            {
                _pendindingQuotations = value;
                this.RaisePropertyChanged("PendingQuotations");
            }
        }
        public Visibility NavigationPaneVisibility
        {
            get
            {
                return _navigationPaneVisibility;
            }
            set
            {
                _navigationPaneVisibility = value;
                this.RaisePropertyChanged("NavigationPaneVisibility");
            }
        }
        #endregion

        #region constructors
        public NavigationPaneViewModel()
        {
            if (this.PendingQuotations == null)
            {
                this.PendingQuotations = new ObservableCollection<LibertyPendingQuotation>();
                this.PopulatePendingQuotations();
            }
        }

        public NavigationPaneViewModel(ConfirmedQuotation confirmation)
        {
            this.UpdatePendingQuotations(confirmation);
        }
        #endregion

        #region methods
        private void WireUpEvents()
        {

        }

        public void UpdatePendingQuotations(ConfirmedQuotation confirmation)
        {
            this.ConfirmedQuotation = confirmation;

            if (this.ConfirmedQuotation != null)
            {
                if (this.PendingQuotations == null)
                {
                    this.PendingQuotations = new ObservableCollection<LibertyPendingQuotation>();
                }
                this.PendingQuotations.Add(confirmation.PendingQuotation);
            }
        }

        public void PopulatePendingQuotations()
        {
            using (var context = new NattexApplicationContext())
            {
                var quotations = context.LibertyPendingQuotations.Where(x => x.IsActive == true);
                if (quotations != null)
                {
                    this.PendingQuotations = new ObservableCollection<LibertyPendingQuotation>(quotations);
                }
            }
        }



        public void ShowPendingQuotationDetailWindow(LibertyPendingQuotation pendingQuotation)
        {
            if (pendingQuotation != null)
            {
                QuotationDetailWindow viewer = new QuotationDetailWindow(pendingQuotation);
                viewer.Owner = System.Windows.Application.Current.MainWindow;
                viewer.ShowActivated = true;
                viewer.ShowInTaskbar = true;
                viewer.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                //viewer.Width = (0.90 * viewer.Owner.Width);
                viewer.WindowState = WindowState.Normal;
                viewer.BringIntoView();
                viewer.Show();
                viewer.SizeToContent = SizeToContent.Width;
            }

        }
        #endregion
    }
}
