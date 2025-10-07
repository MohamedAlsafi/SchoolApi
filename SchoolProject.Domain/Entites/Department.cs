using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class Department : BaseEntity
    {
     

        [StringLength(500)]
        public string Name { get; set; }
        public  ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public  ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmentSubject>(); 
      
    }
}
