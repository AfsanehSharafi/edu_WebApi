using Application.Dtos.Categories;
using MediatR;

namespace Application.Features.Categories.Requests.Queries
{
    public class GetCategoryListRequest:IRequest<List<CategoryDto>>
    {

    }
}
