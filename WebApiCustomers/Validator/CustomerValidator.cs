using FluentValidation;
using WebApiCustomers.Model;

namespace WebApiCustomers.Validator;

public class CustomerValidator : AbstractValidator<CustomersModel>
{
    public CustomerValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty()
                .WithMessage("Full name must not be null or empty");

        RuleFor(c => c.Email)
            .NotEmpty()
                .WithMessage("Email must not be null or empty")
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Email is not valid")
            .Equal(v => v.EmailConfirmation)
                .WithMessage("Email is not the same as confirmation email");

        RuleFor(c => c.EmailConfirmation)
            .NotEmpty()
                .WithMessage("Email Confirmation must not be null or empty");

        RuleFor(c => c.Cpf)
            .NotEmpty()           
                .WithMessage("Cpf must not be null or empty");

        RuleFor(c => c.Cellphone)
            .NotEmpty()
                .WithMessage("Cellphone must not be null or empty");

        RuleFor(c => c.DateOfBirth)
            .NotEmpty()
            .LessThan(DateTime.Now.Date)
                .WithMessage("Date Of Birth must not be null or empty and can't have a date greater than today");

        RuleFor(c => c.EmailSms)
            .NotEmpty()
                .WithMessage("Email Sms must not be null or empty");

        RuleFor(c => c.Whatsapp)
            .NotEmpty()
                .WithMessage("Whatsapp must not be null or empty");

        RuleFor(c => c.Country)
            .NotEmpty()
                .WithMessage("Country must not be null or empty");

        RuleFor(c => c.City)
            .NotEmpty()
                .WithMessage("City must not be null or empty");

        RuleFor(c => c.PostalCode)
            .NotEmpty()
                .WithMessage("PostalCode must not be null or empty");

        RuleFor(c => c.Address)
            .NotEmpty()
                .WithMessage("Address must not be null or empty");

        RuleFor(c => c.Number)
            .NotEmpty()
                .WithMessage("Number must not be null or empty");
    }
}
