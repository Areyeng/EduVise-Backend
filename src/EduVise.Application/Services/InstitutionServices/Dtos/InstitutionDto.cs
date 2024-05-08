using Abp.AutoMapper;
using Abp.Domain.Entities;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.InstitutionServices.Dtos
{
    [AutoMap(typeof(Institution))]
    public class InstitutionDto : Entity<Guid>
    {
        public  string Name { get; set; }
        public  string Description { get; set; }

        //public  storedFile Image { get; set; }
        public  string Accreditation { get; set; }
        public  string Ranking { get; set; }
        public  int PassRate { get; set; }
        public  string Address { get; set; }
        public  DateOnly OpeningDate { get; set; }//expects: "2024-04-22"
        public  DateOnly ClosingDate { get; set; }
        public  string ProgrammesLink { get; set; }
        public  string YearbookLink { get; set; }
        public  string ApplicationLink { get; set; }
    }
}
