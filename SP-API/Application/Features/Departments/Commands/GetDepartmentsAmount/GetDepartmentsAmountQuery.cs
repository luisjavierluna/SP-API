using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.GetDepartmentsAmount
{
    public class GetDepartmentsAmountQuery : IRequest<Response<int>>
    {
        public class GetDepartmentsAmountQueryHandler : IRequestHandler<GetDepartmentsAmountQuery, Response<int>>
        {
            private readonly IRepositoryAsync<Department> _repositoryAsync;

            public GetDepartmentsAmountQueryHandler(IRepositoryAsync<Department> repositoryAsync)
            {
                _repositoryAsync = repositoryAsync;
            }

            public async Task<Response<int>> Handle(GetDepartmentsAmountQuery request, CancellationToken cancellationToken)
            {
                int amount = await _repositoryAsync.CountAsync();

                return new Response<int>(amount);
            }

        }
    }
}
