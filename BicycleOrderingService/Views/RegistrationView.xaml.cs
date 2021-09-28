using System.Windows;
using BicycleOrderingService.ViewModels;

namespace BicycleOrderingService.Views
{
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private RegistrationViewModel ViewModel
        {
            get { return (RegistrationViewModel)DataContext; }
        }

        private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SecurePassword = PasswordBox.SecurePassword;
            ViewModel.UserPassword = PasswordBox.Password;
        }
    }
}
