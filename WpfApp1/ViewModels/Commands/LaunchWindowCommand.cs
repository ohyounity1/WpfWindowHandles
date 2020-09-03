using System;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Services;

namespace WpfApp1.ViewModels.Commands
{
    public class LaunchWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IWindowService _windowService;
        private readonly IWindowProvider _windowProvider;
        private readonly Func<Window, IWindowProvider> _providerFactory;

        public LaunchWindowCommand(IWindowService windowService, 
            IWindowProvider provider, 
            Func<Window, IWindowProvider> providerFactory)
        {
            _windowService = windowService;
            _windowProvider = provider;
            _providerFactory = providerFactory;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _windowService.LaunchNewWindow(_windowProvider, _providerFactory, (bool)parameter);
        }

        public void RefreshCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
