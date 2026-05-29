using Application.Contracts;
using Application.Features.Orders.Requests.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Orders.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IOrderItemsRepository orderItemsRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            ILogger<CreateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateOrderCommand for UserId: {UserId}", request.UserId);
            if(request.Items == null || request.Items.Count == 0)
            {
                _logger.LogWarning("CreateOrderCommand failed: order must have at least one item. UserId: {UserId}", request.UserId); ;
                throw new ArgumentException("Order must have at least one item");
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if(user == null)
            {
                _logger.LogError("CreateOrderCommand failed: User with ID {UserId} not found.", request.UserId);
                throw new KeyNotFoundException($"User with ID {request.UserId} not Found.");
            }
        }
    }
}
