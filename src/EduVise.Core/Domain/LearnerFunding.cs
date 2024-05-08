using Abp.Domain.Entities.Auditing;
using System;


namespace EduVise.Domain
{
    public class LearnerFunding : FullAuditedEntity<Guid>
    {
        public virtual Learner Learner{ get; set; }
        public virtual Funding Funding{ get; set; } 
    }
}
