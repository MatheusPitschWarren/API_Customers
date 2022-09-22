using System;

namespace DomainModel.Extension;

public static class DateTimeExtension
{
    public static bool VerificationThatYouAreOfLegalAge(this DateTime date)
    {
        return (DateTime.Now.Year - date.Year >= 18 && DateTime.Now.DayOfYear - date.DayOfYear >= 0);
    }
}
