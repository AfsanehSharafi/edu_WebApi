using Application.Dtos.Categories;
using MediatR;

namespace Application.Features.Categories.Requests.Queries
{
    public class GetCategoryDetailRequest:IRequest<CategoryDto?>
    {
        public int Id { get; set; }
    }
}
