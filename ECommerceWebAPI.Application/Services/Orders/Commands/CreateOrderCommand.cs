using ECommerceWebAPI.Application.Services.Customers.DTOs;
using ECommerceWebAPI.Application.Services.Orders.DTOs;
using ECommerceWebAPI.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.Commands
{
    public class CreateOrderCommand:IRequest<int>
    {
        public CreateOrderDTO Order {  get; set; }
    }
}
