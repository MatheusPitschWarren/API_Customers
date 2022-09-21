using System.Reflection;
using WebApiCustomers.Model;

namespace WebApiCustomers.Extension
{
    public static class StringExtension
    {        
        public static string CpfCorrect(this string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }        
    }
}
