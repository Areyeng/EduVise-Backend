using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class LearnerSkill : FullAuditedEntity<Guid>
    {
        public string Description { get; set; }
        public string RequiredSubjects { get; set; }
        public int CriticalThinking { get; set; }
        public int ProblemSolving { get; set; }
        public int EffectiveCommunication { get; set; }
        public int HealthcareProficiency { get; set; }
        public int InstructionalDesign { get; set; }
        public int LegalReasoning { get; set; }
        public int Leadership { get; set; }
        public int EnvironmentalSustainability { get; set; }
        public virtual Learner Learner { get; set; }
    }
}
