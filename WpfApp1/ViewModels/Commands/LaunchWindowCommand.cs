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

        public LaunchWindowCommand(IWindowService windowService, IWindowProvider provider)
        {
            _windowService = windowService;
            _windowProvider = provider;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _windowService.LaunchNewWindow(_windowProvider);
        }

        public void RefreshCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
