using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.LearnerFundingServices.Dtos;
using EduVise.Services.LearnerFundingServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduVise.Services.LearnerInstitutionServices.Dtos;
using Abp.UI;
using EduVise.Services.LearnerCourseServices.Dtos;
using Microsoft.EntityFrameworkCore;
using EduVise.Services.InstitutionServices.Dtos;
using EduVise.Services.FundingServices.Dtos;

namespace EduVise.Services.LearnerFundingServices
{
    public class LearnerFundingAppService : ApplicationService, ILearnerFundingAppService
    {
        private readonly IRepository<LearnerFunding, Guid> _learnerfundingRepository;
        private readonly IRepository<Learner, Guid> _learnerRepository;
        private readonly IRepository<Funding, Guid> _fundingRepository;
        public LearnerFundingAppService(IRepository<LearnerFunding, Guid> learnerfundingRepository, IRepository<Learner, Guid> learnerRepository, IRepository<Funding, Guid> fundingRepository)
        {
            _learnerfundingRepository = learnerfundingRepository;
            _learnerRepository = learnerRepository;
            _fundingRepository = fundingRepository;
        }
        //Create
        [HttpPost]
        public async Task<LearnerFundingDto> CreateLearnerFundingAsync(LearnerFundingDto input)
        {
            var learner = _learnerRepository.Get(input.LearnerId) ?? throw new Exception("learner does not exist!");
            var funding = _fundingRepository.Get(input.FundingId) ?? throw new Exception("funding does not exist!");
            var learnerfunding = new LearnerFunding
            {
                Learner = learner,
                Funding = funding,
            };
            await _learnerfundingRepository.InsertAsync(learnerfunding);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<LearnerFundingDto>(learnerfunding);
        }
        //GetbyId
        [HttpGet]
        public async Task<LearnerFundingDto> GetByLearnerFundingId(Guid id)
        {
            var funding = await _learnerfundingRepository.GetAllIncluding(e => e.Learner, e => e.Funding)
                                           .FirstOrDefaultAsync(e => e.Id == id);


            if (funding == null)
            {
                throw new UserFriendlyException("learner's funding not found!");
            }
            return ObjectMapper.Map<LearnerFundingDto>(funding);
        }
        //GetAll
        [HttpGet]
        public async Task<List<LearnerFundingDto>> GetAllLearnerFundingsAsync()
        {
            var learnerfunding = await _learnerfundingRepository.GetAllIncluding(x => x.Learner, x => x.Funding).ToListAsync();
            return ObjectMapper.Map<List<LearnerFundingDto>>(learnerfunding);
        }
        public async Task<List<FundingDto>> GetAllFundingsForSpecificLearnerAsync(Guid id)
        {
            var learnerInstitutions = await _learnerfundingRepository.GetAllIncluding(e => e.Learner, e => e.Funding)
                                                .Where(e => e.Learner.Id == id)
                                                .ToListAsync();

            if (learnerInstitutions == null || learnerInstitutions.Count == 0)
            {
                throw new UserFriendlyException("No learnerfunding found for the provided ID!");
            }

            // Extract institution IDs
            var institutionIds = learnerInstitutions.Select(li => li.Funding.Id).ToList();

            // Fetch corresponding institutions
            var funding = await _fundingRepository.GetAll().Where(i => institutionIds.Contains(i.Id)).ToListAsync();

            return ObjectMapper.Map<List<FundingDto>>(funding);
        }
        //Update
        [HttpPut]
        public async Task<LearnerFundingDto> UpdateLearnerFundingAsync(LearnerFundingDto input)
        {
            var learnerfundinginput = ObjectMapper.Map<LearnerFunding>(input);
            learnerfundinginput = await _learnerfundingRepository.UpdateAsync(learnerfundinginput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<LearnerFundingDto>(learnerfundinginput);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _learnerfundingRepository.DeleteAsync(id);
        }
    }
}
