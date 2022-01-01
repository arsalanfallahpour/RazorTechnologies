//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace RazorTechnologies.Core.Common.Services
//{
//    public class VieModelTypeResolverService : BaseTypeResolverService
//    {
//        /// <summary>
//        /// Initialize For Find types in current assembly
//        /// </summary>
//        /// <param name="assembly"></param>
//        public AppMenuItemTypeResolverService()
//            : base(Assembly.GetExecutingAssembly())
//        {
//            GUIDIntAppMenuItem = typeof(IAppMenuItem).GUID;
//            GUIDIntAppMenuItemReport = typeof(IAppMenuItemReport).GUID;
//            GUIDIntAppMenuItemWizard = typeof(IAppMenuItemWizard).GUID;
//            GUIDIntAppMenuItemList = typeof(IAppMenuItemList).GUID;
//            GUIDAppForm = typeof(IAppForm).GUID;
//            GUIDAppUserControl = typeof(IAppUserControl).GUID;
//            GUIDIntAppMenuItemReportForm = typeof(IAppMenuItemReportForm).GUID;
//            _appMenuItems = new AppMenuItemList();
//            GetAllPotentialTypes();
//        }

//        public readonly Guid GUIDIntAppMenuItem;
//        public readonly Guid GUIDIntAppMenuItemReport;
//        public readonly Guid GUIDIntAppMenuItemWizard;
//        public readonly Guid GUIDAppForm;
//        public readonly Guid GUIDAppUserControl;
//        public readonly Guid GUIDIntAppMenuItemList;
//        public readonly Guid GUIDIntAppMenuItemReportForm;
//        public AppMenuItemList AppMenuItems { get { return _appMenuItems; } }
//        private readonly AppMenuItemList _appMenuItems;


//        public readonly Guid GUIDIntAppMenuItemWizardForm;

//        public bool TryGetTotalTypes(Guid typeGuid, out AppMenuPresentationTypes appMenuPresentationTypes, out AppMenuItemTypes appMenuItemTypes)
//        {
//            appMenuPresentationTypes = AppMenuPresentationTypes.None;
//            appMenuItemTypes = AppMenuItemTypes.None;

//            if(!TryGetPresentationType(typeGuid, out appMenuPresentationTypes))
//                return false;
//            if(!TryGetMenuItemType(typeGuid, out appMenuItemTypes))
//                return false;
//            return true;
//        }
//        public bool TryGetPresentationType(Guid typeGuid, out AppMenuPresentationTypes appMenuPresentationTypes)
//        {
//            var type = GetType(typeGuid);
//            appMenuPresentationTypes = AppMenuPresentationTypes.None;

//            if(type == null)
//                return false;

//            var appType = new AppType(type);
//            if(IsItUserControl(appType))
//                appMenuPresentationTypes = AppMenuPresentationTypes.UserControl;
//            else if(IsItForm(appType))
//                appMenuPresentationTypes = AppMenuPresentationTypes.Form;
//            else
//                appMenuPresentationTypes = AppMenuPresentationTypes.None;

//            return appMenuPresentationTypes != AppMenuPresentationTypes.None;
//        }
//        public bool TryGetMenuItemType(Guid typeGuid, out AppMenuItemTypes appMenuItemTypes)
//        {
//            var type = GetType(typeGuid);
//            appMenuItemTypes = AppMenuItemTypes.None;
//            if(type == null)
//                return false;

//            var appType = new AppType(type);
//            if(IsItMenuItemWizard(appType))
//                appMenuItemTypes = AppMenuItemTypes.Wizard;
//            else if(IsItMenuItemReport(appType) || IsItMenuItemReportForm(appType))
//                appMenuItemTypes = AppMenuItemTypes.Report;
//            else if(IsItMenuItemList(appType))
//                appMenuItemTypes = AppMenuItemTypes.List;
//            else
//                appMenuItemTypes = AppMenuItemTypes.None;

