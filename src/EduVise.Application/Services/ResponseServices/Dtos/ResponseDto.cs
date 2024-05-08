using Abp.AutoMapper;
using Abp.Domain.Entities;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.ResponseServices.Dtos
{
    [AutoMap(typeof(Response))]
    public class ResponseDto : Entity<Guid>
    {
        public virtual Guid Learner { get; set; }
        public int CriticalThinking { get; set; }
        public int ProblemSolving { get; set; }
        public int EffectiveCommunication { get; set; }
        public int HealthcareProficiency { get; set; }
        public int InstructionalDesign { get; set; }
        public int LegalReasoning { get; set; }
        public int Leadership { get; set; }
        public int EnvironmentalSustainability { get; set; }
    }
}
