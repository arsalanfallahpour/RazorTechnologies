namespace RazorTechnologies.TagHelpers.Core.Annotations
{
    public interface ImplicitValidationAttribute
    {
        public bool ApplyValdiation{ get; }
        public void SetApplyValidation(bool apply);
    }
}