using Abp.AutoMapper;
using Abp.Domain.Entities;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerCourseServices.Dtos
{
    [AutoMap(typeof(LearnerCourse))]
    public class LearnerCourseDto : Entity<Guid>
    {
        public virtual Guid LearnerId { get; set; }
        public virtual Guid CourseId { get; set; }
    }
}
