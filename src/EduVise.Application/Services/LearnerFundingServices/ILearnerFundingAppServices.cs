using Abp.Application.Services;
using EduVise.Services.FundingServices.Dtos;
using EduVise.Services.LearnerFundingServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerFundingServices
{
    public interface ILearnerFundingAppService : IApplicationService
    {
        Task<LearnerFundingDto> CreateLearnerFundingAsync(LearnerFundingDto eventDto);
        Task<LearnerFundingDto> GetByLearnerFundingId(Guid id);
        Task<List<LearnerFundingDto>> GetAllLearnerFundingsAsync();
        Task<List<FundingDto>> GetAllFundingsForSpecificLearnerAsync(Guid id);
        Task<LearnerFundingDto> UpdateLearnerFundingAsync(LearnerFundingDto input);
        Task Delete(Guid id);
    }
}
