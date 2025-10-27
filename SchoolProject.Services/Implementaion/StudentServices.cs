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
        public async Task<Student> GetById(int id)
        {
            return await _reposetory.GetByIdAsync(id);
        }

        public IQueryable<Student> GetStudentById(int id)
        {
          return  _reposetory.GetAll().Where(s=>s.ID == id); 
        }

        public async Task<string> AddStudent(Student student)
        {
            //var studentResult = _reposetory.GetAllByCriteriaAsync(s => s.Name == student.Name).FirstOrDefault();
            //if (studentResult != null) return "Exist";

            await  _reposetory.AddAsync(student );
           await _reposetory.SaveChangesAsync();
            return "Success";
                
            
        }

        public async Task<bool> CheckIfNameExistAsync(string name ,CancellationToken cancellationToken=default)
        {
          var exist = await  _reposetory.AnyAsync(x=>x.NameEn == name);
            return exist;
        }

        public async Task UpdateIncludeAsync(Student student, params string[] modifiedProperties)
        {
         await  _reposetory.UpdateIncludeAsync(student, modifiedProperties);
            await _reposetory.SaveChangesAsync();
        }

        public async Task<string> DeleteStudent(Student student)
        {
             await _reposetory.SoftDeleteAsync(student);
            await _reposetory.SaveChangesAsync();
            return "Student Delete Succesfly";
            
        }
    }
}
