using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.Jobs
{
    public class BackgroundServiceJob
    {
        public async Task Test()
        {
            BackgroundJob.Enqueue<NotificationAlertJob>(x => x.Execute());
        }
    }
}
