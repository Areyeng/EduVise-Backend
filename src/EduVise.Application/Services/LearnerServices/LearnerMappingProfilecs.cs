using AutoMapper;
using EduVise.Authorization.Users;
using EduVise.Domain;
using EduVise.Services.LearnerServices.Dtos;
using System;


namespace EduVise.Services.LearnerServices
{
    public class LearnerMappingProfile : Profile
    {
        public LearnerMappingProfile()
        {

            CreateMap<LearnerDto, User>()
                .ForMember(x => x.Roles, y => y.Ignore())
                .ForMember(x => x.Id, m => m.Ignore())
                .ForMember(x => x.FullName, y => y.MapFrom(x => x.Name + " " + x.Surname))
                //.ForMember(x => x.PhoneNumber, y => y.MapFrom(x => x.CellNumber))
                //.ForMember(x => x.EmailAddress, y => y.MapFrom(x => x.Email))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(x => x.Surname));
            //.ForMember(x => x.UserName, y => y.MapFrom(x => x.Email));

            CreateMap<LearnerDto, Learner>()
                .ForMember(x => x.User, m => m.Ignore())
                .ForMember(x => x.Id, m => m.Ignore());

        }

    }
}
