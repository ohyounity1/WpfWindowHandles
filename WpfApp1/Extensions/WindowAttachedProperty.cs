using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Extensions
{
    public static class WindowAttachedProperty
    {
        public static readonly DependencyProperty RefreshViewModelOnRenderedProperty = DependencyProperty.RegisterAttached(
            nameof(RefreshViewModelOnRenderedProperty).Replace("Property", string.Empty), typeof(bool), typeof(WindowAttachedProperty), new PropertyMetadata(false, OnRefreshViewModelOnRenderedPropertyChanged));

        private static void OnRefreshViewModelOnRenderedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window w)
            {
                w.ContentRendered += OnContentRenderedEventHandler;
            }
        }

        private static void OnContentRenderedEventHandler(object sender, EventArgs e)
        {
            if(sender is Window W)
            {
                W.ContentRendered -= OnContentRenderedEventHandler;
                if(W.DataContext is IViewRenderedListener l)
                {
                    l.OnContentRendered();
                }
            }
        }

        public static int GetRefreshViewModelOnRendered(DependencyObject obj) =>
            (int)obj.GetValue(RefreshViewModelOnRenderedProperty);

        public static void SetRefreshViewModelOnRendered(DependencyObject obj, bool refresh) =>
            obj.SetValue(RefreshViewModelOnRenderedProperty, refresh);
    }
}
