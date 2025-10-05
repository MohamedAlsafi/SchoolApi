using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class Subject
    {
     
        [Key]
        public int ID { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public DateTime Period { get; set; }
        public  ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();
        public  ICollection<DepartmentSubject> DepartmetsSubjects { get; set; } = new HashSet<DepartmentSubject>();

       
    }
}
