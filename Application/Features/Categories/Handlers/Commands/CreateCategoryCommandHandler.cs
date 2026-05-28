using Application.Contracts;
using Application.Features.Categories.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var catecory = new Category
            {
                Name = request.Name,
                Description = request.Description
            };
            await _categoryRepository.AddAsync(catecory);
            return catecory.Id;
        }
    }
}
