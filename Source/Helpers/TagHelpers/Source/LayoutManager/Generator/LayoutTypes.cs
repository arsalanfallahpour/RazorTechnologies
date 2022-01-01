using RazorTechnologies.Core.Common;

namespace RazorTechnologies.TagHelpers.LayoutManager.Generator
{
    public enum LayoutTypes
    {
        Creatable = TagHelperStates.Create,
        Modifiable = TagHelperStates.Update,
        Removable = TagHelperStates.Delete,
        JustReadable = TagHelperStates.Readonly
    }
}