using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstract
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetStudentsListasync(); 
    }
}
