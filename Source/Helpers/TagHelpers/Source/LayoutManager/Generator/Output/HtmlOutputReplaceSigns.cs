using System.Collections.Generic;
using System.Linq;

namespace RazorTechnologies.TagHelpers.LayoutManager.Generator.Output
{
    public class HtmlOutputReplaceSigns
    {
        public HtmlOutputReplaceSigns(int parentAppendIndex)
        {
            ParentAppendIndex = parentAppendIndex;
        }
        private readonly Dictionary<string, int> ReplaceSignsCollection = new Dictionary<string, int>();
        public int ParentAppendIndex { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName">FullName means <ApiName.ApiParameterName.DataPropertyName></param>
        /// <returns></returns>

        public bool AddReplaceSing(string fullName, int replaceIndex)
        {
            if (ReplaceSignsCollection.Any(o=>o.Key == fullName))
                return false;
            ReplaceSignsCollection.Add(fullName, replaceIndex);
            return true;
        }

    }
}