using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.DTO
{
    public class AddressDTO
    {
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
    }
}
