using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Application.Services.Orders.DTOs
{
    public class GetOrderDTO
    {
        public int Order_ID { get; set; }
        public string Customer_Name { get; set; }   
        public string Status_Name { get; set; }   
        public int Products_Count { get; set; }   
    }
}
