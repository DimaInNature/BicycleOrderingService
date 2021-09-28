using System.Windows;
using BicycleOrderingService.ViewModels;

namespace BicycleOrderingService.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private LoginViewModel ViewModel
        {
            get { return (LoginViewModel)DataContext; }
        }

        private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SecurePassword = PasswordBox.SecurePassword;
            ViewModel.UserPassword = PasswordBox.Password;
        }
    }
}
