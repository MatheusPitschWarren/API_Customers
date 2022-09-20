using System.Linq;

namespace DomainModel.Extension
{
    public static class StringExtension
    {
        public static string CpfCorrect(this string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }

        public static bool CheckCpfValidate(this string cpf)
        {
            cpf = cpf.CpfCorrect();
            if (cpf.Length != 11)
                return false;

            if (cpf.All(c => c == cpf.First()))
                return false;

            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temporaryCpf;
            string Digit;
            int rest;
            int sum = 0;

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
