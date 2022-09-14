using FluentValidation;
using DomainModel.Model;

namespace AppServices.Validator
{
    public class CustomerValidator : AbstractValidator<CustomersModel>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FullName)
                .NotNull().NotEmpty()
                    .WithMessage("Full name must not be null or empty");

            RuleFor(c => c.Email)
                .NotNull()
                    .WithMessage("Email must not be null or empty")
                .EmailAddress()
                    .WithMessage("Email is not valid")
                .Equal(v => v.EmailConfirmation)
                    .WithMessage("Email is not the same as confirmation email");


            RuleFor(c => c.EmailConfirmation)
                .NotNull()
                    .WithMessage("Email Confirmation must not be null or empty");

            RuleFor(c => c.Cpf)
                .NotNull()
                .Must(checkCPF)
                    .WithMessage("Cpf must not be null or empty");

            RuleFor(c => c.Cellphone)
                .NotNull()
                    .WithMessage("Cellphone must not be null or empty");

            RuleFor(c => c.DateOfBirth)
                .NotNull()
                .LessThan(DateTime.Now.Date)
                    .WithMessage("Date Of Birth must not be null or empty and can't have a date greater than today");

            RuleFor(c => c.EmailSms)
                .NotNull()
                    .WithMessage("Email Sms must not be null or empty");

            RuleFor(c => c.Whatsapp)
                .NotNull()
                    .WithMessage("Whatsapp must not be null or empty");

            RuleFor(c => c.Country)
                .NotNull()
                    .WithMessage("Country must not be null or empty");

            RuleFor(c => c.City)
                .NotNull()
                    .WithMessage("City must not be null or empty");

            RuleFor(c => c.PostalCode)
                .NotNull()
                    .WithMessage("PostalCode must not be null or empty");

            RuleFor(c => c.Address)
                .NotNull()
                    .WithMessage("Address must not be null or empty");

            RuleFor(c => c.Number)
                .NotNull()
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
