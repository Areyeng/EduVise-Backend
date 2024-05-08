using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.QuestionServices.Dtos
{
    [AutoMap(typeof(Question))]
    public class QuestionDto : EntityDto<Guid>
    {
        public virtual string QuestionText { get; set; }
        public virtual string Skill { get; set; }
    }
}
