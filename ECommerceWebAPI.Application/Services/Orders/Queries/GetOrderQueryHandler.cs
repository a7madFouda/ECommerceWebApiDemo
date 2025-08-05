using AutoMapper;
using ECommerceWebAPI.Application.Services.Customers.DTOs;
using ECommerceWebAPI.Application.Services.Orders.DTOs;
using ECommerceWebAPI.Domain.Interfaces;
using ECommerceWebAPI.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.Queries
{
    public class GetOrderQueryHandler:IRequestHandler<GetOrderQuery,GetOrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<GetOrderDTO> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithDetails(query.Id);
            if (order == null) return null;
            var orderDto = new GetOrderDTO()
            {
                Order_ID = order.Id,
                Customer_Name = order.Customer.Name,
                Status_Name = order.Status.ToString(),
                Products_Count = order.OrderProducts.Count
            };
            return orderDto;
        }
    }
}
