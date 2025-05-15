using MailBee.ImapMail;
using MailBee.Mime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecoCms6.Services.Background.MailServices
{
    public class InboxHandler : IInboxHandler
    {
        public IEnumerable<MailMessage> Messages => _messages.Values;
        private readonly Credential _credentials;
        private readonly string _mailServer;
        private readonly Imap _imap;
        private Dictionary<string, MailMessage> _messages;

        public InboxHandler(Credential credentials, string mailServer)
        {
            _messages = new Dictionary<string, MailMessage>();
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            _imap = new Imap()
            {
                SslMode = MailBee.Security.SslStartupMode.UseStartTls

            };
            _mailServer = mailServer;
        }
        public InboxHandler(string user, string password, string mailServer)
        {
            _messages = new Dictionary<string, MailMessage>();
            _credentials = new Credential();
            _credentials.User = user;
            _credentials.Password = password;
            _imap = new Imap()
            {
                SslMode = MailBee.Security.SslStartupMode.UseStartTls
            };
            _mailServer = mailServer;
        }

        public void Connect()
        {
            if (!_imap.IsConnected)
            {
                try
                {
                    _imap.Connect(_mailServer);
                    _imap.Login(_credentials.User, _credentials.Password);
                    _imap.SelectFolder(MailFolder.Inbox);
                }
                catch { }
                
                //var folders = _imap.DownloadFolders();
            }
        }
        public void Disconnect()
        {
            if (_imap.IsConnected)
            {
                _messages.Values.ToList().ForEach(m => m.Dispose());
                _messages = null;
                try
                {
                    _imap.Disconnect();
                }
                catch { }
                
            }
        }

        public void LoadInbox(string filter)
        {
            var messages = _imap.DownloadEntireMessages(filter, true);
            _messages = new Dictionary<string, MailMessage>();
            foreach (MailMessage message in messages)
            {
                _messages.Add(message.UidOnServer.ToString(), message);
            }
        }

        public void MoveFromInbox(MailMessage message, string folder)
        {
            _messages.Remove(message.UidOnServer.ToString());
            _imap.MoveMessages(message.UidOnServer.ToString(), true, folder);
        }
    }
}
