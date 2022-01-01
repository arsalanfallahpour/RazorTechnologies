using System;
using System.Collections.Generic;
using System.Reflection;

using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

namespace RazorTechnologies.Core.Common
{
    public class AppType
    {
        public AppType(Type type)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));
            _interfaces = GetInterfaces();
            _itSelfInterfaces = GetItselfInterfaces();
        }
        public AppType(ref Type type)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));
            _interfaces = GetInterfaces();
            _itSelfInterfaces = GetItselfInterfaces();
        }
        public AppType(AppType appType)
        {
            if (appType == null)
                throw new ArgumentNullException(nameof(appType));
            _type = appType.Type;
            _interfaces = appType.Interfaces;
            _itSelfInterfaces = appType.ItselfInterfaces;
        }

        public bool HasBaseType<T>()
            where T: class
        {
            if (Type.BaseType is null)
                return false;
            return HasBaseType<T>(Type.BaseType);
        }
        public static bool HasBaseType<T>(Type baseType)
           where T : class
        {
            if (baseType is null)
                return false;
            if (baseType.GUID.CompareTo(typeof(T).GUID) == 0)
                return true;
            return HasBaseType<T>(baseType.BaseType);
        }

        public string TypeName { get { return _type.Name; } }
        public Guid TypeGuid { get { return _type.GUID; } }
        public string TypeNamespace { get { return _type.Namespace; } }
        public string TypeFullName { get { return _type.FullName; } }
        public bool IsInterface { get { return _type.IsInterface; } }
        public bool IsAbstract { get { return _type.IsAbstract; } }
        public bool IsValueType { get { return _type.IsValueType; } }
        public bool IsGenericType { get { return _type.IsGenericType; } }

        public Type Type { get { return _type; } }
        private readonly Type _type;

        public List<AppInterface> Interfaces { get { return _interfaces; } }
        private List<AppInterface> _interfaces;
        public List<AppInterface> ItselfInterfaces { get { return _itSelfInterfaces; } }
        private List<AppInterface> _itSelfInterfaces;

        public List<AppInterface> GetItselfInterfaces()
        {

            var interfaces = new List<AppInterface>();
            Type[] itItSelfTypeInterfaces = _type.GetItSelfInterfaces();

            for (int i = 0; i < itItSelfTypeInterfaces.Length; i++)
            {
                var currentInterface = itItSelfTypeInterfaces[i];

                if (currentInterface.IsInterface)
                    interfaces.Add(new AppInterface(ref currentInterface, false));
            }
            return interfaces;
        }
        public List<AppInterface> GetInterfaces()
        {

            var interfaces = new List<AppInterface>();
            Type[] itTypeInterfaces = _type.GetInterfaces();

            for (int i = 0; i < itTypeInterfaces.Length; i++)
            {
                var currentInterface = itTypeInterfaces[i];

                if (currentInterface.IsInterface)
                    interfaces.Add(new AppInterface(ref currentInterface, true));
            }
            return interfaces;
        }
        public override string ToString()
        {
            return TypeName;
        }
        public bool IsExactSameWith(AppType otherItem)
        {
            return TypeGuid == otherItem.TypeGuid && TypeNamespace == otherItem.TypeNamespace;
        }
        public  static bool operator ==(AppType a, AppType b)
        {
            return a.IsExactSameWith(b);
        }
        public static bool operator !=(AppType a, AppType b)
        {
            return !a.IsExactSameWith(b);
        }
        public bool FindInterface(Guid findoutTypeGuid, bool justItself)
        {

            List<AppInterface> interfaces;
            if (justItself)
                interfaces = ItselfInterfaces;
            else
                interfaces = Interfaces;

            for (int i = 0; i < interfaces.Count; i++)
            {
                var currentInterface = interfaces[i];
                if (currentInterface.TypeGuid == findoutTypeGuid)
                    return true;
            }
            return false;

        }
        //public AppTypeMetaDataAttribute GetAppTypeMetaData()
        //{
        //    AppTypeMetaDataAttribute attribute;
        //    if (!TryGetTypeAttribute<AppTypeMetaDataAttribute>(out attribute))
        //        return new AppTypeMetaDataAttribute(string.Empty, string.Empty);

        //    return attribute;
        //}
        public bool TryGetTypeAttribute<TAttribute>(out TAttribute attribute, int index = 0)
            where TAttribute : Attribute
        {
            attribute = null;
            var attributes = Type.GetCustomAttributes(typeof(TAttribute), false);
            if (attributes == null)
                return false;

            if (attributes.Length < 1)
                return false;

            attribute = (TAttribute)attributes[index];
            return true;
        }

        public bool TryGetTypePropertyValue<TProperty>(object src, string name, out TProperty objValue)
            where TProperty: class
        {
            objValue = default;

            var objProperty = Type.GetProperty(name) as PropertyInfo;
            if (objProperty == null)
                return false;
            objValue = objProperty.GetValue(src, null) as TProperty;
            if (objValue is null)
                return false;
            return true;
        }
        //public string GetControlText(Type[] types)
        //{
        //    IAppControl appType;
        //    if (!TryCreateInstance(types, out appType))
        //        return string.Empty;

        //    if (string.IsNullOrEmpty(appType.Text))
        //        return "بدون متن";

        //    return appType.Text;
        //}
        public bool TryCreateInstance<T>(Type[] types, out T instance)
            where T : class
        {
            instance = null;
            var constructor = Type.GetConstructor(new Type[] { });

            if (constructor == null)
                constructor = Type.GetConstructor(types);

            if (constructor == null)
                return false;
            var obj = Activator.CreateInstance(Type, constructor.GetParameters());

            if (obj == null)
                return false;

            instance = obj as T;
            return instance != null;
        }
    }
}