using DomainModel.Extension;
using DomainModel.Model;
using FluentValidation;
using FluentValidation.Validators;

namespace AppServices.Validator;

public class CustomerValidator : AbstractValidator<CustomersModel>
{
    public CustomerValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty()
            .Length(6, 60);

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress(EmailValidationMode.Net4xRegex)
            .Equal(v => v.EmailConfirmation);

        RuleFor(c => c.Cpf)
            .NotEmpty()
            .Must(c => c.CheckCpfValidate())
                .WithMessage("Cpf is not invalid");

        RuleFor(c => c.Cellphone)
            .NotEmpty()
            .Length(11, 16)
                .WithMessage("Number is not valid");

        RuleFor(c => c.DateOfBirth)
            .NotEmpty()
            .Must(c => c.checkEighteenMore())
                .WithMessage("Date Of Birth must not be null or empty and can't have a date greater than today");

        RuleFor(c => c.Country)
            .NotEmpty()
            .Length(2, 50);

        RuleFor(c => c.City)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(c => c.PostalCode)
            .NotEmpty()
            .Length(8, 9);

        RuleFor(c => c.Address)
            .NotEmpty()
            .Length(5, 50);

        RuleFor(c => c.Number)
            .NotEmpty();
    }
}
