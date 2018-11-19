using System;

namespace SimpleAdmin.Common.DateAndTime
{
    public class DateTimeProvider
    {
        public virtual DateTime UtcNow => DateTime.UtcNow;

        public virtual DateTime Now => DateTime.Now;
    }
}
