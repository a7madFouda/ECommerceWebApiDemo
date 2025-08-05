using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.DTOs
{
    public class CreateOrderDTO
    {
        public int Customer_ID { get; set; }
        public List<int> Product_IDs { get; set; } = new List<int>();
    }
}
