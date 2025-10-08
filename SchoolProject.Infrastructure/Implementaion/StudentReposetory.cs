using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entites;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Implementaion
{
    public class StudentReposetory : IStudentReposetory
    {
        private readonly SchoolDbContext _context;
        

        public StudentReposetory(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
