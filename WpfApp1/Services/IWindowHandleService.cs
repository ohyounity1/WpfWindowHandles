using System;
using System.Windows;

namespace WpfApp1.Services
{
    public interface IWindowHandleService
    {
        IntPtr GetParent();
        IntPtr GetHandle();
        IntPtr GetOwner();
        IntPtr GetAncestor();
        IntPtr SetParent(IntPtr newParent);
    }
}
