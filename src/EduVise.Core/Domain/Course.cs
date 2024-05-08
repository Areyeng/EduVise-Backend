using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class Course : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string FacultyName { get; set; }
        public virtual string JobTitles { get; set; }
        public virtual int AvgAPS { get; set; }
        public virtual string AvgDuration { get; set; }
        public virtual string AvgTuition { get; set; }
        public virtual Faculty Faculty {  get; set; }
    }
}
