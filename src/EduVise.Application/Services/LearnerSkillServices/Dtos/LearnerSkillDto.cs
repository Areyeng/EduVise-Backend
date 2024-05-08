using Abp.AutoMapper;
using Abp.Domain.Entities;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerSkillServices.Dtos
{
    [AutoMap(typeof(LearnerSkill))]
    public class LearnerSkillDto : Entity<Guid>
    {
        public int CriticalThinking { get; set; }
        public int ProblemSolving { get; set; }
        public int EffectiveCommunication { get; set; }
        public int HealthcareProficiency { get; set; }
        public int InstructionalDesign { get; set; }
        public int LegalReasoning { get; set; }
        public int Leadership { get; set; }
        public int EnvironmentalSustainability { get; set; }
        public virtual Guid Learner { get; set; }
    }
}
