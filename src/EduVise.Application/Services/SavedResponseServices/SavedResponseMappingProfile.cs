using AutoMapper;
using EduVise.Domain;
using EduVise.Services.SavedResponseServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.SavedResponseServices
{
    public class SavedResponseMappingProfile : Profile
    {
        public SavedResponseMappingProfile()
        {

            CreateMap<SavedResponse, SavedResponseDto> ()
                   .ForMember(dest => dest.LearnerId, opt => opt.MapFrom(src => src.Learner != null ? src.Learner.Id : Guid.Empty));
            CreateMap<SavedResponse, SavedResponseDto>()
                  .ForMember(dest => dest.FacultyOneId, opt => opt.MapFrom(src => src.FacultyOne != null ? src.FacultyOne.Id : Guid.Empty));
            CreateMap<SavedResponse, SavedResponseDto>()
                 .ForMember(dest => dest.FacultyTwoId, opt => opt.MapFrom(src => src.FacultyTwo != null ? src.FacultyTwo.Id : Guid.Empty));
            CreateMap<SavedResponse, SavedResponseDto>()
                 .ForMember(dest => dest.FacultyThreeId, opt => opt.MapFrom(src => src.FacultyThree != null ? src.FacultyThree.Id : Guid.Empty));


        }
    }
}
