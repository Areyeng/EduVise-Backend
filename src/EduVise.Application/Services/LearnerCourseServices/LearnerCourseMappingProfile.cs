using AutoMapper;
using EduVise.Domain;
using EduVise.Services.LearnerCourseServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerCourseServices
{
    public class LearnerCourseMappingProfile : Profile
    {
        public LearnerCourseMappingProfile()
        {
            CreateMap<LearnerCourse, LearnerCourseDto>()
                   .ForMember(dest => dest.LearnerId, opt => opt.MapFrom(src => src.Learner != null ? src.Learner.Id : Guid.Empty))
                   .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course != null ? src.Course.Id : Guid.Empty));
        }
    }

}

