using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
    }
}
