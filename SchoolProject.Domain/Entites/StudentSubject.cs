using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class StudentSubject
    {
        [Key]
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }

        [ForeignKey("StudentID")]
        public  Student Student { get; set; }

        [ForeignKey("SubjectID")]
        public  Subject Subject { get; set; }
    }
}
