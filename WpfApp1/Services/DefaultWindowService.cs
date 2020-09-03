using System;
using System.Windows;
using WpfApp1.Factory;
using WpfApp1.ViewModels;

namespace WpfApp1.Services
{
    public class DefaultWindowService : IWindowService
    {
        private readonly ILaunchedWindowFactory _factory;

        public DefaultWindowService(ILaunchedWindowFactory factory)
        {
            _factory = factory;
        }

        public void LaunchNewWindow(IWindowProvider provider, Func<Window, IWindowProvider> providerFactory, bool parentImmediately)
        {
            var window = _factory.GetLaunchedWindow(provider, providerFactory, parentImmediately);
            window.GetWindow().Show();
        }
    }
}
