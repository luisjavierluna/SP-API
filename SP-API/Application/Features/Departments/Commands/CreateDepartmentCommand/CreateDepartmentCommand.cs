using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.CreateDepartmentCommand
{
    public class CreateDepartmentCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Department> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IRepositoryAsync<Department> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var nuevoDepartment = _mapper.Map<Department>(request);

            var data = await _repositoryAsync.AddAsync(nuevoDepartment);

            return new Response<int>(data.Id);
        }
    }
}
