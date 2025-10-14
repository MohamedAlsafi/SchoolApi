using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using School.Shared.Helper;
using SchoolProject.Domain.Entites;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.InfrastructureBases;
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
        private readonly IGenericRepository<Student> _reposetory;

        public StudentServices(IGenericRepository<Student> reposetory)
        {
            _reposetory = reposetory;
        }
        public IQueryable<Student> GetStudentsQuery ()
        {
            return _reposetory.GetAll();
        }
    }
}
