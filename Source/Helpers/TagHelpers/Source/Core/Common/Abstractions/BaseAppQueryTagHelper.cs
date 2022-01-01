namespace RazorTechnologies.TagHelpers.Core
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using RazorTechnologies.Core.Common;
    using RazorTechnologies.TagHelpers.Core.Attr;
    using RazorTechnologies.TagHelpers.Core.BindingGateway;
    using RazorTechnologies.TagHelpers.Core.THelper;
    using RazorTechnologies.TagHelpers.Core.ViewModel;
    using RazorTechnologies.TagHelpers.LayoutManager;
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public abstract class BaseQueryTagHelper<TQeuryViewModel>
        : BaseAppTagHelper, IQueryTagHelper
        where TQeuryViewModel : BaseQueryViewModel
    {
        public BaseQueryTagHelper(ILayoutManager layoutManager)
            : base(layoutManager)
        {
            LayoutManager = layoutManager;
            //ApplyAdditionalAttributes(RequestViewModel, QueryViewModelType);

            //_filtredRequestViewModelProperties = _allRequestViewModelProperties.Where(o =>
            //!HaveAttribute(SearchMemberMethods.RootMembers, QueryViewModelType, o.Name, IgnoreAttributeType, false)
            //&& !HaveAttribute(SearchMemberMethods.RootMembers, QueryViewModelType, o.Name, AppDataViewLableAttributeType, false)
            ////&& !HaveAttribute(SearchMemberMethods.RootMembers, QueryViewModelType, o.Name, AppHyperLinkElementAttributeType, false)
            //).ToArray();
        }
        public override TagHelperStates TagHelperState => TagHelperStates.Readonly;
        public ILayoutManager LayoutManager { get; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.PostContent.SetHtmlContent(LayoutManager.GetLayoutString().Content);
            return base.ProcessAsync(context, output);
        }
    }
}
