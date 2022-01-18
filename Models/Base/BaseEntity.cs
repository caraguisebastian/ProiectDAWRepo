using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.Base
{
    public class BaseEntity: IBaseEntity
    {
        [Key]
        //Generates a value when row is inserted
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DateCreated { get; set; }

        //Generates a value when row is updated or created
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }

        //Doesn't generate any value
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    }
}
