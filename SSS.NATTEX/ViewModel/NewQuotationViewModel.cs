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
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.ViewModel
{
    public class NewQuotationViewModel : MainViewModel
    {

        private string _controlCaption;
        private string _selectedQuotationType;
        private string _ValidationMessage;
        private bool   _isValidInput;
        private Visibility _validationMessageVisibility;

        private ObservableCollection<string> _quotationTypes;

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
                Validate();
            }
        }

        public ObservableCollection<string>  QuotationTypes
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


        public string ValidationMessage
        {
            get
            {
                return _ValidationMessage;
            }
            set
            {
                _ValidationMessage = value;
                this.RaisePropertyChanged("ValidationMessage");
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

        public DockingSetupModel LayoutModel { get; set; }

        public RelayCommand<Window> ProceedCommand { get; set; }
        public RelayCommand<Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public NewQuotationViewModel(DockingSetupModel layoutModel)
        { 
            this.LayoutModel = layoutModel;
            this.ControlCaption = "SELECT QUOTATION TYPE";
            this.QuotationTypes = new ObservableCollection<string>();
            this.QuotationTypes.Add(string.Empty);
            this.QuotationTypes.Add("Society Scheme Quotation");
            this.QuotationTypes.Add("Single Member Quotation");
            this.ValidationMessage = "";
            this.ValidationMessageVisibility = Visibility.Collapsed;
            WireUpEvents();
        }
        #endregion


        #region methods

        private void Validate()
        {
            this.IsValidInput = true;
            if (string.IsNullOrEmpty(this.SelectedQuotationType))
            {
                this.ValidationMessage = "Please select a quoatation type.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
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
            ProceedCommand = new RelayCommand<Window>(ProceedAction);
            CancelCommand = new RelayCommand<Window>(CancelAction);
        }

        private void ProceedAction(Window window)
        {
            Window win = (Window)window;
            
            if (win != null)
            {
                Validate();
                if (IsValidInput)
                {
                    this.LayoutModel.DocumentPane.Children.Remove(this.LayoutModel.Document);
                    this.LayoutModel.Document = new LayoutDocument()
                    {
                     ContentId = "QM-002",
                        IsActive = true,
                        Title = "2. DATA CAPTURING",
                        CanClose = false,
                        CanFloat = true,
                        IsMaximized = false,
                        IconSource = new BitmapImage(new Uri(@"../../Resources/Images/quote_4_24.png", UriKind.Relative))
                    };
                    this.LayoutModel.Document.Content = new CaptureMemberMinDetailsUserControl(this.LayoutModel);
                    this.LayoutModel.DocumentPane.Children.Add(this.LayoutModel.Document);
                    this.LayoutModel.Document.PreviousContainerIndex = this.LayoutModel.DocumentPane.Children.IndexOf(this.LayoutModel.Document);
                    this.LayoutModel.Document.Parent = this.LayoutModel.DocumentPane;
                    this.LayoutModel.Document.DockAsDocument();
                }
            }
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
        #endregion
    }
}
