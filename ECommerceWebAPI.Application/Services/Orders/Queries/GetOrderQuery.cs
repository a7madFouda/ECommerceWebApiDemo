using ECommerceWebAPI.Application.Services.Customers.DTOs;
using ECommerceWebAPI.Application.Services.Orders.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.Queries
{
    public class GetOrderQuery:IRequest<GetOrderDTO>
    {
        public int Id { get; set; }
    }
}
