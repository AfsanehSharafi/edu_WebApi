using Application.Contracts;
using Application.Dtos.Categories;
using Application.Features.Categories.Requests.Queries;
using MediatR;

namespace Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryDetailRequestHandler : IRequestHandler<GetCategoryDetailRequest, CategoryDto?>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryDetailRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }

        public async Task<CategoryDto?> Handle(GetCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null) 
            {
                return null;
            }

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
            return categoryDto;
        }
    }
}
