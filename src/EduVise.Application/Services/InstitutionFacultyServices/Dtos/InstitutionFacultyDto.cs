using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerFacultyServices.Dtos
{
    public class InstitutionFacultyDto : Entity<Guid>
    {
        public virtual Guid FacultyId { get; set; }
        public virtual Guid InstitutionId { get; set; }
    }
}
