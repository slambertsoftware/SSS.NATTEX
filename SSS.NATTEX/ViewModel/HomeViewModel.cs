using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SSS.NATTEX.Models;
using SSS.NATTEX.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SSS.NATTEX.ViewModel
{
    public class HomeViewModel : MainViewModel
    {
        #region fields
        private string _userName;
        private string _password;
        private string _validationMessage;
        private bool _isValidInput;

        private Visibility _validationMessageVisibility;
        private Visibility _loginButtonVisibility;
        private Visibility _logoutButtonVisibility;
        #endregion

        #region properties
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                this.RaisePropertyChanged("Password");
            }
        }

        public bool IsValidInput
        {
            get
            {
                return _isValidInput;
            }
            set
            {
                _isValidInput = value;
                this.RaisePropertyChanged("IsValidInput");
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

        public Visibility LogoutButtonVisibility
        {
            get
            {
                return _logoutButtonVisibility;
            }
            set
            {
                _logoutButtonVisibility = value;
                this.RaisePropertyChanged("LogoutButtonVisibility");
            }
        }

        public Visibility LoginButtonVisibility
        {
            get
            {
                return _loginButtonVisibility;
            }
            set
            {
                _loginButtonVisibility = value;
                this.RaisePropertyChanged("LoginButtonVisibility");
            }
        }

        public MainWindow MainWindow { get; set; }

        public CurrentLogin CurrentLogin { get; set; }

        public RelayCommand<System.Windows.Window> LoginCommand { get; set; }
        public RelayCommand<System.Windows.Window> LogoutCommand { get; set; }
        #endregion

        #region constructors
        public HomeViewModel(MainWindow window)
        {
            this.MainWindow = window;
            this.LoginButtonVisibility = Visibility.Visible;
            this.LogoutButtonVisibility = Visibility.Collapsed;
            WireUpEvents();
        }
        #endregion

        #region methods
        private void WireUpEvents()
        {
            LoginCommand = new RelayCommand<System.Windows.Window>(LoginAction);
            LogoutCommand = new RelayCommand<System.Windows.Window>(LogoutAction);
            Messenger.Default.Register<CurrentLogin>(this, LoginMessageAction);
        }

        private void LoginMessageAction(CurrentLogin message)
        {
            if (message != null)
            {
                if (message.LoginStatus == "Logged In")
                {
                    this.CurrentLogin = message;
                    this.LogoutButtonVisibility = Visibility.Visible;
                    this.LoginButtonVisibility = Visibility.Collapsed;
                    this.MainWindow.UpdateContent(message.LoginStatus);
                }
            }
        }


        private void LoginAction(System.Windows.Window window)
        {
            System.Windows.Window win = (System.Windows.Window)window;
            IsValidInput = true;
            if (win != null)
            {
                if (IsValidInput)
                {
                    try
                    {
                        LoginWindow login = new LoginWindow(window);
                        login.ShowDialog();
                        login.BringIntoView();
                        login.Topmost = true;
                        login.WindowState = WindowState.Normal;
                    }
                    catch (Exception e)
                    {

                    }
                }

            }

        }

        private void LogoutAction(System.Windows.Window window)
        {
            System.Windows.Window win = (System.Windows.Window)window;
            this.CurrentLogin = null;
            this.LoginButtonVisibility = Visibility.Visible;
            this.LogoutButtonVisibility = Visibility.Collapsed;
            (win as MainWindow).UpdateContent("Logged out");
        }

        #endregion
    }
}