//            return appMenuItemTypes != AppMenuItemTypes.None;
//        }
//        public bool IsItMenuItem(AppType type, bool justItself = false)
//        {
//            return type.FindInterface(GUIDIntAppMenuItem, justItself);
//        }
//        public bool IsItForm(AppType type, bool justItself = false)
//        {
//            return type.FindInterface(GUIDAppForm, justItself);
//        }
//        public bool IsItForm(AppMenuItem menuItem)
//        {
//            return menuItem.PresentationType == AppMenuPresentationTypes.Form;
//        }
//        public bool IsItUserControl(AppType type, bool justItself = false)
//        {
//            return type.FindInterface(GUIDAppUserControl, justItself);
//        }
//        public bool IsItUserControl(AppMenuItem menuItem)
//        {
//            return menuItem.PresentationType == AppMenuPresentationTypes.UserControl;

//        }
//        public bool IsItMenuItemWizard(AppType type, bool justItself = false)
//        {
//            return type.FindInterface(GUIDIntAppMenuItemWizard, justItself);
//        }
//        //public bool IsItMenuItemWizard(AppMenuItem menuItem)
//        //{
//        //    return menuItem.MenuItemType == AppMenuItemTypes.Wizard;
//        //}
//        //public bool IsItMenuItemReport(AppMenuItem menuItem)
//        //{
//        //    return menuItem.MenuItemType == AppMenuItemTypes.Report;
//        //}
//        public bool IsItMenuItemReport(AppType type, bool justItself = false)
//        {
//            return type.FindInterface(GUIDIntAppMenuItemReport, justItself);
//        }
//        public bool IsItMenuItemReportForm(AppType type, bool justItself = false)
//        {
//            return type.FindInterface(GUIDIntAppMenuItemReportForm, justItself);
//        }
//        //public bool IsItMenuItemReportForm(AppMenuItem menuItem)
//        //{
//        //    return menuItem.MenuItemType == AppMenuItemTypes.Report;
//        //}
//        //public bool IsItMenuItemList(AppMenuItem menuItem)
//        //{
//        //    return menuItem.MenuItemType == AppMenuItemTypes.List;
//        //}
//        public bool IsItMenuItemList(AppType type, bool justItself = false)
//        {
//            return type.FindInterface(GUIDIntAppMenuItemList, justItself);
//        }
//        //public bool IsTypeExistInAppTypes(AppType findoutType, AppMenuItemTypes menuItemType)
//        //{
//        //    return _appMenuItems.Any(o => o.IsExactSameWith(findoutType) && o.MenuItemType == menuItemType);
//        //}
//        //public bool IsTypeExistInAppTypes(AppType findoutType, AppMenuItemTypes menuItemType, AppMenuPresentationTypes presentationType)
//        //{
//        //    return _appMenuItems.Any(o => o.IsExactSameWith(findoutType) && o.MenuItemType == menuItemType && o.PresentationType == presentationType);
//        //}
//        //public bool IsTypeExistInAppTypes(Guid findoutTypeGuid)
//        //{
//        //    return _appMenuItems.Any(o => o.TypeGuid == findoutTypeGuid);
//        //}
//        //public bool IsTypeExistInAppTypes(AppType findoutType)
//        //{
//        //    return _appMenuItems.Any(o => o.IsExactSameWith(findoutType));
//        //}
//        //public bool IsTypeExistInAppTypes(AppType findoutType, AppMenuPresentationTypes presentationType)
//        //{
//        //    return _appMenuItems.Any(o => o.IsExactSameWith(findoutType) && o.PresentationType == presentationType);
//        //}
//        public AppMenuPresentationTypes GetPresentationType(Type presentationType)
//        {
//            if(presentationType.GUID == GUIDAppUserControl)
//                return AppMenuPresentationTypes.UserControl;

//            if(presentationType.GUID == GUIDAppForm)
//                return AppMenuPresentationTypes.Form;

