using GalaSoft.MvvmLight.Messaging;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace SSS.NATTEX.ViewModel
{
    public class QuotationDocumentViewerViewModel: MainViewModel
    {

        #region fields
        private string _quotationTabHeader;
        private CurrentLogin _currentLogin;
        private LibertyNewQuotation _quotationModel;
        private LibertyPendingQuotation _libertyPendingQuotation;
        private FixedDocumentSequence _quotationXPSDocument;
        #endregion

        #region properties
        public QuotationDocumentViewerWindow CurrentWindow { get; set; }

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
                return _libertyPendingQuotation;
            }
            set
            {
                _libertyPendingQuotation = value;
                this.RaisePropertyChanged("LibertyPendingQuotation");
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
        #endregion

        #region constructors
        public QuotationDocumentViewerViewModel(System.Windows.Window window, LibertyNewQuotation  quotationModel, CurrentLogin currentLogin)
        {
            this.QuotationModel = quotationModel;
            this.PopulatePendingQuotation();
            this.CurrentLogin = currentLogin;
            System.Windows.Window win = (System.Windows.Window)window;

            if (win != null)
            {
                this.CurrentWindow = (QuotationDocumentViewerWindow)win;
            }
            if (this.QuotationModel != null)
            {
                this.QuotationTabHeader = this.QuotationModel.QuotationNumber;
                this.QuotationXPSDocument = this.QuotationModel.QuotationXPSDocument.GetFixedDocumentSequence();
                if (this.QuotationModel.QuotationDocuments != null)
                {

                }
            }

            ConfirmedQuotation confirmation = new ConfirmedQuotation()
            {
                PendingQuotation = this.PendingQuotation
            };
            Messenger.Default.Send<ConfirmedQuotation>(confirmation);
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

        #endregion


    }
}
