using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class LearnerInstitution : FullAuditedEntity<Guid>
    {
        public virtual Learner Learner { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
