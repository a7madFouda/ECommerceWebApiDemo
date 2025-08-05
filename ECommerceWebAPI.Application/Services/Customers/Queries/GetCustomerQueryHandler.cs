using AutoMapper;
using ECommerceWebAPI.Application.Services.Customers.DTOs;
using ECommerceWebAPI.Domain.Interfaces;
using ECommerceWebAPI.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Customers.Queries
{
    public class GetCustomerQueryHandler:IRequestHandler<GetCustomerQuery,GetCustomerDTO>
    {
        private readonly IBaseRepository<Customer> _baseRepository;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IBaseRepository<Customer> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomerDTO> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            var customer = await _baseRepository.GetByIdAsync(query.Id);
            var customerDto = _mapper.Map<GetCustomerDTO>(customer);
            return customerDto;
        }
    }
}
