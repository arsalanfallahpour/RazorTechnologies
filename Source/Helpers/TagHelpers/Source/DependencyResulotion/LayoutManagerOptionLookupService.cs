using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using System;
using RazorTechnologies.TagHelpers.LayoutManager;
using System.Linq;
using RazorTechnologies.TagHelpers.Common;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public class LayoutManagerOptionLookupService : ILayoutManagerOptionLookupService
    {
        public ILayoutManagerOptionsCollection OptionsCollection => _optionsCollection;
        private readonly LayoutManagerOptionsCollection _optionsCollection;
        public LayoutManagerOptionLookupService(LayoutManagerOptionsCollection optionsCollection)
        {
            _optionsCollection = optionsCollection ?? throw new System.ArgumentNullException(nameof(optionsCollection));
        }

        public LayoutManagerOption LookupFor(TagHelperStates tagHelperState
                                                 ,BindingApiOption bindingApiOption
                                                 //,LayoutHeaderData layoutHeaderData
                                                 //HtmlTagContent submitButtonContent
            )
        {
            var filtredList = _optionsCollection.Where(o => o.ApiType == tagHelperState && o.BindingApiOption == bindingApiOption).ToList();
            if (filtredList is null || filtredList.Count < 1)
                throw new NullReferenceException($"Layout Manager {bindingApiOption.ControllerName}.{bindingApiOption.ActionName} is not initialized. register the LayoutApi to app startup class service configurations.");

            if (filtredList.Count > 1)
                throw new NotSupportedException($"Layout Manager {bindingApiOption.ControllerName}.{bindingApiOption.ActionName} registred more than.");

            var option = filtredList[0];
            //options.SetLayoutHeaderData(layoutHeaderData);
            return option;
        }
    }
}