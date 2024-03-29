﻿using Application.DTOs;
using Application.Features.Departments.Commands.CreateDepartmentCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region
            CreateMap<CreateDepartmentCommand, Department>();
            #endregion

            #region DTOs
            CreateMap<Department, DepartmentDTO>();
            #endregion
        }
    }
}
