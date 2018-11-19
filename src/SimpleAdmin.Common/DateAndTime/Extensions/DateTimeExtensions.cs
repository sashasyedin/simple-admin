using System;

namespace SimpleAdmin.Common.DateAndTime.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfTheDay(this DateTime instance)
        {
            return instance.Date;
        }

        public static DateTime EndOfTheDay(this DateTime instance)
        {
            return instance.Date.AddDays(1).AddTicks(-1);
        }

        public static long ToUnixTimeSeconds(this DateTime instance)
        {
            return ((DateTimeOffset)instance).ToUnixTimeSeconds();
        }
    }
}
