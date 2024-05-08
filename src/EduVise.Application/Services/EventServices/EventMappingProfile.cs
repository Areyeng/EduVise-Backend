using AutoMapper;
using EduVise.Domain;
using EduVise.Services.EventServices;
using EduVise.Services.EventServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.EventServices
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {

            CreateMap<Event, EventDto>()
                   .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.Institution != null ? src.Institution.Id : Guid.Empty));

        }
    }
}
