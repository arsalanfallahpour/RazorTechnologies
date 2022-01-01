using System;
using DotNetCenter.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.UnitTest
{
    [TestClass]
    public class UTHtmlTagName
    {
        #region TranslateToIdSyntax
        [TestMethod]
        public void TranslateToIdSyntaxMethodShouldReturnHtmlTagIdWithSameContentWithoutDot()
        {
            var content = GetContent();
            BuidTestClass(content, out var testClass);
            Assert.AreEqual(
                            testClass.ToString().Replace('.', '_'),
                            testClass.TranslateToIdSyntax().ToString());
        }
        #endregion
        #region TestCase
        private void BuidTestClass(string content, out TestClass testClass)
            => testClass = new TestClass(content);
        private static string GetContent()
        {
            string content = "Test.Case.Class.Name";
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException(content);
            return content;
        }
        class TestClass : HtmlTagAttrName
        {
            public TestClass(string content)
                : base(content)
            { }
        }
        #endregion
    }
}
