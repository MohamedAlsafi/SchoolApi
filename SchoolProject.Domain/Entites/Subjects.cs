using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class Subject : BaseEntity
    {
        [StringLength(500)]
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int? Period { get; set; }
        public  ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();
        public  ICollection<DepartmentSubject> DepartmetsSubjects { get; set; } = new HashSet<DepartmentSubject>();
        public  ICollection<Ins_Subject> Ins_Subjects { get; set; } = new HashSet<Ins_Subject>();
    }
}
