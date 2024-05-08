using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EduVise.Services.ResponseServices.Dtos;

namespace EduVise.Services.NotificationService
{
    public class NotificationSenderService
    {
        public static class NotificationSender
        {
            public static async Task SendNotificationWithAttachment(ChatBotNotification input)
            {
                var smtpClient = new SmtpClient(input.SmtpServer)
                {
                    Port = 587,
                    Credentials = new NetworkCredential(input.SmtpUserName, input.SmtpPassword),
                    EnableSsl = false,
                };

                var message = new MailMessage(input.FromAddress, input.ToAddress)
                {
                    Subject = input.Subject,
                    Body = input.Message,
                };

                //Attachment attachment = new Attachment(input.AttachementPath);
                //message.Attachments.Add(attachment);

                await smtpClient.SendMailAsync(message);
            }

        }
    }
}
