using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Converters
{
    public class BooleanConverterBase<D> : ValueConverterBase<bool, D>
    {
        public D True { get; set; }
        public D False { get; set; }


        protected override D ConvertToDestination(bool sourceValue)
        {
            if (sourceValue) return True;
            return False;
        }

        protected override bool ConvertToSource(D sourceValue)
        {
            if (Equals(sourceValue, True)) return true;
            return false;
        }
    }

    public class MultiBooleanConverterBase<D> : MultiValueConverterBase<bool, D>
    {
        public D True { get; set; }
        public D False { get; set; }


        protected override D ConvertToDestination(bool[] sourceValues)
        {
            foreach(var sourceValue in sourceValues)
            {
                if (!sourceValue) return False;
            }
            return True;
        }

        protected override bool[] ConvertToSource(D sourceValue)
        {
            if (Equals(sourceValue, True)) return new[] { true };
            return new[] { false };
        }
    }
}
