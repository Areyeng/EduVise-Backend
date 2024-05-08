using Abp.AutoMapper;
using EduVise.Domain;
using System;


namespace EduVise.Services.LearnerFundingServices.Dtos
{
    [AutoMap(typeof(LearnerFunding))]
    public class LearnerFundingDto
    {
        public Guid LearnerId { get; set; }
        public Guid FundingId { get; set; }
    }
}
