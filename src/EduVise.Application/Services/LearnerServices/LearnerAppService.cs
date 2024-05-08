using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using AutoMapper.Execution;
using EduVise.Authorization.Users;
using EduVise.Domain;
using EduVise.Services.LearnerServices.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerServices
{
    public class LearnerAppService : ApplicationService, ILearnerAppService
    {
        private readonly IRepository<Learner, Guid> _learnerRepository;
        private readonly UserManager _userManager;
        public LearnerAppService(IRepository<Learner, Guid> learnerRepository, UserManager userManager)
        {
            _learnerRepository = learnerRepository;
            _userManager = userManager;
        }
        //Create
        [HttpPost]
        public async Task<LearnerDto> CreateLearnerAsync(LearnerDto input)
        {
            try
            {
                var learner = ObjectMapper.Map<Learner>(input);
                var user = await CreateUserAsync(input);

                learner.User = user;
                learner = await _learnerRepository.InsertAsync(learner);

                await CurrentUnitOfWork.SaveChangesAsync();
                return ObjectMapper.Map<LearnerDto>(learner);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        //GetbyId
        [HttpGet]
        public async Task<LearnerDto> GetByLearnerId(Guid id)
        {
            var learners = await _learnerRepository.GetAsync(id);
            return ObjectMapper.Map<LearnerDto>(learners);
        }
        //GetbyId
        [AbpAuthorize]
        [HttpGet]
        public async Task<LearnerDto> GetMyLearnerDetails()
        {
            var learner = await _learnerRepository.FirstOrDefaultAsync(l => l.User.Id == AbpSession.UserId);
            return ObjectMapper.Map<LearnerDto>(learner);
        }
        //GetAll
        [HttpGet]
        public async Task<List<LearnerDto>> GetAllLearnersAsync()
        {
            var learners = await _learnerRepository.GetAllListAsync();
            return ObjectMapper.Map<List<LearnerDto>>(learners);
        }
        //Update
        [HttpPut]
        public async Task<LearnerDto> UpdateLearnerAsync(LearnerDto input)
        {
            var learner = await _learnerRepository.GetAllIncluding(x => x.User).FirstOrDefaultAsync(x => x.Id == input.Id);
            learner = ObjectMapper.Map(input, learner);
            learner = await _learnerRepository.UpdateAsync(learner);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<LearnerDto>(learner);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _learnerRepository.DeleteAsync(id);
        }
        private async Task<User> CreateUserAsync(LearnerDto input)
        {
            try
            {
                var password = input?.Password;
                var user = ObjectMapper.Map<User>(input);
                user.Password = password;
                user.UserName = input.EmailAddress;
                if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                    user.SetNormalizedNames();
                user.TenantId = AbpSession.TenantId;

                await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
                await _userManager.CreateAsync(user, password);

                CurrentUnitOfWork.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                // For now, rethrow the exception
                throw ex;
            }
        }

    }
}