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
        private AvbobQuotationModel _avbobQuotationModel;
        private LibertyPendingQuotation _libertyPendingQuotation;
        private AvbobPendingQuotation _avbobPendingQuotation;
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

        public AvbobQuotationModel AvbobQuotationModel
        {
            get
            {
                return _avbobQuotationModel;
            }
            set
            {
                _avbobQuotationModel = value;
                this.RaisePropertyChanged("AvbobQuotationModel");
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
            this.PopulateLibertyPendingQuotation();
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
                    this.CurrentWindow.LoadDocuments(this.QuotationModel.QuotationDocuments);
                }
            }

            ConfirmedQuotation confirmation = new ConfirmedQuotation()
            {
                PendingQuotation = this.PendingQuotation
            };
            Messenger.Default.Send<ConfirmedQuotation>(confirmation);
        }

        public QuotationDocumentViewerViewModel(System.Windows.Window window, AvbobQuotationModel quotationModel, CurrentLogin currentLogin)
        {
            this.AvbobQuotationModel = quotationModel;
            this.PopulateAvbobPendingQuotation();
            this.CurrentLogin = currentLogin;
            System.Windows.Window win = (System.Windows.Window)window;

            if (win != null)
            {
                this.CurrentWindow = (QuotationDocumentViewerWindow)win;
            }
            if (this.AvbobQuotationModel != null)
            {
                this.QuotationTabHeader = this.AvbobPendingQuotation.QuotationNumber;
                if ((this.AvbobQuotationModel != null) && (this.AvbobQuotationModel.QuotationXPSDocument != null))
                {
                    this.QuotationXPSDocument = this.AvbobQuotationModel.QuotationXPSDocument.GetFixedDocumentSequence();
                }
            }

            ConfirmedQuotation confirmation = new ConfirmedQuotation()
            {
                AvbobPendingQuotation = this.AvbobPendingQuotation
            };
            Messenger.Default.Send<ConfirmedQuotation>(confirmation);
        }
        #endregion

        #region methods
        private void PopulateLibertyPendingQuotation()
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

        private void PopulateAvbobPendingQuotation()
        {
            using (var context = new NattexApplicationContext())
            {
                AvbobPendingQuotation quotation = context.AvbobPendingQuotations.Where(x => x.AvbobPendingQuotationID == this.AvbobQuotationModel.QuotationID).FirstOrDefault<AvbobPendingQuotation>();
                if (quotation != null)
                {
                    this.AvbobPendingQuotation = quotation;
                }
            }
        }
        #endregion


    }
}
