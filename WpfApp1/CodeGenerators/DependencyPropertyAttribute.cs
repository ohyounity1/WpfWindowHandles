using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.CodeGenerators
{
    public enum DependencyPropertyType
    {
        Regular,
        Attached
    }

    public class DependencyPropertyAttribute : Attribute
    {
        public DependencyPropertyType Type { get; set; }

        public DependencyPropertyAttribute(DependencyPropertyType type)
        {
            Type = type;
        }
    }

    public enum DependencyPropertyClassType
    {
        NonStatic,
        Static
    }

    public class DependencyPropertyClassAttribute : Attribute
    {
        public DependencyPropertyClassType ClassType { get; set; }

        public DependencyPropertyClassAttribute(DependencyPropertyClassType classType)
        {
            ClassType = classType;
        }
    }
}
