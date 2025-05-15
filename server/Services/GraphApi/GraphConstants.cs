using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Services.GraphApi
{
    public static class GraphConstants
    {
        // Defines the permission scopes used by the app
        public readonly static string[] Scopes =
        {
            "openid",
            "email",
            "offline_access",
            "https://graph.microsoft.com/mail.read",
            "https://graph.microsoft.com/mail.ReadWrite",
            "https://graph.microsoft.com/mail.Send"
        };
    }
}
