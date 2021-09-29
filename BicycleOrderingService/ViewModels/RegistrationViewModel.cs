using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;
using BicycleOrderingService.Data;
using BicycleOrderingService.Models;
using BicycleOrderingService.Services.Command;
using BicycleOrderingService.ViewModels.Base;
using BicycleOrderingService.Views;

namespace BicycleOrderingService.ViewModels
{
    class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel()
        {
            RegistrationButtonClickCommand = new DelegateCommandService(RegistrationButtonClick);
            CancelButtonClickCommand = new DelegateCommandService(CancelButtonClick);
        }

        #region Properties

        public string UserLogin
        {
            get => _userLogin;
            set
            {
                _userLogin = value;
            }
        }

        private string _userLogin = String.Empty;

        public SecureString SecurePassword
        {
            get => _securePassword;
            set
            {
                _securePassword = value;
                OnPropertyChanged("SecurePassword");
            }
        }

        private SecureString _securePassword;

        public unsafe string UserPassword
        {
            [SecurityCritical]
            get
            {
                if (SecurePassword != null)
                {
                    SecureString securePassword = SecurePassword;
                    IntPtr intPtr = Marshal.SecureStringToBSTR(securePassword);
                    return new string((char*)(void*)intPtr);
                }
                return String.Empty;
            }
            [SecurityCritical]
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                using (SecureString secureString = new SecureString())
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        secureString.AppendChar(value[i]);
                    }
                }
                _userPassword = value;
            }
        }

        private string _userPassword;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
            }
        }

        private string _userName = String.Empty;

        public string UserSurname
        {
            get => _userSurname;
            set
            {
                _userSurname = value;
            }
        }

        private string _userSurname = String.Empty;

        #endregion

        #region Commands

        #region RegistrationButtonClickCommand

        public ICommand RegistrationButtonClickCommand { get; private set; }

        private void RegistrationButtonClick(object obj)
        {
            if (UserLogin != String.Empty && UserPassword != String.Empty 
            && UserName != String.Empty && UserSurname != String.Empty)
            {
                UserModel user = new UserModel()
                {
                    Login = UserLogin,
                    Password = UserPassword,
                    Name = UserName,
                    Surname = UserSurname,
                    IsAdmin = false
                };

                if (DataManager.User.Create(user))
                {
                    var view = obj as RegistrationView;

                    var displayRootRegistry = (Application.Current as App).DisplayWindow;

                    displayRootRegistry.Show(new MainViewModel(user));

                    view.Close();
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля.", "Ошибка ввода данных",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region CancelButtonClickCommand

        public ICommand CancelButtonClickCommand { get; private set; }

        private void CancelButtonClick(object obj)
        {
            var view = obj as RegistrationView;

            var displayRootRegistry = (Application.Current as App).DisplayWindow;

            displayRootRegistry.Show(new LoginViewModel());

            view.Close();
        }

        #endregion

        #endregion
    }
}
