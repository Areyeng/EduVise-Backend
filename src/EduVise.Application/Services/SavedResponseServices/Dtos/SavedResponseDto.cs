using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.SavedResponseServices.Dtos
{
    public class SavedResponseDto : Entity<Guid>
    {
        public virtual Guid LearnerId { get; set; }
        public virtual Guid FacultyOneId { get; set; }
        public virtual Guid FacultyTwoId { get; set; }
        public virtual Guid FacultyThreeId { get; set; }

    }
}
