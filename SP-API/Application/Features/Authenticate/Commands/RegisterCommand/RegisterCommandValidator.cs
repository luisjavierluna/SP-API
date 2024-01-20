using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estár vacío.")
                .MaximumLength(80).WithMessage("El campo {PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estár vacío.")
                .MaximumLength(80).WithMessage("El campo {PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estár vacío.")
                .EmailAddress().WithMessage("El campo {PropertyName} debe ser una dirección de correo válida")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estár vacío.")
                .MaximumLength(10).WithMessage("El campo {PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estár vacío.")
                .MaximumLength(15).WithMessage("El campo {PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede estár vacío.")
                .MaximumLength(15).WithMessage("El campo {PropertyName} no debe exceder de {MaxLength} caracteres")
                .Equal(p => p.Password).WithMessage("El campo {PropertyName} debe ser igual a Password");
        }
    }
}
