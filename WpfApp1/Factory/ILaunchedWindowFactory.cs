using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Services;

namespace WpfApp1.Factory
{
    public interface ILaunchedWindowFactory
    {
        IWindowProvider GetLaunchedWindow(IWindowProvider owner, Func<Window, IWindowProvider> factory, bool parentImmediately);
    }
}
