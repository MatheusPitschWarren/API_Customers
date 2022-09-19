﻿using FluentValidation;
using WebApiCustomers.Model;

namespace WebApiCustomers.Validator
{
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
                .EmailAddress()
                    .WithMessage("Email is not valid")
                .Equal(v => v.EmailConfirmation)
                    .WithMessage("Email is not the same as confirmation email");

            RuleFor(c => c.EmailConfirmation)
                .NotEmpty()
                    .WithMessage("Email Confirmation must not be null or empty");

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .Must(checkCPF)
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

        public static bool checkCPF(string cpf)
        {
            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temporaryCpf;
            string Digit;
            int rest;
            int sum = 0;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            temporaryCpf = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                sum += int.Parse(temporaryCpf[i].ToString()) * multiplierOne[i];
            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            Digit = rest.ToString();
            temporaryCpf = temporaryCpf + Digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(temporaryCpf[i].ToString()) * multiplierTwo[i];
            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            Digit = Digit + rest.ToString();

            return cpf.EndsWith(Digit);
        }
    }
}
