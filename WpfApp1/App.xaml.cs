using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			// Parse command line arguments into app config
			var bootstrapper = new Bootstrapper();
			// Create start up window
			CommonServiceLocator.ServiceLocator.Current.GetInstance<MainWindow>().Show();
		}
	}
}
