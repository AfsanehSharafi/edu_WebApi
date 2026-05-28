using Application.Dtos;
using MediatR;

namespace Application.Features.Categories.Requests.Queries
{
    public class GetCategoryDetailRequest:IRequest<CategoryDto?>
    {
        public int Id { get; set; }
    }
}
