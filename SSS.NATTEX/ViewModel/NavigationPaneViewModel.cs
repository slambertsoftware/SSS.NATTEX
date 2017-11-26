using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SSS.NATTEX.ViewModel
{
    public class NavigationPaneViewModel : MainViewModel
    {
        #region fields
        private ObservableCollection<LibertyPendingQuotation> _pendindingQuotations;
        

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
        public RelayCommand ViewPendingQuotationCommand { get; set; }
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
            ViewPendingQuotationCommand = new RelayCommand(ViewPendingQuotationAction);

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

        private void ViewPendingQuotationAction()
        {
          //var dobj = obj;
        //    QuotationDocumentViewerWindow viewer = new QuotationDocumentViewerWindow(this.QuotationModel, this.CurrentLogin);
        //    viewer.Owner = System.Windows.Application.Current.MainWindow;
        //    viewer.ShowActivated = true;
        //    viewer.ShowInTaskbar = true;
        //    viewer.Width = (0.80 * viewer.Owner.Width);
        //    viewer.WindowState = WindowState.Normal;
        //    viewer.BringIntoView();

        //    this.IsBusyStatus = false;
        //    this.IsBusyVisibility = Visibility.Collapsed;
        //    this.CurrentWindow.Close();
        //    viewer.Show();
        }
        #endregion
    }
}
