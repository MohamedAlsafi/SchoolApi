using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entites
{
    public class Ins_Subject : BaseEntity
    {   
        public int instructorId { get; set; }
        public int SubjectId { get; set; }

        [ForeignKey(nameof(instructorId))]
        public Instructor? instructor { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject? Subject { get; set; }
    }
}
