using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.LearnerServices.Dtos;
using EduVise.Services.LearnerSkillServices.Dtos;
using EduVise.Services.ResponseServices.Dtos;
using EduVise.Services.SavedResponseServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerSkillServices
{
    public class LearnerSkillAppService : ApplicationService
    {
        private readonly IRepository<LearnerSkill, Guid> _learnerSkillRepository;
     
        public LearnerSkillAppService(IRepository<LearnerSkill, Guid> learnerSkillRepository, IMapper mapper)
        {
            _learnerSkillRepository = learnerSkillRepository;
      
        }
        //Create
        //[HttpPost]
        //public async Task<LearnerSkillDto> CreateLearnerSkillsAsync(LearnerSkillDto input)
        //{
        //    var responseInputEntity = ObjectMapper.Map<LearnerSkillDto > (input);
            

        //    // Assuming you have a LearnerId in LearnerSkillDto that you want to set here
        //    responseInputEntity.Id = input.Id;

        //    responseInputEntity = await _learnerSkillRepository.InsertAsync(responseInputEntity);
        //    await CurrentUnitOfWork.SaveChangesAsync();

        //    var responseDto = _mapper.Map<LearnerSkillDto>(responseInputEntity);
        //    return responseDto;
        //}
    }
}