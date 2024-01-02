using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Departments.Commands.GetallDepartments
{
    public class GetallDepartmentsQuery : IRequest<PagedResponse<List<DepartmentDTO>>>
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetallDepartmentsQueryHandler : IRequestHandler<GetallDepartmentsQuery, PagedResponse<List<DepartmentDTO>>>
        {
            private readonly IRepositoryAsync<Department> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetallDepartmentsQueryHandler(IRepositoryAsync<Department> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<DepartmentDTO>>> Handle(GetallDepartmentsQuery request, CancellationToken cancellationToken)
            {
                var departments = await _repositoryAsync.ListAsync(
                    new PagedDepartmentsSpecification(request.PageNumber, request.PageSize, request.Name));

                var departmentsDto = _mapper.Map<List<DepartmentDTO>>(departments);

                return new PagedResponse<List<DepartmentDTO>>(departmentsDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