//            return AppMenuPresentationTypes.None;
//        }
//        public bool IsTypeExistInAppTypes(Guid findoutTypeGuid, AppMenuItemTypes menuItemType, AppMenuPresentationTypes presentationType)
//        {
//            return _appMenuItems.Any(o => o.TypeGuid == findoutTypeGuid && o.MenuItemType == menuItemType && o.PresentationType == presentationType);
//        }
//        public bool IsTypeExistInAppTypes(Guid findoutTypeGuid, AppMenuItemTypes menuItemType)
//        {
//            return _appMenuItems.Any(o => o.TypeGuid == findoutTypeGuid && o.MenuItemType == menuItemType);
//        }
//        public bool IsTypeExistInAppTypes(Guid findoutTypeGuid, AppMenuPresentationTypes presentationType)
//        {
//            return _appMenuItems.Any(o => o.TypeGuid == findoutTypeGuid && o.PresentationType == presentationType);
//        }
//        public AppMenuItemList GetAllPotentialTypes()
//        {
//            if(_appMenuItems.Count > 0)
//                return _appMenuItems;

//            var types = GetAllPotentialAppTypes();
//            var ignoredFiles = new List<Type>
//            {
//                //typeof(BaseMasterDetailUI),
//                //typeof(FrmSearch),

//            };

//            for(int ti = 0; ti < types.Count; ti++)
//            {
//                var currentType = types[ti];
//                AppMenuPresentationTypes presentationType;
//                AppMenuItemTypes menuItemType;

//                if(TryGetTotalTypes(currentType.TypeGuid, out presentationType, out menuItemType))
//                    _appMenuItems.AddItem(BuildMenuItem(currentType, presentationType, menuItemType));
//            }

//            return _appMenuItems;
//        }

//        private AppMenuItem BuildMenuItem(AppType currentType, AppMenuPresentationTypes presentationType, AppMenuItemTypes menuItemType)
//        {
//            return new AppMenuItem(currentType, menuItemType, presentationType);
//        }
//        public override List<AppType> GetAllPotentialAppTypes()
//        {
//            if(PotentialAppType.Count > 0)
//                return PotentialAppType;

//            var types = GetAllAppTypes();
//            var ignoredFiles = new List<Type>
//            {
//                //typeof(BaseMasterDetailUI),
//                //typeof(FrmSearch),

//            };

//            for(int ti = 0; ti < types.Length; ti++)
//            {
//                var currentType = types[ti];
//                var currentAppType = new AppType(currentType);
//                if(IsItMenuItem(currentAppType) && !ignoredFiles.Any(o => o.Name == currentType.Name))
//                    AddPotentialAppType(currentAppType);
//            }
//            return PotentialAppType;
//        }
//        public string GetItemPresentationTypePersianTitle(AppMenuPresentationTypes presentationType)
//        {
//            switch(presentationType)
//            {
//                case AppMenuPresentationTypes.None:
//                    throw new NotSupportedException();
//                case AppMenuPresentationTypes.Form:
//                    return "فرم" + " | " + AppMenuPresentationTypes.Form;
//                case AppMenuPresentationTypes.UserControl:
//                    return "کنترل کاربری" + " | " + AppMenuPresentationTypes.UserControl;
//                default:
//                    throw new NotSupportedException();
//            }
//        }
//        public string GetItemTypePersianTitle(AppMenuItemTypes menuItemType)
//        {
//            switch(menuItemType)
//            {
//                case AppMenuItemTypes.None:
//                    throw new NotSupportedException();
//                case AppMenuItemTypes.Wizard:
//                    return "ویزارد" + " | " + AppMenuItemTypes.Wizard;
//                case AppMenuItemTypes.Report:
//                    return "گزارش" + " | " + AppMenuItemTypes.Report;
//                case AppMenuItemTypes.List:
//                    return "لیست" + " | " + AppMenuItemTypes.List;
//                default:
//                    throw new NotSupportedException();
//            }
//        }
//        public bool GetTypeByGuid(Guid typeGuid, out AppMenuItem appMenuItem)
//        {
//            return _appMenuItems.GetItem(typeGuid, out appMenuItem);
//        }
//        public bool GetTypeByGuid(string typeName, out AppMenuItem appMenuItem)
//        {
//            return _appMenuItems.GetItem(typeName, out appMenuItem);
//        }
//        public bool GetTypeByNameInNamespace(string typeName, string @namespace, out AppMenuItem appMenuItem)
//        {
//            return _appMenuItems.GetItem(typeName, @namespace, out appMenuItem);
//        }
//    }
//}

//}
