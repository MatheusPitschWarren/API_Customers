using FluentValidation;
using WebApiCustomers.Extension;
using WebApiCustomers.Model;

namespace WebApiCustomers.Validator;

public class CustomerValidator : AbstractValidator<CustomersModel>
{
    public CustomerValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty()
            .Length(6, 60);

        RuleFor(c => c.Email)
            .NotEmpty()
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Email is not valid")
            .Equal(v => v.EmailConfirmation);

        RuleFor(c => c.EmailConfirmation)
            .NotEmpty()
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Email is not valid");

        RuleFor(c => c.Cpf)
            .NotEmpty()
            .Must(c => c.CheckCpf())
                .WithMessage("Cpf is not invalid");

        RuleFor(c => c.Cellphone)
            .NotEmpty()
            .Length(11,16)
                .WithMessage("Number is not valid");

        RuleFor(c => c.DateOfBirth)
            .NotEmpty()
            .Must(c => c.checkEighteenMore())
                .WithMessage("Date Of Birth must not be null or empty and can't have a date greater than today");

        RuleFor(c => c.EmailSms)
            .NotEmpty();

        RuleFor(c => c.Whatsapp)
            .NotEmpty();

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
