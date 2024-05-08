using Abp.Dependency;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.Jobs
{
    public interface INotifcationSenderJob:ITransientDependency
    {
        [Queue("alpha")]
        public Task Execute();
    }
}
