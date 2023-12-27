using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.CreateDepartmentCommand
{
    public class CreateDepartmentCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Response<int>>
    {
        public Task<Response<int>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
