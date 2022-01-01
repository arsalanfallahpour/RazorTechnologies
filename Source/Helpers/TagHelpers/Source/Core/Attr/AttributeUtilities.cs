using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Attr
{
    public static class AttributeUtilities
    {
        public static bool TryGetCustomAttribute<T>(PropertyInfo propType, out IList<T> attributes)
         where T : Attribute
        {
            attributes = propType.GetCustomAttributes<T>(true)
                ?.ToList();
            return attributes is not null;
        }
        public static bool TryGetCustomAttribute<T>(Type type, out IList<T> attributes)
            where T : Attribute
        {
            attributes = type.GetCustomAttributes<T>(true)
                ?.ToList();
            return attributes is not null;
        }
        public static bool TryGetAttributeByInterface<TAttribute>(Type type, string interfaceName, out IList<TAttribute> attributes)
        where TAttribute : Attribute
        {
            attributes = null;

            if(!TryGetCustomAttribute<TAttribute>(type, out attributes))
                return false;

            attributes = attributes
                ?.Where(o => o.GetType()?.GetInterface(interfaceName) is not null)
                ?.ToList();

            return attributes is not null;
        }
        public static bool TryGetAttributeByInterface<TAttribute>(PropertyInfo propType, string interfaceName, out IList<TAttribute> attributes)
      where TAttribute : Attribute
        {
            attributes = null;

            if(!TryGetCustomAttribute<TAttribute>(propType, out attributes))
                return false;

            attributes = attributes
                ?.Where(o => o.GetType()?.GetInterface(interfaceName) is not null)
                ?.ToList();

            return attributes is not null;
        }
        // public static bool TryGetTypeByInterface<TInterface>(Type type, out Type @interface)
        //where TInterface : interface
        // {
        //     @interface = type.GetInterface(nameof(TInterface));

        //     if(@interface is null)
        //         return false;


        //     return true;
        // }

    }
}
