namespace DomainModel.Extension;

public static class StringExtension
{
    public static string CPFFormatter(this string cpf)
    {
        return cpf.Trim().Replace(".", "").Replace("-", "");
    }        
}