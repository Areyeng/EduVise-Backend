using Abp.AutoMapper;
using Abp.Domain.Entities;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.FacultyServices.Dtos
{
    [AutoMap(typeof(Faculty))]
    public class FacultyDto : Entity<Guid>
    {
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  string RequiredSubjects { get; set; }// must be a json serialized string 
        public  int CriticalThinking { get; set; }
        public  int ProblemSolving { get; set; }
        public  int EffectiveCommunication { get; set; }
        public  int HealthcareProficiency { get; set; }
        public  int InstructionalDesign { get; set; }
        public  int LegalReasoning { get; set; }
        public  int Leadership { get; set; }
        public  int EnvironmentalSustainability { get; set; }
        public  Guid InstitutionId { get; set; }
    }
}
