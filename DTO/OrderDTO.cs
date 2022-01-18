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
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
    }
}
