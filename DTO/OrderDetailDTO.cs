using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.DTO
{
    public class OrderDetailDTO
    {
        [Required]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

    }
}
