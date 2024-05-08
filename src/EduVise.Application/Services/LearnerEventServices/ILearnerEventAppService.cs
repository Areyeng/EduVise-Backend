using Abp.Application.Services;
using EduVise.Services.EventServices.Dtos;
using EduVise.Services.LearnerEventServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerEventServices
{
    public interface ILearnerEventAppService : IApplicationService
    {
        Task<LearnerEventDto> CreateLearnerEventAsync(LearnerEventDto eventDto);
        Task<LearnerEventDto> GetByLearnerEventId(Guid id);
        Task<List<LearnerEventDto>> GetAllLearnerEventsAsync();
        Task<List<EventDto>> GetAllEventsForSpecificLearnerAsync(Guid id);
        Task<LearnerEventDto> UpdateLearnerEventAsync(LearnerEventDto input);
        Task Delete(Guid id);
    }
}
