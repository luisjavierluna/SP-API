using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.CreateDepartmentCommand
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.")
                .MaximumLength(80).WithMessage("El campo {PropertyName} no puede tener más de {MaxLength} caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.")
                .MaximumLength(380).WithMessage("El campo {PropertyName} no puede tener más de {MaxLength} caracteres.");
        }
    }
}
