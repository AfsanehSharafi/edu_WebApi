using Application.Dtos.OrderItems;
using MediatR;

namespace Application.Features.Orders.Requests.Commands
{
    public class CreateOrderCommand:IRequest<int>
    {
        public int UserId { get; set; }
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
