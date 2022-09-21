using System;

namespace DomainModel.Extension;

public static class DateTimeExtension
{
    public static bool checkEighteenMore(this DateTime date)
    {
        return (DateTime.Now.DayOfYear - date.DayOfYear >= 0);
    }
}
