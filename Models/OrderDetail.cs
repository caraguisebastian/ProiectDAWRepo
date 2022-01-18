using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class OrderDetail: BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
