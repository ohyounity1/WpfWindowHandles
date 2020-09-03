using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public abstract class WindowedViewModelBase : ViewModelBase
    {
        protected abstract void OnWindowProviderUpdated(IWindowProvider provider);

        private IWindowProvider _windowProvider;
        public IWindowProvider WindowProvider
        {
            get => _windowProvider;
            set
            {
                if (!ReferenceEquals(_windowProvider, value))
                {
                    _windowProvider = value;
                    OnWindowProviderUpdated(_windowProvider);
                }
            }
        }
    }
}
