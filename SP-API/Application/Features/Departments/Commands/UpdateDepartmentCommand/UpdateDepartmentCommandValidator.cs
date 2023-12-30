using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.UpdateDepartmentCommand
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.")
                .MaximumLength(80).WithMessage("El campo {PropertyName} no puede tener más de {MaxLength} caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.")
                .MaximumLength(380).WithMessage("El campo {PropertyName} no puede tener más de {MaxLength} caracteres.");
        }
    }
}
