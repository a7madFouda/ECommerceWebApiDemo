using ECommerceWebAPI.Application.Services.Customers.DTOs;
using ECommerceWebAPI.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Customers.Commands
{
    public class CreateCustomerCommand:IRequest<Customer>
    {
        public CreateCustomerDTO customer {  get; set; }
    }
}
