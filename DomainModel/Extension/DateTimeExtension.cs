using System;

namespace DomainModel.Extension;

public static class DateTimeExtension
{
    public static bool checkEighteenMore(this DateTime date)
    {
        if (DateTime.Now.Year - date.Year >= 18)
            if (DateTime.Now.DayOfYear - date.DayOfYear >= 0) return true;            
        return false;
    }
}
