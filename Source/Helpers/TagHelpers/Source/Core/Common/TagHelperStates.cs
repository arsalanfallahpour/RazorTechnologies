using RazorTechnologies.TagHelpers.Common;

namespace RazorTechnologies.Core.Common
{
    public enum TagHelperStates
    {
        Create = ApiTypes.Create,
        Update = ApiTypes.Update,
        Delete = ApiTypes.Delete,
        Readonly = ApiTypes.Read
    }
}