using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Extensions
{
    public static class AttachedPropertiesHelper
    {
        private static DependencyProperty RegisterAttached<T>(string propertyName, PropertyChangedCallback cb) =>
            DependencyProperty.RegisterAttached(propertyName.Replace("Property", string.Empty), typeof(T), typeof(GridExtendedProperties), new PropertyMetadata(default(T), cb));

        private static DependencyProperty RegisterAttached<T>(string propertyName) =>
            DependencyProperty.RegisterAttached(propertyName.Replace("Property", string.Empty), typeof(T), typeof(GridExtendedProperties));
    }
}
