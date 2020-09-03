using System;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Services
{
    public interface IWindowService
    {
        void LaunchNewWindow(IWindowProvider provider, Func<Window, IWindowProvider> providerFactory, bool parentImmediately);
    }
}
