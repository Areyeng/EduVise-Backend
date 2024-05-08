using Abp.AutoMapper;
using Abp.Domain.Entities;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.CourseServices
{
    [AutoMap(typeof(Course))]
    public class CourseDto : Entity<Guid>
    {

        public virtual string Name { get; set; }
   
        public virtual string Description { get; set; }

        public virtual string FacultyName { get; set; }
     
        public virtual string JobTitles { get; set; }
        public virtual int AvgAPS { get; set; }
        public virtual string AvgDuration { get; set; }
        public virtual string AvgTuition { get; set; }
        public virtual Guid FacultyId { get; set; }

    }
}
