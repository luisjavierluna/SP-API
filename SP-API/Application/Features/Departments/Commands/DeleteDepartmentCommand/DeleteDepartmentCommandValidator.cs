using FluentValidation;

namespace Application.Features.Departments.Commands.DeleteDepartmentCommand
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacío.");
        }
    }
}
