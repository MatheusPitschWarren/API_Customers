using System.Linq;

namespace DomainModel.Extension
{
    public static class StringExtension
    {
        public static string CpfCorrect(this string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }        
    }
}
