using AutoMapper;
using EduVise.Domain;
using EduVise.Services.LearnerInstitutionServices.Dtos;
using EduVise.Services.LearnerInstitutionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerInstitutionServices
{
    public class LearnerInstitutionMappingProfile : Profile
    {
        public LearnerInstitutionMappingProfile()
        {
            CreateMap<LearnerInstitution, LearnerInstitutionDto>()
                   .ForMember(dest => dest.LearnerId, opt => opt.MapFrom(src => src.Learner != null ? src.Learner.Id : Guid.Empty))
                   .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.Institution != null ? src.Institution.Id : Guid.Empty));
        }
    }
}
