using Abp.AutoMapper;
using Abp.Domain.Entities;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.EventServices.Dtos
{
    [AutoMap(typeof(Event))]
    public class EventDto : Entity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Type { get; set; }// (Open Day,Career Fair,Information Session etc)
        public virtual DateTime Date { get; set; }
        public virtual string Venue { get; set; }
        public virtual Guid InstitutionId { get; set; }
    }
}
