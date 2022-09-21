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
            .MinimumLength(6)
            .MaximumLength(60);

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress(EmailValidationMode.Net4xRegex)
            .Equal(v => v.EmailConfirmation);

        RuleFor(c => c.Cpf)
            .NotEmpty()
            .Must(CheckCpf)
                .WithMessage("Cpf is not invalid");

        RuleFor(c => c.Cellphone)
            .NotEmpty()
            .MinimumLength(11)
            .MaximumLength(16);

        RuleFor(c => c.DateOfBirth)
            .NotEmpty()
            .Must(c => c.checkEighteenMore())
                .WithMessage("Date Of Birth must not be null or empty and can't have a date greater than today");

        RuleFor(c => c.Country)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(c => c.City)
            .NotEmpty()
            .MinimumLength(5)
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
            .GreaterThan(0);        
    }
    private bool CheckCpf(string cpf)
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
