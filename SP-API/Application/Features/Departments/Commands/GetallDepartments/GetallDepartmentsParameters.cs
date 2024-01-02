using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.GetallDepartments
{
    public class GetallDepartmentsParameters : RequestParameters
    {
        public string Name { get; set; }
    }
}
