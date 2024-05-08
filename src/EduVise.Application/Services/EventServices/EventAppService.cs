using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using EduVise.Domain;
using EduVise.Services.CourseServices;
using EduVise.Services.EventServices.Dtos;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.FundingServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.EventServices
{
    public class EventAppService : ApplicationService, IEventAppService
    {
        private readonly IRepository<Event,Guid> _eventRepository;
        private readonly IRepository<Institution, Guid> _institutionRepository;
        public EventAppService (IRepository<Event, Guid> eventRepository, IRepository<Institution, Guid> institutionRepository)
        {
            _eventRepository =  eventRepository;
            _institutionRepository = institutionRepository;
        }
        //Create
        [HttpPost]
        public async Task<EventDto> CreateEventAsync(EventDto input)
        {
            var institution = _institutionRepository.Get(input.InstitutionId) ?? throw new Exception("event does not exist!");
            var events = new Event
            {
                Name = input.Name,
                Description = input.Description,
                Type = input.Type,
                Date = input.Date,
                Venue = input.Venue,
                Institution = institution,
            };

            await _eventRepository.InsertAsync(events);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<EventDto>(events);
        }
        //GetbyId
        [HttpGet]
        public async Task<EventDto> GetByEventId(Guid id)
        {
            var events = await _eventRepository.GetAllIncluding(e => e.Institution)
                 .FirstOrDefaultAsync(e => e.Id == id);
            if (events == null)
            {
                throw new UserFriendlyException("event not found!");
            }
            return ObjectMapper.Map<EventDto>(events);
        }
        //GetAll
        [HttpGet]
        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllIncluding(x => x.Institution).ToListAsync();

            return ObjectMapper.Map<List<EventDto>>(events);
        }

        [HttpGet]
        public async Task<List<EventDto>> GetAllEventsByClosingAsync()
        {
            var currentDate = DateTime.UtcNow.Date;
            var events = await _eventRepository
                .GetAllListAsync(e => e.Date >= currentDate);

            var sortedEvents= events.OrderBy(e => e.Date);

            return ObjectMapper.Map<List<EventDto>>(sortedEvents);
        }
        //Update
        [HttpPut]
        public async Task<EventDto> UpdateEventAsync(EventDto input)
        {
            var institution = _institutionRepository.Get(input.InstitutionId) ?? throw new Exception("event does not exist!");
            var events = new Event
            {
                Name = input.Name,
                Description = input.Description,
                Type = input.Type,
                Date = input.Date,
                Venue = input.Venue,
                Institution = institution,
            };

            var update = await _eventRepository.UpdateAsync(ObjectMapper.Map(input, events));

            return ObjectMapper.Map<EventDto>(update);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _eventRepository.DeleteAsync(id);
        }
    }
}
