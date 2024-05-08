using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class SavedResponse : FullAuditedEntity<Guid>
    {
        public virtual Learner Learner { get; set; }
        public virtual Faculty FacultyOne { get; set; }
        public virtual Faculty FacultyTwo { get; set; }
        public virtual Faculty FacultyThree { get; set; }

    }
}
