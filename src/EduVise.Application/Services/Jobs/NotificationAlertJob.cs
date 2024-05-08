using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using EduVise.Domain;
using EduVise.Services.ResponseServices.Dtos;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EduVise.Services.NotificationService.NotificationSenderService;

namespace EduVise.Services.Jobs
{
    public class NotificationAlertJob : INotifcationSenderJob, ITransientDependency
    {
        public async Task Execute()
        {

            using (var uow = IocManager.Instance.Resolve<IUnitOfWorkManager>().Begin())
            {
                var _learnerinstitutionRepository = IocManager.Instance.Resolve<IRepository<LearnerInstitution, Guid>>();
                var _configuration = IocManager.Instance.Resolve<IConfiguration>();
                try
                {
                    var institutions = await _learnerinstitutionRepository
                        .GetAllIncluding(x => x.Learner, y => y.Institution).Where(x=>x.Institution != null && x.Learner != null)
                        .ToListAsync();
                    foreach (var institution in institutions)
                    {
                        var currentDate = DateOnly.FromDateTime(DateTime.Now);
                        var dateDifference = institution.Institution.ClosingDate.DayNumber - currentDate.DayNumber;
                        var dateTime = DateTime.Parse(institution.Institution.ClosingDate.ToString());
                        int totalDays = Convert.ToInt32((DateTime.Parse(institution.Institution.ClosingDate.ToString()) - DateTime.UtcNow.Date).TotalDays);

                        if (dateDifference >= 0 && dateDifference <= 5)
                        {
                            var notificationInput = new ChatBotNotification
                            {
                                Subject = _configuration.GetSection("Notifications")["subject"],
                                SmtpServer = _configuration.GetSection("Notifications")["smtpServer"],
                                SmtpUserName = _configuration.GetSection("Notifications")["smtpUsername"],
                                SmtpPassword = _configuration.GetSection("Notifications")["smtpPasword"],
                                FromAddress = _configuration.GetSection("Notifications")["fromAddress"],
                                ToAddress = institution.Learner.EmailAddress,
                                Message = $"Please note that the closing date for {institution.Institution.Name} is on {institution.Institution.ClosingDate}.\n" +
                                $"Its Closing in {dateDifference} days.",
                                AttachementPath = null
                            };

                            await NotificationSender.SendNotificationWithAttachment(notificationInput);
                        }
                    }
                    uow.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
