using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Departement.Queries.Dtos;
using SchoolProject.Application.Features.Departement.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Departement.Queries.Handelers
{
    public class GetDepartmentByIDQueryHandeler : ResponseHandler, IRequestHandler<GetDepartmentByIDQuery, Response<GetDepartmentByIDQueryDto>>
    {
        private readonly IDepartementService _departementService;

        public GetDepartmentByIDQueryHandeler(IDepartementService departementService)
        {
            _departementService = departementService;
        }
        public async Task<Response<GetDepartmentByIDQueryDto>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
           var department = _departementService.GetDepartmentById(request.Id);
            var departmentMapping = await department.ProjectTo<GetDepartmentByIDQueryDto>().FirstOrDefaultAsync(cancellationToken);
            if (departmentMapping is null)
            {
                return NotFound<GetDepartmentByIDQueryDto>(LZ.Translate(SharedResourcesKeys.NotFound));
            }
            return Success(departmentMapping);
        }
    }
}
