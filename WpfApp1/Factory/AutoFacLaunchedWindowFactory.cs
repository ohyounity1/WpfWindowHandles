using Autofac;
using WpfApp1.Windows;
using System.Windows;

namespace WpfApp1.Factory
{
    public class AutoFacLaunchedWindowFactory : ILaunchedWindowFactory
    {
        //private readonly Window _window;

        public AutoFacLaunchedWindowFactory(ILifetimeScope container)
        {
            /*
            _window.DataContext = container.Resolve<LaunchedWindowViewModel>(
                new ResolvedParameter((pi, ptx) => pi.ParameterType == typeof(IWindowHandleService), 
                    (pi, ptx) => 
                        ptx.Resolve<IWindowHandleService>(new TypedParameter(typeof(Window), _window))));*/
        }

        public Window GetLaunchedWindow(Window owner)
        {
            var window = CommonServiceLocator.ServiceLocator.Current.GetInstance<LaunchedWindow>();
            if(owner != null)
            {
                window.Owner = owner;
            }
            return window;
        }
    }
}
