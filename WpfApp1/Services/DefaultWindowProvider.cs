using System.Windows;

namespace WpfApp1.Services
{
    public class DefaultWindowProvider : IWindowProvider
    {
        private readonly Window _window;

        public DefaultWindowProvider(Window window)
            => _window = window;

        public Window GetWindow() => _window;
    }
}
