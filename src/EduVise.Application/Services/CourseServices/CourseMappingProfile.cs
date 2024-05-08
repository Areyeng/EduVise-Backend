using AutoMapper;
using EduVise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.CourseServices
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {

            CreateMap<Course, CourseDto>()
                   .ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.Faculty != null ? src.Faculty.Id : Guid.Empty));
            CreateMap<CourseDto, Course>();
                  //.ForMemberdest => dest.FacultyId, opt => opt.MapFrom(src => src.Faculty != null ? src.Faculty : Guid.Empty));

        }
    }
}
