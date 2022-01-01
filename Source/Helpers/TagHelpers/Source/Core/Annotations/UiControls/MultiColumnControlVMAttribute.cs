//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RazorTechnologies.TagHelpers.Core.Annotations
//{
//    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
//    abstract class MultiColumnControlVMAttribute : BaseViewModelAttribute
//    {
//        public MultiColumnControlVMAttribute(UiDataLoadingConditions dataLoadingCondition, UiDataLoadingBehaviors dataLoadingBehavior)
//        {
//            _dataLoadingBehavior = dataLoadingBehavior;

//            //if (string.IsNullOrEmpty(filter))
//            //    _dataLoadingCondition = UiDataLoadingConditions.LoadByFilter;
//            //else
//                //_dataLoadingCondition = UiDataLoadingConditions.LoadAll;


//            _dataLoadingCondition = dataLoadingCondition;
//            _dataLoadingBehavior = dataLoadingBehavior;
//            //_filter = filter;
//        }

//        public UiDataLoadingConditions LoadingCondition => _dataLoadingCondition;
//        public UiDataLoadingBehaviors LoadingBehavior => _dataLoadingBehavior;
//        //public  string Filter => _filter;

//        public readonly UiDataLoadingConditions _dataLoadingCondition;
//        public readonly UiDataLoadingBehaviors _dataLoadingBehavior;
//        //public readonly string _filter;
//    }
//}
