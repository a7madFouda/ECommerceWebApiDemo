using AutoMapper;
using ECommerceWebAPI.Application.Services.Orders.DTOs;
using ECommerceWebAPI.Domain.Interfaces;
using ECommerceWebAPI.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.Commands
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand,int>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IBaseRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(
            IBaseRepository<Order> repository,
            IBaseRepository<Product> productRepository,
            IBaseRepository<Customer> customerRepository,
            IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Order.Customer_ID);

            if (customer == null)
            {
                throw new Exception($"No customer with id : {request.Order.Customer_ID}");
            }
            CreateOrderDTO orderDTO = request.Order;

            var orderProducts = await _productRepository.FindAsync(x => orderDTO.Product_IDs.Contains(x.Id));

            if (orderProducts == null || !orderProducts.Any())
            {
                throw new Exception("No valid products in the order");
            }

            List<OrderProduct> orderProductsList = new List<OrderProduct>();

            foreach (var orderProduct in orderProducts)
            {
                OrderProduct newOrderProduct = new OrderProduct()
                {
                    ProductId = orderProduct.Id
                };
                orderProductsList.Add(newOrderProduct);
            }

            Order order = new Order()
            {
                Customer_ID = orderDTO.Customer_ID,
                OrderProducts = orderProductsList,
                Total_Price = orderProducts.Select(x => x.Price).Sum()
            };
            await _repository.InsertAsync(order);
            await _repository.SaveChangesAsync();
            return order.Id;
        }
    }
}
