using GalaSoft.MvvmLight.Command;
using SSS.NATTEX.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SSS.NATTEX.ViewModel
{
    public class ApplicationConfigurationViewModel : MainViewModel
    {
        #region fields
        private string _accessUserName;
        private string _accessPassword;
        private string _validationMessage;
        private string _userName;
        private string _password;
        private string _serverName;
        private string _databaseName;
        private bool _isValidInput;
        private bool _configurationSelected;
        private bool _accessControlSelected;
        private bool _isValidConnectionInput;
        private int _selectedIndex;

        private Visibility _validationMessageVisibility;
        private Visibility _accessControlVisibility;
        private Visibility _configurationVisibility;

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

        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                _serverName = value;
                this.RaisePropertyChanged("ServerName");
            }
        }

        public string DatabaseName
        {
            get
            {
                return _databaseName;
            }
            set
            {
                _databaseName = value;
                this.RaisePropertyChanged("DatabaseName");
            }
        }

        public string AccessUserName
        {
            get
            {
                return _accessUserName;
            }
            set
            {
                _accessUserName = value;
                this.RaisePropertyChanged("AccessUserName");
            }
        }

        public string AccessPassword
        {
            get
            {
                return _accessPassword;
            }
            set
            {
                _accessPassword = value;
                this.RaisePropertyChanged("AccessPassword");
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

        public bool IsValidConnectionInput
        {
            get
            {
                return _isValidConnectionInput;
            }
            set
            {
                _isValidConnectionInput = value;
                this.RaisePropertyChanged("IsValidConnectionInput");
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

        private int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                this.RaisePropertyChanged("SelectedIndex");
            }
        }

        public bool ConfigurationSelected
        {
            get
            {
                return _configurationSelected;
            }
            set
            {
                _configurationSelected = value;
                this.RaisePropertyChanged("ConfigurationSelected");
            }
        }

        public bool AccessControlSelected
        {
            get
            {
                return _accessControlSelected;
            }
            set
            {
                _accessControlSelected = value;
                this.RaisePropertyChanged("AccessControlSelected");
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

        public Visibility AccessControlVisibility
        {
            get
            {
                return _accessControlVisibility;
            }
            set
            {
                _accessControlVisibility = value;
                this.RaisePropertyChanged("AccessControlVisibility");
            }
        }

        public Visibility ConfigurationVisibility
        {
            get
            {
                return _configurationVisibility;
            }
            set
            {
                _configurationVisibility  = value;
                this.RaisePropertyChanged("ConfigurationVisibility");
            }
        }

 

        public RelayCommand<System.Windows.Window> ConnectCommand { get; set; }
        public RelayCommand<System.Windows.Window> SaveCommand { get; set; }
        public RelayCommand<System.Windows.Window> AccessCommand { get; set; }
        #endregion

        #region constructors
        public ApplicationConfigurationViewModel()
        {
            this.SelectedIndex = 1;
            this.AccessControlVisibility = Visibility.Visible;
            this.AccessControlSelected = true;
            this.ConfigurationVisibility = Visibility.Collapsed;
            this.ValidationMessageVisibility = Visibility.Collapsed;
            this.ValidationMessage = string.Empty;
            this.WireUpEvents();
        }
        #endregion

        #region methods
        private void Validate()
        {
            this.IsValidInput = true;

            if (string.IsNullOrEmpty(this.AccessUserName))
            {
                this.ValidationMessage = "Please enter your access name.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else if (string.IsNullOrEmpty(this.AccessPassword))
            {
                this.ValidationMessage = "Please enter your access password.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidInput = false;
            }
            else
            {
                this.ValidationMessage = "";
                this.ValidationMessageVisibility = Visibility.Collapsed;
            }
        }

        private void ValidateConnectionControls()
        {
            this.IsValidConnectionInput = true;
            if (string.IsNullOrEmpty(this.DatabaseName))
            {
                this.ValidationMessage = "Please enter the database name.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidConnectionInput = false;
            }
        }

        private void WireUpEvents()
        {
            AccessCommand = new RelayCommand<System.Windows.Window>(AccessAction);
            ConnectCommand = new RelayCommand<System.Windows.Window>(ConnectAction);
            SaveCommand = new RelayCommand<System.Windows.Window>(SaveAction);
        }

        private void AccessAction(System.Windows.Window window)
        {
            if ((this.AccessUserName == "slambert.software") && (this.AccessPassword == "18032016"))
            {
                this.ConfigurationVisibility = Visibility.Visible;
                this.SelectedIndex = 1;
                this.ConfigurationSelected = true;
                
                this.AccessControlVisibility = Visibility.Collapsed;
            }
        }

        private void ConnectAction(System.Windows.Window window)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True; Integrated Security=True;", this.ServerName, this.DatabaseName,
                this.UserName, this.Password);
            try
            {
                SQLHelper helper = new SQLHelper(connectionString);
                {
                    if (helper.IsConnected())
                    {
                        System.Windows.MessageBox.Show("Database connection succeeded.", "Connection success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Database connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveAction(System.Windows.Window window)
        {
            ValidateConnectionControls();
            if (this.IsValidConnectionInput)  {
                string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True; Integrated Security=True;", this.ServerName, this.DatabaseName,
                    this.UserName, this.Password);
                try
                {
                    SQLHelper helper = new SQLHelper(connectionString);
                    if (helper.IsConnected())
                    {
                        AppSetting setting = new AppSetting();
                        setting.SaveConnectionString("NattexApplicationContext", connectionString);
                        ConfigurationManager.RefreshSection("connectionStrings");
                        System.Windows.MessageBox.Show("Database connection saved.", "Save success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Database connection", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                this.ValidationMessage = "Invalid connection details. Please re-enter.";
                this.ValidationMessageVisibility = Visibility.Visible;
                this.IsValidConnectionInput = false;
            }
        }
        #endregion
    }
}
