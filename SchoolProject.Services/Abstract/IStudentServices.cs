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
        public IQueryable<Student> GetStudentsQuery();

        public IQueryable<Student> GetStudentById (int id); 

        public Task<Student> GetById (int id);  

        public Task<string> AddStudent (Student student);

        public Task<bool> CheckIfNameExistAsync (string name , CancellationToken cancellationToken = default);

        public Task UpdateIncludeAsync(Student student, params string[] modifiedProperties);


    }
}
