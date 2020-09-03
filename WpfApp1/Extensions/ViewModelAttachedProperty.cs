using System;
using System.Windows;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1.Extensions
{
    public static class ViewModelAttachedProperty
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.RegisterAttached(
            nameof(ViewModelProperty).Replace("Property", string.Empty), typeof(Type), typeof(ViewModelAttachedProperty), new PropertyMetadata(null, ViewModelPropertyChangedCallback));

        private static void ViewModelPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element)
            {
                if (e.NewValue is Type viewModelType)
                {
                    element.DataContext = CommonServiceLocator.ServiceLocator.Current.GetInstance(viewModelType);
                    if(element is Window w && element.DataContext is WindowedViewModelBase vmb)
                    {
                        vmb.WindowProvider = new DefaultWindowProvider(w);
                    }
                }
            }
        }

        public static Type GetViewModel(DependencyObject dependency) =>
            dependency.GetValue(ViewModelProperty) as Type;

        public static void SetViewModel(DependencyObject dependency, Type newValue) =>
            dependency.SetValue(ViewModelProperty, newValue);
    }
}
