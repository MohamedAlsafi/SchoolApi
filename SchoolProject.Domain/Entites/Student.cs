using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class Student : BaseEntity
    {
        
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string  Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public  Department Department { get; set; }
    }
}
