using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.SavedResponseServices;
using EduVise.Services.ResponseServices.Dtos;
using EduVise.Services.SavedResponseServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.LearnerSkillServices.Dtos;

namespace EduVise.Services.SavedResponseServices
{
    public class SavedResponseAppService : ApplicationService, ISavedResponseAppService
    {
        private readonly IRepository<SavedResponse, Guid> _facultyRepository;
        private readonly IRepository<Institution, Guid> _institutionRepository;
        private readonly IRepository<SavedResponseDto, Guid> _savedResponseRepository;
        public SavedResponseAppService(IRepository<SavedResponse, Guid> facultyRepository, IRepository<Institution, Guid> institutionRepository, IRepository<SavedResponseDto, Guid> savedResponseRepository)
        {
            _facultyRepository = facultyRepository;
            _institutionRepository = institutionRepository;
            _savedResponseRepository = savedResponseRepository;
        }
        public async Task<SavedResponseDto> AddLearnerFacultiesAsync(Guid learner,Guid Faculty1,Guid Faculty2,Guid Faculty3)
        {
            var savedResponse = new SavedResponseDto
            {
                LearnerId = learner,
                FacultyOneId = Faculty1,
                FacultyTwoId = Faculty2,
                FacultyThreeId = Faculty3
            };

            // Save the updated response to the repository
            savedResponse = await _savedResponseRepository.InsertAsync(savedResponse);

            // Ensure the changes are saved to the database
            await CurrentUnitOfWork.SaveChangesAsync();

            return savedResponse;
        }

    }
}