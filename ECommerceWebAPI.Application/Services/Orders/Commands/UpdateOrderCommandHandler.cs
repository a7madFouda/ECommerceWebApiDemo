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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IOrderRepository _repository;
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IBaseRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public UpdateOrderCommandHandler(
            IOrderRepository repository,
            IBaseRepository<Product> productRepository,
            IBaseRepository<Customer> customerRepository,
            IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = await _repository.GetOrderWithDetails(request.Id);

            if(order == null)
            {
                throw new Exception("No order exist with this id");
            }

            order.Status = Domain.Enums.OrderStatus.Delivered;

            await _repository.UpdateAsync(order);

            var orderProductsIds = order.OrderProducts.Select(x=>x.ProductId).ToList();

            var products = await _productRepository.FindAsync(x => orderProductsIds.Contains(x.Id));

            foreach (var product in products)
            {
                product.Stock -= 1;
            }

            await _productRepository.UpdateRangeAsync(products);

            await _productRepository.SaveChangesAsync();
            await _repository.SaveChangesAsync();

            return order.Id;
        }
    }
}
