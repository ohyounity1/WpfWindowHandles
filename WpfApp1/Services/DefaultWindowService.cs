using WpfApp1.Factory;

namespace WpfApp1.Services
{
    public class DefaultWindowService : IWindowService
    {
        private readonly ILaunchedWindowFactory _factory;

        public DefaultWindowService(ILaunchedWindowFactory factory)
        {
            _factory = factory;
        }

        public void LaunchNewWindow(IWindowProvider provider)
        {
            var window = _factory.GetLaunchedWindow(provider.GetWindow());
            window.Show();
        }
    }
}
