using Application.Contracts;
using Application.Dtos.Categories;
using Application.Features.Categories.Requests.Queries;
using MediatR;

namespace Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categories =await _categoryRepository.GetAllAsync();
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                Id=c.Id,
                Name=c.Name,
                Description=c.Description,
            }).ToList();
            return categoryDtos;
        }
    }
}
