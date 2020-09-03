using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public abstract class ValueConverterBase<S, D> : IValueConverter
    {
        protected abstract D ConvertToDestination(S sourceValue);
        protected abstract S ConvertToSource(D sourceValue);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is S sourceValue)
            {
                return ConvertToDestination(sourceValue);
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is D sourceValue)
            {
                return ConvertToSource(sourceValue);
            }
            return Binding.DoNothing;
        }
    }

    public abstract class MultiValueConverterBase<S, D> : IMultiValueConverter
    {
        protected abstract D ConvertToDestination(S[] sourceValues);
        protected abstract S[] ConvertToSource(D sourceValue);

        public object Convert(object[] values, Type targetTypes, object parameter, CultureInfo culture)
        {
            try
            {
                return ConvertToDestination(values.Cast<S>().ToArray());
            }
            catch(Exception)
            {
                return Binding.DoNothing;
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            if (value is D sourceValue)
            {
                return ConvertToSource(sourceValue).Cast<object>().ToArray();
            }
            return new[] { Binding.DoNothing };
        }
    }
}
