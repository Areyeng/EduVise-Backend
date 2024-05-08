using Abp.Domain.Entities.Auditing;
using EduVise.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Domain
{
    public class Learner : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateOnly BirthDate { get; set; }
        public virtual string EmailAddress { get; set; }

        [RegularExpression(@"^\d{1,10}$")]
        public virtual long PhoneNumber { get; set; }
        
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$")]
        public virtual string Password { get; set; }
        public  virtual User User { get; set; }
    }
}
