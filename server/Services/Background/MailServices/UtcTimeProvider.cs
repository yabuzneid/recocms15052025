using System;

namespace RecoCms6.Services.Background.MailServices
{
    public class UtcTimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
        public DateTime Today => Now.Date;

        public DateTime GetHourOfDay(int hour)
        {
            return Today.AddHours(hour);
        }
    }
}
