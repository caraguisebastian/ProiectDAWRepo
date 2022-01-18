using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Address: BaseEntity
    {
        public Guid UserId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public virtual User User { get; set; }
    }
}
