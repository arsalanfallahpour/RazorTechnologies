namespace RazorTechnologies.TagHelpers.LayoutManager.Controls
{
    public class LayoutHeaderBreadcrumb : ILayoutHeaderBreadcrumb
    {
        public LayoutHeaderBreadcrumb(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }
}