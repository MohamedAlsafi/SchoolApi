using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class DepartmentSubject : BaseEntity
    {
        
        public int DepartmentID { get; set; }
        public int SubjectID { get; set; }

        [ForeignKey("DepartmentID")]
        public  Department Department { get; set; }

        [ForeignKey("SubjectID")]
        public  Subject Subjects { get; set; }
    }
}
