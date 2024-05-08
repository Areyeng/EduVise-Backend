using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.InstitutionServices.Dtos;
using EduVise.Services.LearnerCourseServices.Dtos;
using EduVise.Services.LearnerEventServices.Dtos;
using EduVise.Services.LearnerInstitutionServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerInstitutionServices
{
    public class LearnerInstitutionAppService : ApplicationService, ILearnerInstitutionAppService
    {
        private readonly IRepository<LearnerInstitution, Guid> _learnerinstitutionRepository;
        private readonly IRepository<Learner, Guid> _learnerRepository;
        private readonly IRepository<Institution, Guid> _institutionRepository;
        public LearnerInstitutionAppService(IRepository<LearnerInstitution, Guid> learnerinstitutionRepository, IRepository<Learner, Guid> learnerRepository, IRepository<Institution, Guid> institutionRepository)
        {
            _learnerinstitutionRepository = learnerinstitutionRepository;
            _learnerRepository = learnerRepository;
            _institutionRepository = institutionRepository;
        }
        //Create
        [HttpPost]
        public async Task<LearnerInstitutionDto> CreateLearnerInstitutionAsync(LearnerInstitutionDto input)
        {
            var learner = _learnerRepository.Get(input.LearnerId) ?? throw new Exception("learner does not exist!");
            var institution = _institutionRepository.Get(input.InstitutionId) ?? throw new Exception("institution does not exist!");
            var learnerinstitution = new LearnerInstitution 
            {
                Learner = learner,
                Institution = institution,
            };
            await _learnerinstitutionRepository.InsertAsync(learnerinstitution);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<LearnerInstitutionDto>(learnerinstitution);
        }
        //GetbyId
        [HttpGet]
        public async Task<LearnerInstitutionDto> GetByLearnerInstitutionId(Guid id)
        {
            var institution = await _learnerinstitutionRepository.GetAllIncluding(e => e.Learner, e => e.Institution)
                                           .FirstOrDefaultAsync(e => e.Id == id);

            if (institution == null)
            {
                throw new UserFriendlyException("learnerinstitution not found!");
            }
            return ObjectMapper.Map<LearnerInstitutionDto>(institution);
        }
        //GetAll
        [HttpGet]
        public async Task<List<LearnerInstitutionDto>> GetAllLearnerInstitutionsAsync()
        {
            var learnerinstitution = await _learnerinstitutionRepository.GetAllIncluding(x => x.Learner, x => x.Institution).ToListAsync();
            return ObjectMapper.Map<List<LearnerInstitutionDto>>(learnerinstitution);
        }
        public async Task<List<InstitutionDto>> GetAllInstitutionsForSpecificLearnerAsync(Guid id)
        {
            var learnerInstitutions = await _learnerinstitutionRepository.GetAllIncluding(e => e.Learner, e => e.Institution)
                                                .Where(e => e.Learner.Id == id)
                                                .ToListAsync();

            if (learnerInstitutions == null || learnerInstitutions.Count == 0)
            {
                throw new UserFriendlyException("No learnerinstitutions found for the provided ID!");
            }

            // Extract institution IDs
            var institutionIds = learnerInstitutions.Select(li => li.Institution.Id).ToList();

            // Fetch corresponding institutions
            var institutions = await _institutionRepository.GetAll().Where(i => institutionIds.Contains(i.Id)).ToListAsync();

            return ObjectMapper.Map<List<InstitutionDto>>(institutions);
        }

        //Update
        [HttpPut]
        public async Task<LearnerInstitutionDto> UpdateLearnerInstitutionAsync(LearnerInstitutionDto input)
        {
            var learner = _learnerRepository.Get(input.LearnerId) ?? throw new Exception("learner does not exist!");
            var institution= _institutionRepository.Get(input.InstitutionId) ?? throw new Exception("institution does not exist!");
            var learnerinstitution= new LearnerInstitution
            {
                Learner = learner,
                Institution = institution,
            };
            var update = await _learnerinstitutionRepository.UpdateAsync(ObjectMapper.Map(input, learnerinstitution));

            return ObjectMapper.Map<LearnerInstitutionDto>(update);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _learnerinstitutionRepository.DeleteAsync(id);
        }
    }
}
