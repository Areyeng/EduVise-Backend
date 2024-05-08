using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class Funding : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string InstitutionCriteria { get; set; }
        public virtual string FacultyCriteria { get; set; }
        public virtual string MarkCriteria { get; set; }

        public virtual decimal? AnnualAmount { get; set; }
        public virtual int? Duration { get; set; }
        public virtual DateTime? OpeningDate { get; set; }
        public virtual DateTime? ClosingDate { get; set; }

        public virtual string FundingLink { get; set; }

    }
}
