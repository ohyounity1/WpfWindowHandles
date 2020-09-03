using System;
using System.Diagnostics;
using System.Windows.Input;
using WpfApp1.Services;

namespace WpfApp1.ViewModels.Commands
{
    public class UnSyncParentWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IWindowHandleService _windowService;
        private readonly IParentHandleListener _handleListener;

        public UnSyncParentWindowCommand(IWindowHandleService windowService, IParentHandleListener handleListener)
        {
            _windowService = windowService;
            _handleListener = handleListener;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var result = _windowService.SetParent((IntPtr)parameter);
            Debug.WriteLine(result);
            _handleListener.UpdateHandles();
        }

        public void RefreshCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
