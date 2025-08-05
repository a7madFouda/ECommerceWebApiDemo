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
    public class GetCustomerListQueryHandler:IRequestHandler<GetCustomerListQuery,List<GetCustomerDTO>>
    {

        private readonly IBaseRepository<Customer> _baseRepository;
        private readonly IMapper _mapper;
        public GetCustomerListQueryHandler(IBaseRepository<Customer> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<List<GetCustomerDTO>> Handle(GetCustomerListQuery query, CancellationToken cancellationToken)
        {
            var customers = await _baseRepository.GetAllAsync();
            var customersDto = _mapper.Map<List<GetCustomerDTO>>(customers);
            return customersDto;
        }
    }
}
