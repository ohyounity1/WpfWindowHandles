using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Extensions
{
    public static class LaunchedWindowViewModelAttachedProperty
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
                }
            }
        }

        public static Type GetViewModel(DependencyObject dependency) =>
            dependency.GetValue(ViewModelProperty) as Type;

        public static void SetViewModel(DependencyObject dependency, Type newValue) =>
            dependency.SetValue(ViewModelProperty, newValue);
    }
}
