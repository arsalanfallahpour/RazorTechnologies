using MediatR;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public interface IMediatableLayoutControl
    {
        public IMediator Mediator{ get; }
    }
}