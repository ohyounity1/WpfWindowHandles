using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using System.Windows;
using WpfApp1.Factory;
using WpfApp1.Services;
using WpfApp1.ViewModels;
using WpfApp1.Windows;

namespace WpfApp1
{
    public class Bootstrapper
    {
        private readonly IContainer _container;

        public Bootstrapper()
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);
            RegisterViewModels(builder);
            RegisterViews(builder);

            RegisterFactories(builder);

            _container = builder.Build();

            var csl = new AutofacServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultWindowProvider>().As<IWindowProvider>();
            builder.RegisterType<DefaultWindowService>().As<IWindowService>();
            builder.Register((c, p) => new DefaultWindowHandleService(p.TypedAs<Window>())).As<IWindowHandleService>().InstancePerDependency();
        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<LaunchedWindowViewModel>();
        }

        private void RegisterViews(ContainerBuilder builder)
        {
            builder.RegisterType<LaunchedWindow>();
            builder.RegisterType<MainWindow>();
        }

        private void RegisterFactories(ContainerBuilder builder)
        {
            builder.RegisterType<AutoFacLaunchedWindowFactory>().As<ILaunchedWindowFactory>();
        }
    }
}
