using Abp.AutoMapper;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerInstitutionServices.Dtos
{
    [AutoMap(typeof(LearnerInstitution))]
    public class LearnerInstitutionDto
    {
        public virtual Guid LearnerId { get; set; }
        public virtual Guid InstitutionId { get; set; }
    }
}
