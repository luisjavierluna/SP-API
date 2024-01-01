using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<Response<DepartmentDTO>>
    {
        public int Id { get; set; }

        public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Response<DepartmentDTO>>
        {
            private readonly IRepositoryAsync<Department> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetDepartmentByIdQueryHandler(IRepositoryAsync<Department> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<DepartmentDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
            {
                var departament = await _repositoryAsync.GetByIdAsync(request.Id);
                if (departament == null)
                {
                    throw new KeyNotFoundException($"No se encontraron registros con el id {request.Id}");
                }
                else
                {
                    var dto = _mapper.Map<DepartmentDTO>(departament);

                    return new Response<DepartmentDTO>(dto);
                }
            }
        }
    }
}
