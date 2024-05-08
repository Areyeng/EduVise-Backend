using AutoMapper;
using EduVise.Domain;
using EduVise.Services. LearnerFundingServices.Dtos;
using System;


namespace EduVise.Services.LearnerFundingServices
{
    public class LearnerFundingMappingProfile : Profile
    {
        public  LearnerFundingMappingProfile()
        {
            CreateMap< LearnerFunding,  LearnerFundingDto>()
                   .ForMember(dest => dest.LearnerId, opt => opt.MapFrom(src => src.Learner != null ? src.Learner.Id : Guid.Empty))
                   .ForMember(dest => dest.FundingId, opt => opt.MapFrom(src => src.Funding!= null ? src.Funding.Id : Guid.Empty));
        }
    }
}
