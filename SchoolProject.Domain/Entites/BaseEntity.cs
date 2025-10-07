using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public bool Deleted { get; set; } = false;

    }
}
