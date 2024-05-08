using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class Institution : FullAuditedEntity<Guid>
    {
        public  virtual string Name { get; set; }
        public virtual string Description { get; set; }

        //public  storedFile Image { get; set; }
        public virtual string Accreditation { get; set; }
        public virtual string Ranking { get; set; }
        public virtual int PassRate { get; set; }
        public virtual string Address { get; set; }
        public virtual DateOnly OpeningDate { get; set; }
        public virtual DateOnly ClosingDate { get; set; }
        public virtual string ProgrammesLink { get; set; }
        public virtual string YearbookLink { get; set; }
        public virtual string ApplicationLink { get; set; }

      

    }
}
