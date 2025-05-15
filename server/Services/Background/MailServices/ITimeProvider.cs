using System;

namespace RecoCms6.Services.Background.MailServices
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
        DateTime GetHourOfDay(int hour);
    }
}
