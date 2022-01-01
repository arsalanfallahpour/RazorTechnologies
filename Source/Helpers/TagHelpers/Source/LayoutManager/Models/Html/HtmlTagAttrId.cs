using System;

using DotNetCenter.Core;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagAttrId : HtmlTagAttribute, IHtmlTagAttrId
    {
        /// <summary>
        /// Used for custom id
        /// </summary>
        /// <param name="tagId">Custom Id</param>
        public HtmlTagAttrId(string tagId)
        : base(tagId)
        { }

        /// <summary>
        /// Used for uniqueId
        /// </summary>
        /// <param name="length">Unique Id length</param>
        public HtmlTagAttrId(byte length = 7)
        : base($"i{CuidGenerator.NewCuid(length)}")
        { }

        public override string AttributeName => "id";
    }
}