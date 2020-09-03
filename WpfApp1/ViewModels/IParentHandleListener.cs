using System;

namespace WpfApp1.ViewModels
{
    public interface IParentHandleListener
    {
        void UpdateHandles();
        IntPtr SetParentResult { get; set; }
        bool ParentImmediately { get; set; }
    }
}
