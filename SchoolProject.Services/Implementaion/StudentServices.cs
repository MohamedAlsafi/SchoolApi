using SchoolProject.Domain.Entites;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementaion
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentReposetory _reposetory;

        public StudentServices(IStudentReposetory reposetory)
        {
            _reposetory = reposetory;
        }
        public async Task<List<Student>> GetStudentsListasync()
        {
           return await _reposetory.GetStudentListAsync();
        }
    }
}
