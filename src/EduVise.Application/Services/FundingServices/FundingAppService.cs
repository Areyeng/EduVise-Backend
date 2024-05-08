using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduVise.Domain;
using EduVise.Services.FundingServices;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.FundingServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduVise.Services.InstitutionServices.Dtos;

namespace EduVise.Services.FundingServices
{
    public class FundingAppService : ApplicationService, IFundingAppService
    {
        private readonly IRepository<Funding, Guid> _fundingRepository;
        public FundingAppService(IRepository<Funding, Guid> fundingRepository)
        {
            _fundingRepository = fundingRepository;
        }
        //Create
        [HttpPost]
        public async Task<FundingDto> CreateFundingAsync(FundingDto input)
        {
            var fundinginput = ObjectMapper.Map<Funding>(input);
            fundinginput = await _fundingRepository.InsertAsync(fundinginput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<FundingDto>(fundinginput);
        }
        //GetbyId
        [HttpGet]
        public async Task<FundingDto> GetByFundingId(Guid id)
        {
            var fundings = await _fundingRepository.GetAsync(id);
            return ObjectMapper.Map<FundingDto>(fundings);
        }
        //GetAll
        [HttpGet]
        public async Task<List<FundingDto>> GetAllFundingsAsync()
        {
            var fundings = await _fundingRepository.GetAllListAsync();
            return ObjectMapper.Map<List<FundingDto>>(fundings);
        }
        [HttpGet]
        public async Task<List<FundingDto>> GetAllFundingsByClosingAsync()
        {
            var currentDate = DateTime.UtcNow.Date;
            var fundings = await _fundingRepository
                .GetAllListAsync(funding => funding.ClosingDate >= currentDate);

            var sortedFundings = fundings.OrderBy(funding => funding.ClosingDate);

            return ObjectMapper.Map<List<FundingDto>>(sortedFundings);
        }

        //Update
        [HttpPut]
        public async Task<FundingDto> UpdateFundingAsync(FundingDto input)
        {
            var fundinginput = ObjectMapper.Map<Funding>(input);
            fundinginput = await _fundingRepository.UpdateAsync(fundinginput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<FundingDto>(fundinginput);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _fundingRepository.DeleteAsync(id);
        }
    }
}
