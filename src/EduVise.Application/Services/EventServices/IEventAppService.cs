using Abp.Application.Services;
using EduVise.Services.EventServices;
using EduVise.Services.EventServices.Dtos;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace EduVise.Services.EventServices
{
    public interface IEventAppService :IApplicationService
    {
        Task<EventDto> CreateEventAsync (EventDto eventDto);
        Task<EventDto> GetByEventId(Guid id);
        Task<List<EventDto>> GetAllEventsAsync();
        Task<List<EventDto>> GetAllEventsByClosingAsync();
        Task<EventDto> UpdateEventAsync(EventDto input);
        Task Delete(Guid id);
    }
}
