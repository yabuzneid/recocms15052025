using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Services.MailerService
{
    public interface IDiariesMailSenderService
    {
        [DisplayName("Send Diaries Mail")]
        Task<bool> SendMailAsync();
    }
}
