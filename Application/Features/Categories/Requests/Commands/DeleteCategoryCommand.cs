using MediatR;

namespace Application.Features.Categories.Requests.Commands
{
    public class DeleteCategoryCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
