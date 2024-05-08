using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
   public class Question : FullAuditedEntity<Guid>
   {
       public virtual string QuestionText { get; set; }
       public virtual string Skill {  get; set; }
   }
}
