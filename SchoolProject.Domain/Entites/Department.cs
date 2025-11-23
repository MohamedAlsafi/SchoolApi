using SchoolProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class Department :BaseEntity 
    {
        [StringLength(500)]
        public string NameEn { get; set; }
        public string NameAr{ get; set; }
        public int? IsManger { get; set; }

        [ForeignKey(nameof(IsManger))]
        [InverseProperty(nameof(Instructor.DepartmentManaged))]
        public Instructor InstructorManager { get; set; }
        public  ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public  ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmentSubject>();
        
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
