using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.DTO
{
    public class CategoryDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
