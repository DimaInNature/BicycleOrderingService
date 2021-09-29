using System.Windows;
using BicycleOrderingService.Services;
using BicycleOrderingService.ViewModels;
using BicycleOrderingService.Views;

namespace BicycleOrderingService
{
    public partial class App : Application
    {
        public DisplayWindowService DisplayWindow { get; private set; } = new DisplayWindowService();

        public App()
        {
            DisplayWindow.RegisterWindow<LoginViewModel, LoginView>();
            DisplayWindow.RegisterWindow<RegistrationViewModel, RegistrationView>();
            DisplayWindow.RegisterWindow<MainViewModel, MainView>();
            DisplayWindow.RegisterWindow<AdminMainViewModel, AdminMainView>();
        }
    }
}
