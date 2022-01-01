//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Reflection;

//namespace RazorTechnologies.Core.Common.Services
//{
//    public abstract class BaseTypeResolverService
//    {
//        /// <summary>
//        /// Initialize For Find types in current assembly
//        /// </summary>
//        /// <param name="assembly"></param>
//        public BaseTypeResolverService(Assembly assembly)
//        {
//            _guidAppTypeMetaDataAttribute = typeof(AppTypeMetaDataAttribute).GUID;
//            _appAssembly = assembly;
//            _appMetaTagTypes = new List<Type>
//            {
//                typeof(AppTypeMetaDataAttribute)
//            };

//            _potentialAppType = new List<AppType>();

//            //if (!TryFindTypeHaveMetaTagAttribute(out _attributedTypes))
//            //    _attributedTypes = new Dictionary<Type, List<Attribute>>();

//        }
//        public abstract List<AppType> GetAllPotentialAppTypes();
//        public List<AppType> PotentialAppType { get { return _potentialAppType; } }
//        private readonly List<AppType> _potentialAppType;
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="appType"></param>
//        /// <returns>True if type add to collection; otherwise false</returns>
//        public bool AddPotentialAppType(AppType appType)
//        {
//            if (_potentialAppType.Any(o => o.TypeGuid.CompareTo(appType.TypeGuid) == 0))
//                 return false;

//            _potentialAppType.Add(appType);
//                return true;
//        }
//                /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="appType"></param>
//        /// <returns>True if type add to collection; otherwise false</returns>
//        public bool AddPotentialAppType(List<AppType> appTypes)
//        {
//            var isAllAdded = true;
//            for (int i = 0; i < appTypes.Count; i++)
//            {
//                var appType = appTypes[i];
//                if (_potentialAppType.Any(o => o.TypeGuid.CompareTo(appType.TypeGuid) == 0))
//                {
//                    isAllAdded = false;
//                    continue;
//                }

//                _potentialAppType.Add(appType);
//            }
//            return isAllAdded;
//        }

//        private const bool EnableFindInhritedMetaAttributes = false;
//        public Assembly AppAssembly { get { return _appAssembly; } }
//        public List<CsFileContentInfo> AttributedTypes { get { return _attributedTypes; } }
//        private List<CsFileContentInfo> _attributedTypes;

//        protected readonly Assembly _appAssembly;
//        protected Type[] _appAssemblyTypes;
//        protected List<Type> _appAssemblyInterfaces;
//        public List<Type> AppMetaTagTypes { get { return _appMetaTagTypes; } }
//        private readonly List<Type> _appMetaTagTypes;

//        public Guid GUIDAppTypeMetaDataAttribute { get { return _guidAppTypeMetaDataAttribute; } }
//        private readonly Guid _guidAppTypeMetaDataAttribute;
//        public Type GetType(string typeName)
//        {
//            var typeGuid = Guid.Empty;
//            return GetType(typeName, out typeGuid);
//        }
//        public Type GetType(Guid typeGuid, out string typeName)
//        {
//            typeName = string.Empty;
//            var types = GetAllAppTypes();
//            for (int i = 0; i < types.Length; i++)
//            {
//                var currentType = _appAssemblyTypes[i];
//                if (currentType.GUID == typeGuid)
//                {
//                    typeName = currentType.Name;
//                    return currentType;
//                }
//            }
//            return null;
//        }
//        public Type GetType(Guid typeGuid)
//        {
//            var typeName = string.Empty;
//            return GetType(typeGuid, out typeName);
//        }
//        public Type GetType(string typeName, out Guid typeGuid)
//        {
//            typeGuid = Guid.Empty;
//            var types = GetAllAppTypes();
//            for (int i = 0; i < types.Length; i++)
//            {
//                var currentType = _appAssemblyTypes[i];
//                if (currentType.Name == typeName)
//                {
//                    typeGuid = currentType.GUID;
//                    return currentType;
//                }
//            }
//            return null;
//        }
//        public Type[] GetAllAppTypes()
//        {
//            if (_appAssemblyTypes != null)
//                if (_appAssemblyTypes.Length > 0)
//                    return _appAssemblyTypes;

//            _appAssemblyTypes = _appAssembly.GetTypes();
//            return _appAssemblyTypes;
//        }
//        public List<Type> GetAllTypesInterfaces()
//        {
//            if (_appAssemblyInterfaces != null)
//                if (_appAssemblyInterfaces.Count > 0)
//                    return _appAssemblyInterfaces;

//            var interfaces = new List<Type>();
//            var assmblyTypes = _appAssembly.GetTypes();
//            for (int i = 0; i < assmblyTypes.Length; i++)
//            {
//                var currentType = _appAssemblyTypes[i];
//                if (currentType.IsInterface)
//                    interfaces.Add(currentType);
//            }
//            _appAssemblyInterfaces = interfaces;
//            return interfaces;
//        }
//        //public List<Type> GetAllTypesInterfaces(Type type, bool justInherited)
//        //{

//        //    var interfaces = new List<Type>();
//        //    Type[] expectedTypeInterfaces;


//        //    if (justInherited)
//        //        expectedTypeInterfaces = type.GetItSelfInterfaces();
//        //    else
//        //        expectedTypeInterfaces = type.GetInterfaces();

//        //    for (int i = 0; i < expectedTypeInterfaces.Length; i++)
//        //    {
//        //        var currentInterface = expectedTypeInterfaces[i];

//        //        if (currentInterface.IsInterface)
//        //            interfaces.Add(currentInterface);
//        //    }
//        //    return interfaces;
//        //}
//        //public virtual bool FindTypeInterface(AppType type, Guid interfaceTypeGuid, bool nonInheritedInterface)
//        //{
//        //    if (type == null)
//        //        return false;

//        //    if (type.IsInterface)
//        //        return false;
//        //    if (FindInterface(type, interfaceTypeGuid, nonInheritedInterface))
//        //        return true;
//        //    return false;
//        //}

//        public virtual bool FindInterface(AppType type, Guid interfaceTypeGuid, bool nonInheritedInterface)
//        {
//            var currentInterfaces = type.ItSelfInterfaces;
//            for (int cii = 0; cii < currentInterfaces.Count; cii++)
//            {
//                var currentInterface = currentInterfaces[cii];
//                if (currentInterface.TypeGuid == interfaceTypeGuid)
//                    return true;

//            }
//            return false;
//        }

//        //public bool TryFindTypeHaveMetaTagAttribute(out Lis> attributedTypes)
//        //{
//        //    var allTypes = GetAllAppTypes();
//        //    attributedTypes = new Dictionary<Type, List<Attribute>>();
//        //    for (int ti = 0; ti < allTypes.Length; ti++)
//        //    {
//        //        var currentType = allTypes[ti];
//        //        for (var ii = 0; ii < _appMetaTagTypes.Count; ii++)
//        //        {
//        //            var currentMetaTag = _appMetaTagTypes[ii];
//        //            var currentTypeAttributes = currentType.GetCustomAttributes(EnableFindInhritedMetaAttributes);
//        //            currentTypeAttributes.Where(o => o.GetType().GUID.CompareTo(currentMetaTag.GUID) == 0).ToList();
//        //            if (currentTypeAttributes.Length > 0)
//        //            {
//        //                var attributes = currentTypeAttributes.Cast<Attribute>().ToList();
//        //                if (HaveAppAttribute(attributedTypes))
//        //                    attributedTypes.Add(currentType, attributes);
//        //            }
//        //        }
//        //    }
//        //    return attributedTypes.Count > 0;
//        //}
//    }
//}
