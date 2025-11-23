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
    public class DepartmentServices : IDepartementService
    {
        private readonly IGenericRepository<Department> _reposetory;

        public DepartmentServices(IGenericRepository<Department> reposetory)
        {
            _reposetory = reposetory;
        }

        public IQueryable<Department> GetDepartmentsQuery ()
        {
            return _reposetory.GetAll();
        }
        public async Task<Department> GetById(int id)
        {
            return await _reposetory.GetByIdAsync(id);
        }

        public IQueryable<Department> GetDepartmentById(int id)
        {
          return  _reposetory.GetAll().Where(s=>s.ID == id); 
        }

        //public async Task<string> AddDepartment(Department student)
        //{
        //    //var studentResult = _reposetory.GetAllByCriteriaAsync(s => s.Name == student.Name).FirstOrDefault();
        //    //if (studentResult != null) return "Exist";

        //    await  _reposetory.AddAsync(student );
        //   await _reposetory.SaveChangesAsync();
        //    return "Success";            
        ////}

        //public async Task<bool> CheckIfNameExistAsync(string name ,CancellationToken cancellationToken=default)
        //{
        //  var exist = await  _reposetory.AnyAsync(x=>x.NameEn == name);
        //    return exist;
        //}

        //public async Task UpdateIncludeAsync(Department student, params string[] modifiedProperties)
        //{
        // await  _reposetory.UpdateIncludeAsync(student, modifiedProperties);
        //    await _reposetory.SaveChangesAsync();
        //}

        //public async Task<string> DeleteDepartment(Department student)
        //{
        //     await _reposetory.SoftDeleteAsync(student);
        //    await _reposetory.SaveChangesAsync();
        //    return "Department Delete Succesfly";
            
        //}
    }
}
