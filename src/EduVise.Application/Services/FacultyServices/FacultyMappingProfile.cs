using AutoMapper;
using EduVise.Domain;
using EduVise.Services.CourseServices;
using EduVise.Services.EventServices.Dtos;
using EduVise.Services.FacultyServices.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.FacultyServices
{
    public class FacultyMappingProfile : Profile
    {
        public FacultyMappingProfile()
        {

            //CreateMap<Faculty, FacultyDto>()
            //       .ForMember(dest => dest.RequiredSubjects, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.RequiredSubjects)));
            CreateMap<Faculty, FacultyDto>()
                   .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.Institution != null ? src.Institution.Id : Guid.Empty));


        }
    }
}
