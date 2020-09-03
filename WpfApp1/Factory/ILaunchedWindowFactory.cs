using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Factory
{
    public interface ILaunchedWindowFactory
    {
        Window GetLaunchedWindow(Window owner);
    }
}
