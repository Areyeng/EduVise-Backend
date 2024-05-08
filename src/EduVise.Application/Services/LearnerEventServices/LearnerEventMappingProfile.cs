using AutoMapper;
using EduVise.Domain;
using EduVise.Services.LearnerEventServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerEventServices
{
    public class LearnerEventMappingProfile : Profile
    {
        public LearnerEventMappingProfile()
        {
            CreateMap<LearnerEvent, LearnerEventDto>()
                   .ForMember(dest => dest.LearnerId, opt => opt.MapFrom(src => src.Learner != null ? src.Learner.Id : Guid.Empty))
                   .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Event != null ? src.Event.Id : Guid.Empty));
        }
    }
}
