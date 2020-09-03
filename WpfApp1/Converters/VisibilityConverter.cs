using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Converters
{
    public class VisibilityConverter : BooleanConverterBase<Visibility>
    {
    }

    public class MultiVisibilityConverter : MultiBooleanConverterBase<Visibility>
    {
    }

    public class EqualsVisilityConverter : EqualsComparisonConverter<Visibility>
    {

    }
}
