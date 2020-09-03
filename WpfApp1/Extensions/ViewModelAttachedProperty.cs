using System;
using System.Windows;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1.Extensions
{
    public static class ViewModelAttachedProperty
    {
        public static readonly DependencyProperty ViewModelProperty = RegisterAttached<Type>(
            nameof(ViewModelProperty), ViewModelPropertyChangedCallback);

        private static void ViewModelPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element)
            {
                if (e.NewValue is Type viewModelType)
                {
                    element.DataContext = CommonServiceLocator.ServiceLocator.Current.GetInstance(viewModelType);
                    if(element is Window w && element.DataContext is WindowedViewModelBase vmb)
                    {
                        vmb.UpdateWindowProvider(new DefaultWindowProvider(w), (window) => new DefaultWindowProvider(window));
                    }
                }
            }
        }

        public static Type GetViewModel(DependencyObject dependency) =>
            dependency.GetValue(ViewModelProperty) as Type;

        public static void SetViewModel(DependencyObject dependency, Type newValue) =>
            dependency.SetValue(ViewModelProperty, newValue);


        public static readonly DependencyProperty ParentImmediatelyProperty = RegisterAttached<bool>(
            nameof(ParentImmediatelyProperty), ParentImmediatelyPropertyChangedCallback);

        private static void ParentImmediatelyPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window w && w.DataContext is WindowedViewModelBase vmb)
            {
                vmb.UpdateParentImmediately((bool)e.NewValue);
            }
        }

        public static bool GetParentImmediately(DependencyObject dependency) =>
            (bool)dependency.GetValue(ParentImmediatelyProperty);

        public static void SetParentImmediately(DependencyObject dependency, bool newValue) =>
            dependency.SetValue(ParentImmediatelyProperty, newValue);

        private static DependencyProperty RegisterAttached<T>(string propertyName, PropertyChangedCallback cb) =>
            DependencyProperty.RegisterAttached(propertyName.Replace("Property", string.Empty), typeof(T), typeof(ViewModelAttachedProperty), new PropertyMetadata(default(T), cb));

        private static DependencyProperty RegisterAttached<T>(string propertyName) =>
            DependencyProperty.RegisterAttached(propertyName.Replace("Property", string.Empty), typeof(T), typeof(ViewModelAttachedProperty));
    }
}
