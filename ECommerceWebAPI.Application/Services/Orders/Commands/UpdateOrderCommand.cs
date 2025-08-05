using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.Commands
{
    public class UpdateOrderCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
