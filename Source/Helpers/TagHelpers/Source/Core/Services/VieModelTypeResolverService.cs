//using RazorTechnologies.TagHelpers.Core.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.IO;
//using System.Linq;
//using System.Reflection;

//namespace RazorTechnologies.Core.Common.Services
//{
//    public class VieModelTypeResolverService
//    {
//        public Type GetTypeByName(string typeName)
//        {
//            var types = Assembly.GetExecutingAssembly().GetTypes();
//            foreach (var type in types)
//            {
//                if (type.Name == typeName)
//                    return type;
//            }
//            return null;
//        }
//        internal Dictionary<string, Guid> GetAllPotentialTypes()
//        {
//            var types = Assembly.GetExecutingAssembly().GetTypes();
//            var newItems = new Dictionary<string, Guid>();
//            var confilicts = new List<str   ing>();
//            for (int i = 0; i < types.Length; i++)
//            {
//                var sourceType = types[i];
//                    if (IsItViewModel(sourceType) )
//                        if (!newItems.Keys.ToList().Any(o => o == sourceType.Name))
//                            newItems.Add(sourceType.Name, sourceType.GUID);
//            }
//            return newItems;
//        }
//        private bool IsTypeSubClassOf(Type subType, Type parentType)
//        {
//            if (subType.BaseType == null)
//                return false;

//            if (subType.IsSubclassOf(parentType))
//                return true;

//            return IsTypeSubClassOf(subType.BaseType, parentType);
//        }
//        private bool IsItViewModel(Type subType)
//        {
//            if (subType.BaseType == null)
//                return false;

//            var typeObj = subType.GetInterface(typeof(IAppViewModel).Name);
//            if (typeObj != null)
//                return true;

//            return IsItViewModel(subType.BaseType);
//        }

//    }
//}
