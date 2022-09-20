﻿using FluentValidation;
using WebApiCustomers.Extension;
using WebApiCustomers.Model;

namespace WebApiCustomers.Validator;

public class CustomerValidator : AbstractValidator<CustomersModel>
{
    public CustomerValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(60);

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
            .MinimumLength(11)
            .MaximumLength(16);                

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
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(c => c.City)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(c => c.PostalCode)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(9);

        RuleFor(c => c.Address)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(c => c.Number)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50);
    }
}
