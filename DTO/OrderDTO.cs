using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.DTO
{
    public class OrderDTO
    {
        [Required]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
    }
}
