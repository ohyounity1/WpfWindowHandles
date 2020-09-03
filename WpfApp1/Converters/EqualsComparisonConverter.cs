using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class EqualsComparisonConverter<D> : IMultiValueConverter
    {
        public BooleanConverterBase<D> Converter { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            for(var outerIndex = 0; outerIndex < values.Length; ++outerIndex)
            {
                for(var innerIndex = outerIndex + 1; innerIndex < values.Length; ++innerIndex)
                {
                    if (!Equals(values[outerIndex], values[innerIndex])) return Converter.Convert(false, targetType, parameter, culture);
                }
            }
            return Converter.Convert(true, targetType, parameter, culture);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { Binding.DoNothing };
        }
    }
}
