using System;
using System.Windows;
using WpfApp1.Services;
using WpfApp1.ViewModels.Commands;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : LaunchedWindowViewModel, ViewModelBase.IPropertyListener<LaunchWindowCommand>
    {
        private readonly IWindowService _windowsService;
        private LaunchWindowCommand _launchWindowCommand;

        public MainWindowViewModel(IWindowService windowService, Func<Window, IWindowHandleService> serviceFactory) :
            base(serviceFactory)
        {
            _windowsService = windowService;
        }

        public LaunchWindowCommand LaunchWindowCommand
        {
            get => _launchWindowCommand;
            set
            {
                if (!ReferenceEquals(_launchWindowCommand, value))
                {
                    _launchWindowCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        public void UpdateValue(string propertyName, LaunchWindowCommand value)
        {
            OnPropertyChanged(propertyName);
        }

        protected override void OnWindowProviderUpdated(IWindowProvider provider, Func<Window, IWindowProvider> providerFactory)
        {
            base.OnWindowProviderUpdated(provider, providerFactory);
            _launchWindowCommand = new LaunchWindowCommand(_windowsService, provider, providerFactory);
        }
    }
}
