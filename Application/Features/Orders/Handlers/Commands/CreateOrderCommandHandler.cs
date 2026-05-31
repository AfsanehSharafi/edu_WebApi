using Application.Contracts;
using Application.Features.Orders.Requests.Commands;
using Domain.Entities;
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
            if (user == null)
            {
                _logger.LogError("CreateOrderCommand failed: User with ID {UserId} not found.", request.UserId);
                throw new KeyNotFoundException($"User with ID {request.UserId} not Found.");
            }

            decimal totalPrice = 0;
            var orderItemsToAdd = new List<OrderItems>();
            var order = new Order
            {
                UserId= request.UserId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending,
                TotalPrice =0
            };
            foreach( var itemDto in request.Items )
            {
                if(itemDto.Quantity <= 0)
                {
                    _logger.LogWarning("CreateOrderCommand failed: Invalid quantity for ProductId {ProductId}. UserId: {UserId}", itemDto.ProductId, request.UserId);
                    throw new ArgumentException($"Quantity must be greater than zero for Product ID {itemDto.ProductId}.");
                }

                var product = await _productRepository.GetByIdAsync(itemDto.ProductId); ;
                if(product == null)
                {
                    _logger.LogError("CreateOrderCommand failed: Product with ID {ProductId} not found. UserId: {UserId}", itemDto.ProductId, request.UserId);
                    throw new KeyNotFoundException($"Product with ID {itemDto.ProductId} not found.");
                }
                var orderItem = new OrderItems
                {
                    ProductId =itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    Price = product.Price,
                };
                totalPrice += product.Price * itemDto.Quantity;

            }
        }
    }
}
