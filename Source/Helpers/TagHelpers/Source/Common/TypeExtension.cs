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

        //private void ApplyAdditionalAttributes(object instance, Type type, PropertyInfo[] props)
        //{
        //    PropertyOverridingTypeDescriptor ctd = new PropertyOverridingTypeDescriptor(TypeDescriptor.GetProvider(instance).GetTypeDescriptor(instance));
        //    foreach (var prop in props)
        //    {
        //        var attrs = prop.GetCustomAttributes<FileBrowserVMAttribute>(true).ToList()[0].GetAdditionalAttributes();
        //        PropertyDescriptor pd2 =
        //            TypeDescriptor.CreateProperty(
        //                type, // or just _settings, if it's already a type
        //                TypeDescriptor.GetProperties(instance)[prop.Name],
        //                attrs.ToArray()
        //         );
        //        ctd.OverrideProperty(pd2);
        //    }
        //    TypeDescriptor.AddProvider(new TypeDescriptorOverridingProvider(ctd), instance);
        //    var props2 = TypeDescriptor.GetProperties(instance, true);

        //}
        //private void ApplyAdditionalAttributes(object instance, Type type)
        //{
        //    PropertyOverridingTypeDescriptor ctd = new PropertyOverridingTypeDescriptor(TypeDescriptor.GetProvider(instance).GetTypeDescriptor(instance));
        //    foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(instance))
        //    {
        //        var prop = type.GetProperties().FirstOrDefault(o => o.Name == pd.Name);
        //        var attrs = prop.GetCustomAttributes<BaseFormControlViewModelAttribute>(true).ToList();

        //        if (!attrs.Any())
        //            continue;

        //        var additionalAttributes = new List<Attribute>();
        //        for (int i = 0; i < attrs.Count; i++)
        //            additionalAttributes.AddRange(attrs[i].GetAdditionalAttributes());

        //        PropertyDescriptor pd2 =
        //            TypeDescriptor.CreateProperty(
        //                type, // or just _settings, if it's already a type
        //                pd,
        //                additionalAttributes.ToArray()
        //         );
        //        ctd.OverrideProperty(pd2);
        //    }
        //    TypeDescriptor.AddProvider(new TypeDescriptorOverridingProvider(ctd), instance);
        //    var props2 = TypeDescriptor.GetProperties(instance, true);

        //}
    }
}
