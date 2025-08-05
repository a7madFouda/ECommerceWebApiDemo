using ECommerceWebAPI.Domain.Enums;
using ECommerceWebAPI.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Domain.Models.Entities
{
    public class Order:BaseModel
    {
        public OrderStatus Status { get; set; }
        public double Total_Price { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
