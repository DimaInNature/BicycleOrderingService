using BicycleOrderingService.Services.Command;
using BicycleOrderingService.ViewModels.Base;
using BicycleOrderingService.Views;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;
using BicycleOrderingService.Data;
using BicycleOrderingService.Services;

namespace BicycleOrderingService.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            EnterButtonClickCommand = new DelegateCommandService(EnterButtonClick);
            RegisterButtonClickCommand = new DelegateCommandService(RegisterButtonClick);
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

        private string _userLogin;

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

        #endregion

        #region Commands

        #region EnterButtonClickCommand

        public ICommand EnterButtonClickCommand { get; private set; }

        private void EnterButtonClick(object obj)
        {
            if (UserLogin != String.Empty && UserPassword != String.Empty)
            {
                if (ValidationService.Validation(UserLogin,UserPassword))
                {
                    var activeUser = DataManager.User.GetByLoginAndPassword(UserLogin, UserPassword);

                    if (activeUser.IsAdmin)
                    {
                        var view = obj as LoginView;

                        var displayRootRegistry = (Application.Current as App).DisplayWindow;

                        displayRootRegistry.Show(new AdminMainViewModel(activeUser));

                        view.Close();
                    }
                    else
                    {
                        var view = obj as LoginView;

                        var displayRootRegistry = (Application.Current as App).DisplayWindow;

                        displayRootRegistry.Show(new MainViewModel(activeUser));

                        view.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя с таким логином и паролем несуществует", "Ошибка ввода данных",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля ввода логина и пароля.", "Ошибка ввода данных",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region RegisterButtonClickCommand

        public ICommand RegisterButtonClickCommand { get; private set; }

        private void RegisterButtonClick(object obj)
        {
            var view = obj as LoginView;

            var displayRootRegistry = (Application.Current as App).DisplayWindow;

            displayRootRegistry.Show(new RegistrationViewModel());

            view.Close();
        }

        #endregion

        #endregion
    }
}
