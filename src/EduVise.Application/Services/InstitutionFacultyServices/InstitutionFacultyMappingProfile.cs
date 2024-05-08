using AutoMapper;
using EduVise.Domain;
using EduVise.Services.LearnerFacultyServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.InstitutionFacultyServices
{
    public class InstitutionFacultyMappingProfile : Profile
    {
        public InstitutionFacultyMappingProfile()
        {

         CreateMap<InstitutionFaculty, InstitutionFacultyDto>()
                .ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.Faculty != null ? src.Faculty.Id : Guid.Empty))
                .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.Institution != null ? src.Institution.Id : Guid.Empty)); ;

        }
    }
}
