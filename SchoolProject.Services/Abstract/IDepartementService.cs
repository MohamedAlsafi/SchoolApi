using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstract
{
    public interface IDepartementService
    {
        public IQueryable<Department> GetDepartmentsQuery();

        public IQueryable<Department> GetDepartmentById(int id);

        public Task<Department> GetById(int id);
    }
}
