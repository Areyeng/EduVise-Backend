using Abp.Application.Services;
using EduVise.Services.LearnerServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerServices
{
    public interface ILearnerAppService : IApplicationService
    {
        Task<LearnerDto> CreateLearnerAsync(LearnerDto input);
        Task<LearnerDto> GetByLearnerId(Guid id);
        Task<List<LearnerDto>> GetAllLearnersAsync();
        Task<LearnerDto> UpdateLearnerAsync(LearnerDto input);
        Task Delete(Guid id);
    }
}
