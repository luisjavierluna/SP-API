using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.UpdateDepartmentCommand
{
    public class UpdateDepartmentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Department> _repositoryAsync;

        public UpdateDepartmentCommandHandler(IRepositoryAsync<Department> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repositoryAsync.GetByIdAsync(request.Id);

            if (department == null)
            {
                throw new KeyNotFoundException($"No existen registros con el Id: {request.Id}");
            }
            else
            {
                department.Name = request.Name;
                department.Description = request.Description;

                await _repositoryAsync.UpdateAsync(department);

                return new Response<int>(department.Id);
            }
        }
    }
}
