using MediatR;

namespace Application.Features.Categories.Requests.Commands
{
    public class UpdateCategoryCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
