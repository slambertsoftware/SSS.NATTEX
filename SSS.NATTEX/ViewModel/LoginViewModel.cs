using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SSS.NATTEX.ViewModel
{
    public class LoginViewModel: MainViewModel
    {
        #region fields
        private int    _userID;
        private string _userName;
        private string _password;
        private string _userFirstName;
        private string _userLastName;
        private string _userRole;
        private string _validationMessage;
        private string _loginMessage;
        private bool _isValidInput;

        private System.Windows.Window _mainWindow;
        private Visibility _validationMessageVisibility;
        #endregion

        #region properties
        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
                this.RaisePropertyChanged("UserID");
            }
        }

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

        public string UserFirstName
        {
            get
            {
                return _userFirstName;
            }
            set
            {
                _userFirstName = value;
                this.RaisePropertyChanged("UserFirstName");
            }
        }

        public string UserLastName
        {
            get
            {
                return _userLastName;
            }
            set
            {
                _userLastName = value;
                this.RaisePropertyChanged("UserLastName");
            }
        }

        public string UserRole
        {
            get
            {
                return _userRole;
            }
            set
            {
                _userRole = value;
                this.RaisePropertyChanged("UserRole");
            }
        }

        public string LoginMessage
        {
            get
            {
                return _loginMessage;
            }
            set
            {
                _loginMessage = value;
                this.RaisePropertyChanged("LoginMessage");
            }
        }

        public System.Windows.Window MainWindow
        {
            get
            {
                return _mainWindow;
            }
            set
            {
                _mainWindow = value;
                this.RaisePropertyChanged("MainWindow");
            }
        }

        public bool IsValidInput
        {
            get
            {
                return _isValidInput;
            }
            set {
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

        public RelayCommand<System.Windows.Window> LoginCommand { get; set; }
        public RelayCommand<System.Windows.Window> CancelCommand { get; set; }
        #endregion

        #region constructors
        public LoginViewModel(System.Windows.Window window)
        {
            this.ValidationMessageVisibility = Visibility.Collapsed;
            this.ValidationMessage = string.Empty;
            WireUpEvents();
        }
        #endregion

        #region methods
        private void WireUpEvents()
        {
           LoginCommand = new RelayCommand<System.Windows.Window>(LoginAction);
           CancelCommand = new RelayCommand<System.Windows.Window>(CancelAction);
        }

        private void Validate()
        {
            this.IsValidInput = true;

            if (string.IsNullOrEmpty(this.UserName))
            {
                this.ValidationMessage = "Please enter your user name.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (string.IsNullOrEmpty(this.Password))
            {
                this.ValidationMessage = "Please enter your password.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
        }

        private void LoginAction(System.Windows.Window window)
        {
            System.Windows.Window win = (System.Windows.Window)window;

            if (win != null)
            {
                Validate();
                if (IsValidInput)
                {
                    try
                    {
                        if (IsvalidUserCredentials())
                        {
                            CurrentLogin message = new CurrentLogin()
                            {
                                LoginStatus = "Logged In",
                                UserID  = this.UserID,
                                UserName = this.UserName,
                                UserFirstName = this.UserFirstName,
                                UserLastName = this.UserLastName,
                                UserRole = this.UserRole,
                                Message = ""
                            };
                            Messenger.Default.Send<CurrentLogin>(message);
                            win.DialogResult = true;
                            win.Close();
                        }
                        else
                        {
                            this.ValidationMessage = "Invalid user credentials. Please retry.";
                            this.ValidationMessageVisibility = Visibility.Visible;
                            this.IsValidInput = false;
                        }
                    }
                    catch (Exception e)
                    {
                        this.ValidationMessage = "Please contact the system administrator if the problem persists. Note the following error message : " + e.Message;
                        this.ValidationMessageVisibility = Visibility.Visible;
                        this.IsValidInput = false;
                    }
                }

            }

        }

        private void CancelAction(System.Windows.Window window)
        {
            System.Windows.Window win = (System.Windows.Window)window;
            if (win != null)
            {
                win.Close();
            }
        }

        private bool IsvalidUserCredentials()
        {
            bool result = true;
            var db = new NattexApplicationContext();
            var list = db.ApplicationUsers.ToList();

            using (var context = new NattexApplicationContext())
            {
                ApplicationUser user = context.ApplicationUsers.Where(x => x.UserName == this.UserName && x.Password == this.Password && x.IsActive == true).FirstOrDefault();
                if (user != null)
                {
                    this.UserID   = user.ApplicationUserID;
                    this.UserRole = user.ApplicationRole.Description;
                    this.UserName = user.UserName;
                    this.UserFirstName = user.FirstName;
                    this.UserLastName = user.LastName;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        #endregion



    }
}
