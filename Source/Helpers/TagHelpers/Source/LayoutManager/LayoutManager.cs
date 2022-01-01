using DotNetCenter.Core;
using Microsoft.AspNetCore.Http;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    //Design Patterns - Business Delegate Pattern
    //Delegate
    public class LayoutManager : ILayoutManager
    {

        public LayoutManager(ILayoutManagerOptionProvider provider, IHttpContextAccessor httpContextAccessor)
        {
            Provider = provider;
            HttpContextAccessor = httpContextAccessor;
        }

        public HtmlTagAttrId LayoutContainerId => Options.LayoutGeneratorOutput.LayoutContainerId;
        public HtmlTagAttrId LayoutFormId => Options.LayoutGeneratorOutput.LayoutFormId;
        public Guid Key => Options.LayoutGeneratorOutput.Key;
        public ILayoutManagerOptionProvider Provider { get; }

        //?????
        public IHttpContextAccessor HttpContextAccessor { get; }
        public ILayoutManagerOption Options { get => _options; }
        private LayoutManagerOption _options;

        private bool IsOptionsLoaded()
            => Options is not null;

        private bool isOptionsLoaded;

        //Read Factory and Builder Pattern
        public virtual ILayoutString GetLayoutString()
        {
            if (!IsOptionsLoaded())
                throw new NullReferenceException($"Loaded Options before use it. <{nameof(LayoutGeneratorOption)}>.");


            if (Options?.LayoutGeneratorOutput?.RuntimeLayoutGenerator is null)
                throw new NullReferenceException(nameof(LayoutGeneratorOutput.RuntimeLayoutGenerator));

            if (!Options.LayoutGeneratorOutput.RuntimeLayoutGenerator.IsReadyToPresent)
                throw new Exception(nameof(LayoutGeneratorOutput.RuntimeLayoutGenerator.MakeReadyToPresent));

            return Options.LayoutGeneratorOutput.RuntimeLayoutGenerator.GetLayoutString();
        }

        public void LoadOptions(
                                TagHelperStates tagHelperState
                                ,BindingApiOption bindingApiOption
            )
        {
            isOptionsLoaded = false;
            if (bindingApiOption is null)
                throw new ArgumentNullException(nameof(bindingApiOption));

            _options = Provider.GetOptions(bindingApiOption,
                                                        tagHelperState
                                                        );
            isOptionsLoaded = true;
        }

        public virtual bool SaveLayoutFile()
            => true;
    }
}
