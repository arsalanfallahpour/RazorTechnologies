using Microsoft.AspNetCore.Html;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Common;
using RazorTechnologies.TagHelpers.Core.Api;
using RazorTechnologies.TagHelpers.Core.Attr;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.ViewModel;
using RazorTechnologies.TagHelpers.DependencyResulotion;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    //Singleton
    //Build Options in DIC ConfigureServices
    public class LayoutGeneratorOptionLookupService : ILayoutGeneratorOptionLookupService
    {
        public LayoutGeneratorOptionLookupService(ILayoutApiWrapper apiWrapper)
        {
            LayoutApiWrapper = apiWrapper ?? throw new System.ArgumentNullException(nameof(apiWrapper));
        }
        public ILayoutApiWrapper LayoutApiWrapper { get; }
        public LayoutGeneratorOption LookupFor(TagHelperStates tagHelperState,
                                                 BindingApiOption bindingApiOption
                                                 //,LayoutHeaderData layoutHeaderData
                                                 //, HtmlTagContent submitButtonContent
            )
        {
            var filtredList = LayoutApiWrapper.LayoutApis.Where(o => o.ApiType == (ApiTypes)tagHelperState && o.BindingApiOption == bindingApiOption).ToList();
            if(filtredList is null || filtredList.Count < 1)
                throw new NullReferenceException($"Layout Api {bindingApiOption.ControllerName}.{bindingApiOption.ActionName} is not initialized. register the LayoutApi to app startup class service configurations.");

            if(filtredList.Count  > 1)
                throw new NotSupportedException($"Layout Api {bindingApiOption.ControllerName}.{bindingApiOption.ActionName} registred more than.");

            var apiModel = filtredList[0];
            var options = new LayoutGeneratorOption(apiModel
                                              //, submitButtonContent
                                              );
            //options..SetLayoutHeaderData(layoutHeaderData);
            return options;
        }
    }
}