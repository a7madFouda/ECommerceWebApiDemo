using ECommerceWebAPI.Application.Services.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Customers.Queries
{
    public class GetCustomerListQuery:IRequest<List<GetCustomerDTO>>
    {
    }
}
