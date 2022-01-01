using System;
using DotNetCenter.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;

namespace RazorTechnologies.TagHelpers.UnitTest
{
    [TestClass]
    public class UTEnumerations
    {
        #region CheckEnumerationCompatiblity
        [TestMethod]
        public void LayoutTypesEnumerationMembersShouldProvideSameValuesWithTagHelperStatesEnum()
        {
            var value = TagHelperStates.Create;
            var expected = (LayoutTypes)value;
            var actual = LayoutTypes.Creatable;
            Assert.AreEqual(actual , expected);

            value = TagHelperStates.Update;
            expected = (LayoutTypes)value;
            actual = LayoutTypes.Modifiable;
            Assert.AreEqual(
                     actual,
                     expected);
            value = TagHelperStates.Delete;
            expected = (LayoutTypes)value;
            actual = LayoutTypes.Removable;

            Assert.AreEqual(
                     actual,
                     expected);
            value = TagHelperStates.Readonly;
            expected = (LayoutTypes)value;
            actual = LayoutTypes.JustReadable;
            Assert.AreEqual(
                     actual,
                     expected);
        }
        [TestMethod]
        public void TagHelperStatesEnumerationMembersShouldProvideSameValuesWithApiTypesEnum()
        {
            var value = ApiTypes.Create;
            var expected = (TagHelperStates)value;
            var actual = TagHelperStates.Create;
            Assert.AreEqual(
                            actual,
                            expected);
            value = ApiTypes.Update;
            expected = (TagHelperStates)value;
            actual = TagHelperStates.Update;
            Assert.AreEqual(
                     actual,
                     expected);
            value = ApiTypes.Delete;
            expected = (TagHelperStates)value;
            actual = TagHelperStates.Delete;

            Assert.AreEqual(
                     actual,
                     expected);

            value = ApiTypes.Read;
            expected = (TagHelperStates)value;
            actual = TagHelperStates.Readonly;
            Assert.AreEqual(
                     actual,
                     expected);
        }

        #endregion
    }
}
