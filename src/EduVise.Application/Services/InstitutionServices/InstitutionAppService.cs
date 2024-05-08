using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.CourseServices;
using EduVise.Services.InstitutionServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.InstitutionServices
{
   public class InstitutionAppService : ApplicationService, IInstitutionAppService
    {
        private readonly IRepository<Institution,Guid> _institutionRepository;

        public InstitutionAppService (IRepository<Institution, Guid> institutionRepository)
        {
            _institutionRepository = institutionRepository;
        }
        //Create
        [HttpPost]
        public async  Task<InstitutionDto> CreateInstitutionAsync(InstitutionDto input)
        {
            var institutioninput = ObjectMapper.Map<Institution>(input);
            institutioninput=await _institutionRepository.InsertAsync(institutioninput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<InstitutionDto>(institutioninput);
        }
        //GetbyId
        [HttpGet]
        public async Task<InstitutionDto> GetByInstitutionId(Guid id)
        {
            var institutions = await _institutionRepository.GetAsync(id);
            return ObjectMapper.Map<InstitutionDto>(institutions);
        }
        //GetAll
        [HttpGet]
        public async Task<List<InstitutionDto>> GetAllInstitutionsAsync()
        {
            var institutions = await _institutionRepository.GetAllListAsync();
            return ObjectMapper.Map<List<InstitutionDto>>(institutions);
        }
        [HttpGet]
        public async Task<List<InstitutionDto>> GetAllInstitutionsByClosingAsync()
        {
            var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var institutions = await _institutionRepository
                .GetAllListAsync(institution => institution.ClosingDate >= currentDate);

            var sortedInstitutions = institutions.OrderBy(institution => institution.ClosingDate);

            return ObjectMapper.Map<List<InstitutionDto>>(sortedInstitutions);
        }



        //Update
        [HttpPut]
        public async Task<InstitutionDto> UpdateInstitutionAsync(InstitutionDto input)
        {
            var institutioninput = ObjectMapper.Map<Institution>(input);
            institutioninput = await _institutionRepository.UpdateAsync(institutioninput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<InstitutionDto>(institutioninput);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _institutionRepository.DeleteAsync(id);
        }
    }
}
