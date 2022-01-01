using System;
using DotNetCenter.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.UnitTest
{
    [TestClass]
    public class UTBaseStringModelValue
    {
        #region ToString
        [TestMethod]
        public void ToStringOverridenMethodShouldReturnContentIfItIsValid()
        {
            var content = GetContent();
            BuidTestClass(content, out var testClass);
            Assert.IsTrue(testClass.ToString().Equals(content));
        }
        [TestMethod]
        public void ToStringOverridenMethodShouldThrowNullArgumentExceptionIfItIsNotValid()
        {
            BuidTestClass(string.Empty, out var testClass);
            Assert.ThrowsException<ArgumentNullException>(new Action(() => testClass.ToString()));
        }
        #endregion
        #region HasValue
        [TestMethod]
        public void HasValueMethodShouldReturnTrueIfValueIsNotNullOrEmpty()
        {
            var content = GetContent();
            BuidTestClass(content, out var testClass);
            Assert.IsTrue(testClass.HasValue());
        }
        [TestMethod]
        public void HasValueMethodShouldReturnFalseIfValueIsNullOrEmpty()
        {
            BuidTestClass(string.Empty, out var testClass);
            Assert.IsFalse(testClass.HasValue());
            BuidTestClass(null, out testClass);
            Assert.IsFalse(testClass.HasValue());
        }
        #endregion
        #region IsNullOrEmpty
        [TestMethod]
        public void IsNullOrEmptyMethodShouldReturnFalseIfContentIsNotNullOrEmpty()
        {
            var content = GetContent();
            BuidTestClass(content, out var testClass);
            Assert.IsFalse(testClass.IsNullOrEmpty());
        }
        [TestMethod]
        public void IsNullOrEmptyMethodShouldReturnTrueIfContentIsNullOrEmpty()
        {
            BuidTestClass(string.Empty, out var testClass);
            Assert.IsTrue(testClass.IsNullOrEmpty());
            BuidTestClass(null, out testClass);
            Assert.IsTrue(testClass.IsNullOrEmpty());
        }
        #endregion
        #region TestCase
        private void BuidTestClass(string content, out TestClass testClass)
            => testClass = new TestClass(content);
        private static string GetContent()
        {
            string content = CuidGenerator.NewCuid();
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException(content);
            return content;
        }
        class TestClass : BaseStringModelValue
        {
            public TestClass(string content)
                : base(content)
            { }
        }
        #endregion
    }
}
