using AutoMapper;
using ECommerceWebAPI.Domain.Interfaces;
using ECommerceWebAPI.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Customers.Commands
{
    public class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommand,Customer>
    {
        private readonly IBaseRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(IBaseRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = _mapper.Map<Customer>(request.customer);
            await _repository.InsertAsync(customer);
            await _repository.SaveChangesAsync();
            return customer;
        }
    }
}
