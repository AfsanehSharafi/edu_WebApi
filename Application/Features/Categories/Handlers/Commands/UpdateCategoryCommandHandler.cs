using Application.Features.Categories.Requests.Commands;
using MediatR;

namespace Application.Features.Categories.Handlers.Commands
{
    internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        public Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
