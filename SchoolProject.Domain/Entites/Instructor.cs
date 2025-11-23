using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class Instructor : BaseEntity
    {
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }
        public int? SupervisorId { get; set; }

        public int DepartmentId { get; set; }


        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        [InverseProperty(nameof(Department.InstructorManager))]
        public Department? DepartmentManaged { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        // Self-reference: Supervisor / Subordinates
        [InverseProperty(nameof(Instructor.Subordinates))]  
        public Instructor? Supervisor { get; set; }

        // collection of instructors who have this as Supervisor
        [InverseProperty(nameof(Instructor.Supervisor))]
        public ICollection<Instructor> Subordinates { get; set; } = new HashSet<Instructor>();
        public  ICollection<Ins_Subject> Ins_Subjects { get; set; } = new HashSet<Ins_Subject>();




    }
}
