using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class Response : FullAuditedEntity<Guid>
    {
        public virtual Learner Learner { get; set; }
        public virtual string Description { get; set; }
        public virtual string RequiredSubjects { get; set; }
        public virtual int CriticalThinking { get; set; }
        public virtual int ProblemSolving { get; set; }
        public virtual int EffectiveCommunication { get; set; }
        public virtual int HealthcareProficiency { get; set; }
        public virtual int InstructionalDesign { get; set; }
        public virtual int LegalReasoning { get; set; }
        public virtual int Leadership { get; set; }
        public virtual int EnvironmentalSustainability { get; set; }
    }
}
