using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorTechnologies.Core.Common
{
    public static class TypeExtension
    {
        public static Type[] GetItSelfInterfaces(this Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            var allInterfaces = type.GetInterfaces();
            var nonInheritedInterfaces = new HashSet<Type>(allInterfaces);
            if (type.BaseType == null)
                return allInterfaces;
            foreach (var baseInterface in type.BaseType.GetInterfaces())
            {
                RemoveInheritedInterfaces(baseInterface, nonInheritedInterfaces);

            }
            foreach (var iface in allInterfaces)
            {
                RemoveInheritedInterfaces(iface, nonInheritedInterfaces);
            }
            return nonInheritedInterfaces.ToArray();
        }

        public static void RemoveInheritedInterfaces(Type iface, HashSet<Type> ifaces)
        {
            foreach (var inheritedIface in iface.GetInterfaces())
            {
                ifaces.Remove(inheritedIface);
                RemoveInheritedInterfaces(inheritedIface, ifaces);
            }
        }
    }
}
