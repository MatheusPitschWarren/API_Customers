using System;

namespace DomainModel.Extension
{
    public static class DateTimeExtension
    {
        public static bool checkEighteenMore(this DateTime date)
        {
            if (date.Year - DateTime.Now.Year >= 18)
            {
                return true;
            }
            return false;
        }
    }
}
