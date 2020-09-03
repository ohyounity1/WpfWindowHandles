using System;
using System.Windows;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public abstract class WindowedViewModelBase : ViewModelBase
    {
        protected abstract void OnWindowProviderUpdated(IWindowProvider provider, Func<Window, IWindowProvider> factory);

        public void UpdateWindowProvider(IWindowProvider windowProvider, Func<Window, IWindowProvider> providerFactory)
        {
            WindowProvider = windowProvider;
            OnWindowProviderUpdated(WindowProvider, providerFactory);
        }

        protected abstract void OnParentImmediatelyUpdated(bool parentImmediately);

        public void UpdateParentImmediately(bool parentImmediately)
        {
            OnParentImmediatelyUpdated(parentImmediately);
        }

        private IWindowProvider _windowProvider;
        protected IWindowProvider WindowProvider
        {
            get => _windowProvider;
            set
            {
                if (!ReferenceEquals(_windowProvider, value))
                {
                    _windowProvider = value;
                }
            }
        }
    }
}
