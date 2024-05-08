using Abp.Application.Services;
using EduVise.Services.FundingServices;
using EduVise.Services.FundingServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.FundingServices
{
    public interface IFundingAppService : IApplicationService
    {
        Task<FundingDto> CreateFundingAsync(FundingDto fundingDto);
        Task<FundingDto> GetByFundingId(Guid id);
        Task<List<FundingDto>> GetAllFundingsAsync();
        Task<List<FundingDto>> GetAllFundingsByClosingAsync();
        Task<FundingDto> UpdateFundingAsync(FundingDto input);
        Task Delete(Guid id);
    }
}
