using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.ResponseServices.Dtos
{
    public class ChatBotNotification
    {
        public string Message { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string AttachementPath { get; set; }
        public string Subject { get; set; }
    }
}
